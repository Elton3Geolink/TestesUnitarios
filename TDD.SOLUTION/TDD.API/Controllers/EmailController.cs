using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TDD.SERVICOS;

namespace TDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailServico _emailServico;

        public EmailController(EmailServico emailServico)
        {
            _emailServico = emailServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            bool sucesso = await _emailServico.EnviarEmail();

            if(sucesso)
                return Ok("email enviado com sucesso");

            return BadRequest("email nao enviado");
        }
    }
}
