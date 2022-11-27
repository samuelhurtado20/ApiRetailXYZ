using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRetailXYZ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SucursalController : ControllerBase
    {
        private readonly RetailXyzContext _context;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<SucursalController> _logger;

        public SucursalController(RetailXyzContext context, IUnitOfWork uow, ILogger<SucursalController> logger)
        {
            _context = context;
            _uow = uow;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/Sucursal/GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var brand = await _context.Sucursal.ToListAsync();
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
        [Route("api/Sucursal/GetOne")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var Sucursal = await _uow.Sucursal.Get(id);
                if (Sucursal == null)
                {
                    return NotFound();
                }
                return Ok(Sucursal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Sucursal/GetAllSp")]
        public async Task<IActionResult> GetAllSp()
        {
            try
            {
                var collection = await _context.Sucursal.FromSqlRaw("EXECUTE GetAllSucursal").ToListAsync();
                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Sucursal/Insert")]
        public async Task<IActionResult> Post(Sucursal entity)
        {
            try
            {
                await _uow.Sucursal.Insert(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Sucursal/Update")]
        public IActionResult Update(Sucursal entity)
        {
            try
            {
                _uow.Sucursal.Update(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Sucursal/Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var brand = await _context.Sucursal
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
        [Route("api/Sucursal/DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var brand = await _context.Sucursal.FindAsync(id);
            _context.Sucursal.Remove(brand);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool Exists(Guid id)
        {
            return _context.Sucursal.Any(e => e.Id == id);
        }
    }
}