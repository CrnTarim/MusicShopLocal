﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShopEntities.DTOs;
using MusicShopEntities.Entities;
using MusicShopEntities.Services;
using OfficeOpenXml;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MusicShop2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Album> _service;
        public AlbumController(IMapper mapper, IService<Album> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<List<Album>> All()
        {
            var album= await _service.GetAllAsync();
            var albumDto = _mapper.Map<List<Album>>(album.ToList());
            return albumDto;
        }

        [HttpGet("{id}")]
        public async Task<List<Album>> GetById(int id)
        {
            var album = await _service.GetAllAsync();
            var albumDto = _mapper.Map<List<Album>>(album);
            return albumDto;
        }
       
        [HttpPost]
        public async Task Save(AlbumDto albumDto)
        {
            await _service.AddAsync(_mapper.Map<Album>(albumDto));
        }
        

        [HttpPut("{id}")]
        public async Task Update(int id,AlbumDto albumDto)
        {
            var entity = await _service.GetbyIdAsync(id);
            if (entity != null)
            {
                _mapper.Map(albumDto, entity);
                await _service.UpdateAsync(entity);
            }
        }

        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            var album = await _service.GetbyIdAsync(id);
            await _service.RemoveAsync(album);
        }

        [HttpGet("export/excel/all")]
        public async Task<IActionResult> ExportAllAlbumsToExcel()
        {
            var albums = await _service.GetAllAsync();

            if (albums == null || !albums.Any())
            {
                return NotFound();
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Albums");

                worksheet.Cells["A1"].Value = "ID";
                worksheet.Cells["B1"].Value = "Name";
                worksheet.Cells["C1"].Value = "Singer";
                worksheet.Cells["D1"].Value = "Created Year";
                worksheet.Cells["E1"].Value = "Record Company Name";
                worksheet.Cells["F1"].Value = "Customer ID";
                worksheet.Cells["G1"].Value = "Created Date";
                worksheet.Cells["H1"].Value = "Updated Date";

                int row = 2;
                foreach (var album in albums)
                {
                    worksheet.Cells[row, 1].Value = album.Id;
                    worksheet.Cells[row, 2].Value = album.Name;
                    worksheet.Cells[row, 3].Value = album.Singer;
                    worksheet.Cells[row, 4].Value = album.CreatedYear;
                    worksheet.Cells[row, 5].Value = album.RecordCompanyName;
                    worksheet.Cells[row, 6].Value = album.CustomerId;
                    worksheet.Cells[row, 7].Value = album.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.Cells[row, 8].Value = album.UpdatedDate?.ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }

                var excelFileBytes = package.GetAsByteArray();

                return File(excelFileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "albums.xlsx");
            }
        }
    }
}