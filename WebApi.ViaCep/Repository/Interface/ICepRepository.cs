using Refit;
using WebApi.ViaCep.Dto;
using WebApi.ViaCep.Model;

namespace WebApi.ViaCep.Repository.Interface
{
    public interface ICepRepository
    {
        [Get("/ws/{cep}/json")]
        Task<CepModel> GetCepBrasil(string cep);
    }
}
