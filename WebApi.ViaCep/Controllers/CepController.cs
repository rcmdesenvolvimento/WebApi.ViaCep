using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WebApi.ViaCep.Context;
using WebApi.ViaCep.Dto;
using WebApi.ViaCep.Model;
using WebApi.ViaCep.Repository.Interface;

namespace WebApi.ViaCep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepRepository repository;
        private readonly CepDbContext _context;
        public CepController(ICepRepository repository, CepDbContext context)
        {
            this.repository = repository;
            _context = context;
        }

        [HttpGet("{cep}")]
        //public Task<CepModelDTO> GetCepBrasil([FromServices] ICepRepository repository, string cep)
        public async Task<ActionResult> GetCepBrasil([FromRoute] string cep)
        {
            //var response = await repository.GetCepBrasil(cep);

            try
            {
                var response = await repository.GetCepBrasil(cep);

                _context.CepModel.Add(response);
                _context.SaveChangesAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Cep inexistente : " + ex.Message);
            }

        }

        [HttpGet]
        public async Task<List<CepModel>> getAllCep()
        {
            return await _context.CepModel.ToListAsync();
        }

    }
}
