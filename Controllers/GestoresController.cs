using apiGestores.Context;
using apiGestores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDbContext context;
        public GestoresController(AppDbContext _context)
        {
            context = _context;
        }

        // GET: api/<GestoresController>
        [HttpGet]
        public ActionResult Get()
        {
            //List < gestores_bd >
            return Ok(context.gestores_bd.ToList());
        }

        // GET api/<GestoresController>/5
        [HttpGet("{id}", Name = "GetGestor")]
        public ActionResult Get(int id)
        {
            var gestor = context.gestores_bd.FirstOrDefault(g => g.id == id);
            return Ok(gestor);
        }



        // POST api/<GestoresController>
        [HttpPost]
        public ActionResult Post([FromBody] gestores_bd gestor)
        {
            context.gestores_bd.Add(gestor);
            context.SaveChanges();
            return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
        }


        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] gestores_bd gestor)
        {
            if (gestor.id == id)
            {
                context.Entry(gestor).State = EntityState.Modified;
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<GestoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var gestor = context.gestores_bd.FirstOrDefault(g => g.id == id);
            if (gestor.id == id)
            {
                context.gestores_bd.Remove(gestor);
                context.SaveChanges();
                return Ok(id);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
