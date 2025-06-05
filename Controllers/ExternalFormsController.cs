using ExternalFormsMicroservice.DTOs;
using ExternalFormsMicroserviceMain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExternalFormsMicroservice.Controllers
{
    [ApiController]
    [Route("api/externalforms")]
    public class ExternalFormsController : ControllerBase
    {
        private readonly FormApplicationService _formService;

        public ExternalFormsController(FormApplicationService formService)
        {
            _formService = formService;
        }

        [HttpGet("forms")]
        public async Task<ActionResult<List<FormApplicationDto>>> GetForms()
        {
            var forms = await _formService.GetAllApplicationsAsync();
            return Ok(forms);
        }

        [HttpGet("")]
        public IActionResult GetRoot()
        {
            return Ok("External Forms Microservice is running.");
        }

        [HttpPost("apply")]
        public async Task<ActionResult<FormApplicationDto>> ApplyForForm([FromBody] ApplyFormRequestDto request)
        {
            if (string.IsNullOrEmpty(request.StudentId) || string.IsNullOrEmpty(request.FormType))
            {
                return BadRequest("StudentId and FormType are required.");
            }

            var application = await _formService.ApplyForFormAsync(request.StudentId, request.FormType);
            return Ok(application);
        }

        [HttpPost("apply/reconsideration")]
        public async Task<IActionResult> ApplyReconsideration([FromBody] DTOs.ReconsiderationFormDto form)
        {
            if (form == null || string.IsNullOrEmpty(form.StudentId))
            {
                return BadRequest("Invalid reconsideration form data.");
            }
            var result = await _formService.ApplyReconsiderationFormAsync(form);
            return Ok(result);
        }

        [HttpPost("apply/compassionateaegrotat")]
        public async Task<IActionResult> ApplyCompassionateAegrotat([FromBody] DTOs.CompassionateAegrotatFormDto form)
        {
            if (form == null || string.IsNullOrEmpty(form.StudentId))
            {
                return BadRequest("Invalid compassionate/aegrotat form data.");
            }
            var result = await _formService.ApplyCompassionateAegrotatFormAsync(form);
            return Ok(result);
        }

        [HttpPost("apply/completionprogramme")]
        public async Task<IActionResult> ApplyCompletionProgramme([FromBody] DTOs.CompletionProgrammeFormDto form)
        {
            if (form == null || string.IsNullOrEmpty(form.StudentId))
            {
                return BadRequest("Invalid completion programme form data.");
            }
            var result = await _formService.ApplyCompletionProgrammeFormAsync(form);
            return Ok(result);
        }
    }
}
