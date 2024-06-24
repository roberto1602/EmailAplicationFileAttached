using Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/email-aplication-file-attached")]
    [ApiController]
    public class SendEmailController(ILogicEmailFile emailFile) : ControllerBase
    {
        private readonly ILogicEmailFile emailFile = emailFile;

        [HttpGet("send-email", Name = "EmailAplicationFileAttached")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SendEmail(int idUser)
        {
            try
            {
                var responseEmail = await emailFile.GetStates(idUser);

                if (responseEmail == null)
                    return NotFound();
                else
                    return Ok(responseEmail);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}