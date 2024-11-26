using APIDemo.Dtos;
using APIDemo.Mappers;
using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        ProductContext cntx;
        public ProductAPIController(ProductContext cntx)
        { 
          this.cntx = cntx;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            //return Ok(this.cntx.Products.ToList());
            var res = this.cntx.Products.Select(
                 x => x.MapToProductDto()
                );
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProducts([FromRoute]int id)
        {
            var rec = this.cntx.Products.Find(id).MapToProductDto();
            if (rec == null)
            {
                return NotFound();
            }
            return Ok(rec);
        }


        [HttpPost]
        public IActionResult Create([FromBody]ProductCreateDto rec)
        {
            if (rec == null)
                return BadRequest("Model is Null!");

            var model = rec.MapToProduct();
            this.cntx.Products.Add(model);
            this.cntx.SaveChanges();
            return CreatedAtAction("Create", rec);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int id,[FromBody]ProductUpdateDto rec)
        {
            if (rec == null)
                return BadRequest("Model is Null!");

            if (id == 0)
                return BadRequest("ID can not be Zero!");

            var oldrec = this.cntx.Products.Find(id);
            if (oldrec == null)
                return NotFound("Record Not Found");
            
            oldrec.ProductName=rec.ProductName;
            oldrec.Price=rec.Price;
            oldrec.ProductCategoryID = rec.ProductCategoryID;
            oldrec.MfgName =rec.MfgName;
            this.cntx.SaveChanges();
            return Ok(oldrec);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id) {
            if (id == 0)
                return BadRequest();
          
            var oldrec = this.cntx.Products.Find(id);
            if (oldrec == null)
                return NotFound();

            this.cntx.Products.Remove(oldrec);
            this.cntx.SaveChanges();
            return NoContent();
        }

    }
}
