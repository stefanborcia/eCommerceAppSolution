﻿using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await categoryService.GetAllAsync();

            return data.Count() > 0 ? Ok(data) : NotFound(data);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetSignle(Guid id)
        {
            var data = await categoryService.GetByIdAsync(id);

            return data != null ? Ok(data) : NotFound(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreateCategory category)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var result = await categoryService.AddAsync(category);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await categoryService.UpdateAsync(category);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await categoryService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
