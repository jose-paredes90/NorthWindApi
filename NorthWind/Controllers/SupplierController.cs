using Microsoft.AspNetCore.Mvc;
using NorthWind.Dto;
using NorthWind.Dto.Request;
using NorthWind.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierBiz supplierBiz;

        public SupplierController(ISupplierBiz supplierBiz)
        {
            this.supplierBiz = supplierBiz;
        }

        [HttpGet, Route("{supplierId}")]
        public IActionResult Get(int supplierId)
        {
            SupplierDto proveedor = supplierBiz.GetSupplierById(supplierId);

            return Ok(proveedor);
        }


        [HttpGet, Route("")]
        public IActionResult GetCity([FromQuery] string city)
        {
            List<SupplierDto> supplierDto = supplierBiz.GetCustomersByCity(city);
            return Ok(supplierDto);
        }

        [HttpPost, Route("")]
        public IActionResult Post([FromBody] SupplierRequest request )
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
             var supplier = supplierBiz.SaveSupplier(request);
            SupplierDto response = supplierBiz.GetSupplierById(supplier);
            return Created($"api/v1/supplier/{supplier}", response);
        }

        [HttpPut, Route("{id}")]
        public IActionResult Put(int id, [FromBody] SupplierUpdateRequest supplierUpdate )
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var supplier = supplierBiz.UpdateSupplier(id, supplierUpdate);
            if(supplier == null)
            {
                return NotFound();
            }   
            return Ok(supplier);
        }

        [HttpDelete, Route("{id}")]
        public IActionResult Delete(int id)
        {
           supplierBiz.DeleteSupplier(id);
            return NoContent();
        }
    }
}
