using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRetailXYZ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RespuestaController : ControllerBase
    {
        private readonly RetailXyzContext _context;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<RespuestaController> _logger;

        public RespuestaController(RetailXyzContext context, IUnitOfWork uow, ILogger<RespuestaController> logger)
        {
            _context = context;
            _uow = uow;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/Respuesta/GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var brand = await _context.Respuesta.ToListAsync();
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
        [Route("api/Respuesta/GetOne")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var Respuesta = await _uow.Respuesta.Get(id);
                if (Respuesta == null)
                {
                    return NotFound();
                }
                return Ok(Respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Respuesta/GetAllSp")]
        public async Task<IActionResult> GetAllSp()
        {
            try
            {
                var collection = await _context.Respuesta.FromSqlRaw("EXECUTE GetAllRespuesta").ToListAsync();
                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Respuesta/Insert")]
        public async Task<IActionResult> Post(Respuestas entity)
        {
            try
            {
                await _uow.Respuesta.Insert(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Respuesta/Update")]
        public IActionResult Update(Respuestas entity)
        {
            try
            {
                _uow.Respuesta.Update(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Respuesta/Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var brand = await _context.Respuesta
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
        [Route("api/Respuesta/DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var brand = await _context.Respuesta.FindAsync(id);
            _context.Respuesta.Remove(brand);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool Exists(Guid id)
        {
            return _context.Respuesta.Any(e => e.Id == id);
        }
    }
}