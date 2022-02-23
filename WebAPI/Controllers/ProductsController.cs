using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//c# atribute --javada annotation
   
    //Products (pluriels)
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //debendennt to abstract not to concrete class
        // IoC Container --Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        //SWAGGER
        public IActionResult Get()
        {
            var result =_productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
            
        }

        //setting names for the multiple operations which is gett
        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        
        //want to get a product ? how through parantesis
        //postmandan angulardan react dan aldıgım urunu koyuyorum
        public IActionResult Post(Product product)
        {
            var result =_productService.add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
