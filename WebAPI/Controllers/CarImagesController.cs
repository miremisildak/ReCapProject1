﻿using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] int carId, [FromForm] IFormFile file)
        {
            var result = _carImageService.Add(carId, file);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            var result = _carImageService.Delete(id);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm]  int id, [FromForm]  IFormFile file)
        {
            var result = _carImageService.Update(id, file);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getByCarId")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
