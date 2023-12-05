using Microsoft.EntityFrameworkCore;
using WebApi.ViaCep.Model;

namespace WebApi.ViaCep.Context
{
    public class CepDbContext : DbContext
    {
        public CepDbContext(DbContextOptions<CepDbContext> options) : base(options)
        { }

        public DbSet<CepModel> CepModel { get; set; }
    }
}
