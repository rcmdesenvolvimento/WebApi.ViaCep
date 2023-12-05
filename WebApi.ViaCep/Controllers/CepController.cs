using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViaCep.Dto;
using WebApi.ViaCep.Repository.Interface;

namespace WebApi.ViaCep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepRepository repository;
        public CepController(ICepRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{cep}")]
        //public Task<CepModelDTO> GetCepBrasil([FromServices] ICepRepository repository, string cep)
        public async Task<ActionResult> GetCepBrasil([FromRoute] string cep)
        {
            var response = await repository.GetCepBrasil(cep);

            //return repository.GetCepBrasil(cep);
            return Ok(response);
        }
    }
}
