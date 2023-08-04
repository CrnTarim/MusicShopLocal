using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShopEntities.DTOs;
using MusicShopEntities.Entities;
using MusicShopEntities.Services;
using OfficeOpenXml;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml.Drawing.Chart;

namespace MusicShop2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordCompanyController : ControllerBase
    {
     
        private readonly IMapper _mapper;
        private readonly IService<RecordCompany> _service;
        public RecordCompanyController(IMapper mapper, IService<RecordCompany> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<List<RecordCompanyDto>> All()
        {
            var recordCompany = await _service.GetAllAsync();
            var recordCompanyDto = _mapper.Map<List<RecordCompanyDto>>(recordCompany.ToList());
            return recordCompanyDto;
        }

        [HttpGet("{id}")]
        public async Task<List<RecordCompany>> GetById(int id)
        {
            var recordCompany = await _service.GetAllAsync();
            var recordCompanyDto = _mapper.Map<List<RecordCompany>>(recordCompany);
            return recordCompanyDto;
        }

        [HttpPost]
        public async Task Save(RecordCompanyDto recordCompanyDto)
        {
            await _service.AddAsync(_mapper.Map<RecordCompany>(recordCompanyDto));
        }

        [HttpPut("{id}")]
        public async Task Update(int id, RecordCompanyDto recordCompanyDto)
        {
            var entity = await _service.GetbyIdAsync(id);
            if (entity != null)
            {
                _mapper.Map(recordCompanyDto, entity);
                await _service.UpdateAsync(entity);
            }
        }

        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            var recordCompany = await _service.GetbyIdAsync(id);
            await _service.RemoveAsync(recordCompany);
        }

        [HttpGet("export/excel/all")]
        public async Task<IActionResult> ExportToExcel()
        {
            var recordCompanies = await _service.GetAllAsync();

            if (recordCompanies == null || !recordCompanies.Any())
            {
                return NotFound();
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("RecordCompanies");

                worksheet.Cells["A1"].Value = "ID";
                worksheet.Cells["B1"].Value = "Name";
                worksheet.Cells["C1"].Value = "Company Year";
                worksheet.Cells["D1"].Value = "Company Value";
                worksheet.Cells["E1"].Value = "Album ID";
                worksheet.Cells["F1"].Value = "Created Date";
                worksheet.Cells["G1"].Value = "Updated Date";

                int row = 2;
                foreach (var company in recordCompanies)
                {
                    worksheet.Cells[row, 1].Value = company.Id;
                    worksheet.Cells[row, 2].Value = company.Name;
                    worksheet.Cells[row, 3].Value = company.CompanyYear;
                    worksheet.Cells[row, 4].Value = company.CompanyValue;
                    worksheet.Cells[row, 5].Value = company.AlbumId;
                    worksheet.Cells[row, 6].Value = company.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.Cells[row, 7].Value = company.UpdatedDate?.ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }

                var excelFileBytes = package.GetAsByteArray();

                return File(excelFileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "record_companies.xlsx");
            }

        }

        [HttpGet("export/pdf/all")]
        public async Task<IActionResult> ExportPdf()
        {
            var recordCompanies = await _service.GetAllAsync();

            if (recordCompanies == null || !recordCompanies.Any())
            {
                return NotFound();
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("RecordCompanies");

                worksheet.Cells["A1"].Value = "ID";
                worksheet.Cells["B1"].Value = "Name";
                worksheet.Cells["C1"].Value = "Company Year";
                worksheet.Cells["D1"].Value = "Company Value";
                worksheet.Cells["E1"].Value = "Album ID";
                worksheet.Cells["F1"].Value = "Created Date";
                worksheet.Cells["G1"].Value = "Updated Date";

                int row = 2;
                foreach (var company in recordCompanies)
                {
                    worksheet.Cells[row, 1].Value = company.Id;
                    worksheet.Cells[row, 2].Value = company.Name;
                    worksheet.Cells[row, 3].Value = company.CompanyYear;
                    worksheet.Cells[row, 4].Value = company.CompanyValue;
                    worksheet.Cells[row, 5].Value = company.AlbumId;
                    worksheet.Cells[row, 6].Value = company.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.Cells[row, 7].Value = company.UpdatedDate?.ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }


                var excelFileBytes = package.GetAsByteArray();

                return File(excelFileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "recordcampnies.xlsx");
            }
        }

        
    }
}
