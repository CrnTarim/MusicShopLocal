﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShopEntities.DTOs;
using MusicShopEntities.Entities;
using MusicShopEntities.Services;
using MusicShopService.Services;
using OfficeOpenXml;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.SignalR;
using MusicShop2.Models;

namespace MusicShop2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;
        private readonly IHubContext<BroadcastHubs, Models.IHubClients> _hub;


        public CustomerController(IMapper mapper, ICustomerService service, IHubContext<BroadcastHubs, Models.IHubClients> hub)
        {
            _mapper = mapper;
            _service = service;
            _hub = hub;
        }

        [HttpGet]
        public async Task<List<CustomerDto>> All()
        {
            var customer = await _service.GetAllAsync();
            var customerDto = _mapper.Map<List<CustomerDto>>(customer.ToList());
            await _hub.Clients.All.BroadcastMessage();
            return customerDto;
        }

        [HttpGet("{id}")]
        public async Task<List<Customer>> GetById(int id)
        {
            var customer = await _service.GetAllAsync();
            var customerDto = _mapper.Map<List<Customer>>(customer);
            await _hub.Clients.All.BroadcastMessage();
            return customerDto;
        }

        [HttpPost]
        public async Task Save(CustomerDto customerDto)
        {
            await _service.AddAsync(_mapper.Map<Customer>(customerDto));
            await _hub.Clients.All.BroadcastMessage();

        }

        [HttpPut("{id}")]
        public async Task Update(int id, CustomerDto customerDto)
        {
            var entity = await _service.GetbyIdAsync(id);
            if (entity != null)
            {
                _mapper.Map(customerDto, entity);
                await _service.UpdateAsync(entity);
            }
        }

        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            var customer = await _service.GetbyIdAsync(id);
            await _service.RemoveAsync(customer);
        }

        [HttpGet("[action]/{customerId}")]
        public async Task<ActionResult<List<AlbumDto>>> GetCustomerAlbumsAsync(int customerId)
        {
            var albums = await _service.GetAllAlbum(customerId);
            return albums;
        }
        

        [HttpGet("export/excel/all")]
        public async Task<IActionResult> ExportAllCustomersToExcel()
        {
            var customers = await _service.GetAllAsync();

            if (customers == null || !customers.Any())
            {
                return NotFound(); 
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Customers");

                worksheet.Cells["A1"].Value = "ID";
                worksheet.Cells["B1"].Value = "Name";
                worksheet.Cells["C1"].Value = "Email";
                worksheet.Cells["D1"].Value = "Phone";
                worksheet.Cells["E1"].Value = "Created Date";
                worksheet.Cells["F1"].Value = "Updated Date";

                int row = 2;
                foreach (var customer in customers)
                {
                    worksheet.Cells[row, 1].Value = customer.Id;
                    worksheet.Cells[row, 2].Value = customer.Name;
                    worksheet.Cells[row, 3].Value = customer.Email;
                    worksheet.Cells[row, 4].Value = customer.Phone;
                    worksheet.Cells[row, 5].Value = customer.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.Cells[row, 6].Value = customer.UpdatedDate?.ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }
               
                var excelFileBytes = package.GetAsByteArray();
               
                return File(excelFileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "customers.xlsx");
            }

        }      

        [HttpGet("export/pdf/all")]
        public async Task<IActionResult> ExportEmployeesPdf() 
        {
            var customers = await _service.GetAllAsync(); 

            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                using (var document = new Document())
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();

                    var table = new PdfPTable(3);
                    table.AddCell("Id");
                    table.AddCell("Name");
                    table.AddCell("Phone");

                    foreach (var customer in customers)
                    {
                        table.AddCell(customer.Id.ToString());
                        table.AddCell(customer.Name);
                        table.AddCell(customer.Phone);
                    }

                    document.Add(table);
                    document.Close();
                }
                fileBytes = stream.ToArray();
            }

            var contentType = "application/pdf";
            var fileName = "customer.pdf";

            return File(fileBytes, contentType, fileName);
        }
    }

}
