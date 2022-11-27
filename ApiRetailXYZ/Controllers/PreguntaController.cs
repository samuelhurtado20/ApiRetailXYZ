using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRetailXYZ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreguntaController : ControllerBase
    {
        private readonly RetailXyzContext _context;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<PreguntaController> _logger;

        public PreguntaController(RetailXyzContext context, IUnitOfWork uow, ILogger<PreguntaController> logger)
        {
            _context = context;
            _uow = uow;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/Pregunta/GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var brand = await _context.Pregunta.ToListAsync();
                if (brand == null)
                {
                    return NotFound();
                }

                return Ok(brand);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Pregunta/GetOne")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var Pregunta = await _uow.Pregunta.Get(id);
                if (Pregunta == null)
                {
                    return NotFound();
                }
                return Ok(Pregunta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Pregunta/GetAllSp")]
        public async Task<IActionResult> GetAllSp()
        {
            try
            {
                var collection = await _context.Pregunta.FromSqlRaw("EXECUTE GetAllPregunta").ToListAsync();
                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Pregunta/Insert")]
        public async Task<IActionResult> Post(Preguntas entity)
        {
            try
            {
                await _uow.Pregunta.Insert(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Pregunta/Update")]
        public IActionResult Update(Preguntas entity)
        {
            try
            {
                _uow.Pregunta.Update(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Pregunta/Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var brand = await _context.Pregunta
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (brand == null)
                {
                    return NotFound();
                }

                return Ok(brand);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/Pregunta/DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var brand = await _context.Pregunta.FindAsync(id);
            _context.Pregunta.Remove(brand);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool Exists(Guid id)
        {
            return _context.Pregunta.Any(e => e.Id == id);
        }
    }
}