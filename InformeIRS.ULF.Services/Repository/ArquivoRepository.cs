using InformeIR.ULF.Services.Context;
using InformeIR.ULF.Services.Models.Dtos;
using InformeIR.ULF.Services.Models.Entities;
using InformeIR.ULF.Services.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using System.Threading.Tasks;


namespace InformeIR.ULF.Services.Repository
{
    public class ArquivoRepository : BaseRepository, IArquivoRepository
    {
        private readonly InformeIRSContexto _context;
        public ArquivoRepository(InformeIRSContexto context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArquivoDto>> GetArquivos()
        {
            return await _context.Arquivo
                .Where(x => x.IndCompetenciaLiberada == "S")
                .Select(x => new ArquivoDto 
                {
                  Id = x.Id, 
                  Nome = x.Nome, 
                  AnoReferencia = x.AnoReferencia,
                  IndCompetenciaLiberada = x.IndCompetenciaLiberada
                }).ToListAsync();
        }

        public async Task<ArquivoDto> GetArquivoBy(int id)
        {

            return await _context.Arquivo.Select(p => new ArquivoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    AnoReferencia = p.AnoReferencia,
                    IndCompetenciaLiberada = p.IndCompetenciaLiberada
                })
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ArquivoDto>> GetArquivoByAno(int anoReferencia)
        {
            //Busca informação do Ficheiro por ano de Referência apenas com a Competência Liberada IndCompetenciaLiberada == "N"
            

            return await _context.Arquivo
                .Select(x => new ArquivoDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    AnoReferencia = x.AnoReferencia,
                    IndCompetenciaLiberada = x.IndCompetenciaLiberada
                })
                .Where(x => x.AnoReferencia == anoReferencia && x.IndCompetenciaLiberada == "N")
                .ToListAsync();
        }

    }
}
