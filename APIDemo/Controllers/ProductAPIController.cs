using APIDemo.Dtos;
using APIDemo.Helpers;
using APIDemo.Interfaces;
using APIDemo.Mappers;
using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductRepo _repo;
        public ProductAPIController(IProductRepo repo)
        { 
          this._repo = repo;
        }

        [HttpGet]
        public async Task <IActionResult> GetProducts([FromQuery]QueryObject query)
        {
            //return Ok(this.cntx.Products.ToList());
            var res =await this._repo.GetAll(query);
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProducts([FromRoute]int id)
        {
            var rec = await this._repo.GetById(id);
            if (rec == null)
            {
                return NotFound();
            }
            return Ok(rec);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProductCreateDto rec)
        {
            if (rec == null)
                return BadRequest("Model is Null!");

            var res=await this._repo.Create(rec);
            return CreatedAtAction("Create", res);
        }

        [HttpPut("{id:int}")]
        public async  Task<IActionResult> Update([FromRoute]int id,[FromBody]ProductUpdateDto rec)
        {
            if (rec == null)
                return BadRequest("Model is Null!");

            if (id == 0)
                return BadRequest("ID can not be Zero!");

           var res = this._repo.Update(id, rec);
            return Ok(res);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            if (id == 0)
                return BadRequest();
            await this._repo.Delete(id);
            return NoContent();
        }

    }
}
