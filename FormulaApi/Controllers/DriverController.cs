using FormulaApi.Core.Repositories;
using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriverController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Driver.All());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var driver = await _unitOfWork.Driver.GetById(id);

            if (driver == null) return NotFound();

            return Ok(driver);
        }

        [HttpPost]
        [Route("AddDriver")]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            await _unitOfWork.Driver.Add(driver);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpGet]
        [Route("GetDriverByNumber")]
        public async Task<IActionResult> GetDriverByNumber(int number)
        {
            var driver = await _unitOfWork.Driver.GetDriverNumber(number);

            if (driver == null) return NotFound();

            return Ok(driver);
        }

        [HttpDelete]
        [Route("DeleteDriver")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _unitOfWork.Driver.GetById(id);

            if (driver == null) return NotFound();

            await _unitOfWork.Driver.Delete(driver);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdateDriver")]
        public async Task<IActionResult> UpdateDriver(Driver driver)
        {
            var existDriver = await _unitOfWork.Driver.GetById(driver.Id);

            if (existDriver == null) return NotFound();

            await _unitOfWork.Driver.Upate(driver);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
