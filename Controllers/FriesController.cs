using System;
using System.Collections.Generic;
using burgershack_winter20.Models;
using burgershack_winter20.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgershack_winter20.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriesController : ControllerBase
    {
        private readonly FryService _service;

        public FriesController(FryService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Fry>> Get()
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
        public ActionResult<Fry> Get(int id)
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
        public ActionResult<Fry> Create([FromBody] Fry newFry)
        {
            try
            {
                return Ok(_service.Create(newFry));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Fry> Edit([FromBody] Fry editFry, int id)
        {
            try
            {
                editFry.Id = id;
                return Ok(_service.Edit(editFry));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")] // DELETE
        public ActionResult<Fry> Delete(int id)
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