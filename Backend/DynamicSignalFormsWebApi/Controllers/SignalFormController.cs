using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DataTransferObject.SignalFormDto;
using ServiceLayer.Service;

namespace DynamicSignalFormsWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SignalFormController : ControllerBase
    {
        private readonly ISignalFormService _signalFormService;

        public SignalFormController(ISignalFormService signalFormService)
        {
            _signalFormService = signalFormService;
        }

        [HttpGet("GetAllForms")]
        public async Task<IActionResult> GetAllForms()
        {
            try
            {
                var items = await _signalFormService.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong: " + ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpGet("GetFormById")]
        public async Task<IActionResult> GetFormById(int id)
        {
            try
            {
                var item = await _signalFormService.GetById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong: " + ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpGet("GetFormArrays")]
        public async Task<IActionResult> GetFormArrays()
        {
            try
            {
                var items = await _signalFormService.GetFormArrays();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong: " + ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SignalFormDto dto)
        {
            try
            {
                await _signalFormService.Create(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong: " + ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] SignalFormDto dto)
        {
            try
            {
                await _signalFormService.Update(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong: " + ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _signalFormService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong: " + ex.Message + " - " + ex.InnerException);
            }
        }

    }

}