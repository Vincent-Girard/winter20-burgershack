using System;
using System.Collections.Generic;
using burgershack_winter20.Models;
using burgershack_winter20.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgershack_winter20.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly DrinkService _service;

        public DrinksController(DrinkService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Drink>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")] // GETBYID
        public ActionResult<Drink> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Drink> Create([FromBody] Drink newDrink)
        {
            try
            {
                return Ok(_service.Create(newDrink));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Drink> Edit([FromBody] Drink editDrink, int id)
        {
            try
            {
                editDrink.Id = id;
                return Ok(_service.Edit(editDrink));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")] // DELETE
        public ActionResult<Drink> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}