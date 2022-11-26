using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRetailXYZ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncuestaController : ControllerBase
    {
        private readonly RetailXyzContext _context;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<EncuestaController> _logger;

        public EncuestaController(RetailXyzContext context, IUnitOfWork uow, ILogger<EncuestaController> logger)
        {
            _context = context;
            _uow = uow;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/encuesta/GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var brand = await _context.Encuesta.ToListAsync();
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
        [Route("api/encuesta/GetOne")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var encuesta = await _uow.Encuesta.Get(id);
                if (encuesta == null)
                {
                    return NotFound();
                }
                return Ok(encuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/encuesta/GetAllSp")]
        public async Task<IActionResult> GetAllSp()
        {
            try
            {
                var collection = await _context.Encuesta.FromSqlRaw("EXECUTE GetAllEncuesta").ToListAsync();
                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/encuesta/Insert")]
        public async Task<IActionResult> Post(Encuesta entity)
        {
            try
            {
                await _uow.Encuesta.Insert(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/encuesta/Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var brand = await _context.Encuesta
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

        [HttpPost]
        [Route("api/encuesta/DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var brand = await _context.Encuesta.FindAsync(id);
            _context.Encuesta.Remove(brand);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool BrandExists(Guid id)
        {
            return _context.Encuesta.Any(e => e.Id == id);
        }
    }
}