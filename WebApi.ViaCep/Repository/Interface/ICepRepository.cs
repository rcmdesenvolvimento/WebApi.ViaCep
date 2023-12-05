using Refit;
using WebApi.ViaCep.Dto;

namespace WebApi.ViaCep.Repository.Interface
{
    public interface ICepRepository
    {
        [Get("/ws/{cep}/json")]
        Task<CepModelDTO> GetCepBrasil(string cep);
    }
}
