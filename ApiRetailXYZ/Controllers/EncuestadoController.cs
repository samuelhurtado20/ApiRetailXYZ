using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRetailXYZ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncuestadoController : ControllerBase
    {
        private readonly RetailXyzContext _context;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<EncuestadoController> _logger;

        public EncuestadoController(RetailXyzContext context, IUnitOfWork uow, ILogger<EncuestadoController> logger)
        {
            _context = context;
            _uow = uow;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/Encuestado/GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var brand = await _context.Encuestado.ToListAsync();
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
        [Route("api/Encuestado/GetOne")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var Encuestado = await _uow.Encuestado.Get(id);
                if (Encuestado == null)
                {
                    return NotFound();
                }
                return Ok(Encuestado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Encuestado/GetAllSp")]
        public async Task<IActionResult> GetAllSp()
        {
            try
            {
                var collection = await _context.Encuestado.FromSqlRaw("EXECUTE GetAllEncuestado").ToListAsync();
                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Encuestado/Insert")]
        public async Task<IActionResult> Post(Encuestado entity)
        {
            try
            {
                await _uow.Encuestado.Insert(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Encuestado/Update")]
        public IActionResult Update(Encuestado entity)
        {
            try
            {
                _uow.Encuestado.Update(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Encuestado/Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var brand = await _context.Encuestado
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
        [Route("api/Encuestado/DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var brand = await _context.Encuestado.FindAsync(id);
            _context.Encuestado.Remove(brand);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}