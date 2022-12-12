using Microsoft.EntityFrameworkCore;
using InformeIR.ULF.Services.Models.Entities;

namespace InformeIR.ULF.Services.Context
{
    public class InformeIRSContexto : DbContext
    {
        public InformeIRSContexto(DbContextOptions<InformeIRSContexto> options):base(options) 
        {
            //Database.EnsureCreated(); Só em desenvolvimento
            
        }

        public DbSet<Arquivo> Arquivo { get; set; }

        public DbSet<InformeIRValores> InformeIRValores { get; set; }

    }
}
