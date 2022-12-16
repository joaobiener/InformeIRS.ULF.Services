using AutoMapper;
using InformeIR.ULF.Services.Models.Dtos;
using InformeIR.ULF.Services.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InformeIR.ULF.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArquivoController : ControllerBase
    {
        private readonly IArquivoRepository _repository;
        private readonly IMapper _mapper;

        public ArquivoController(IArquivoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var arquivos = await _repository.GetArquivos();

            return arquivos.Any()
                ? Ok(arquivos)
                : NotFound("Arquivos não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest("Dados inválidos.");

            var arquivo = await _repository.GetArquivoBy(id);

            var ArquivoRetorno = _mapper.Map<ArquivoDto>(arquivo);

            return ArquivoRetorno != null
                ? Ok(ArquivoRetorno)
                : NotFound("Arquivos não encontrads");
        }

        [HttpGet("AnoReferenica/{anoReferencia}")]
        public async Task<IActionResult> GetByAno(int anoReferencia)
        {
            if (anoReferencia <= 0) return BadRequest("Dados inválidos.");

            var arquivo = await _repository.GetArquivoByAno(anoReferencia);

            //var ArquivoRetorno = _mapper.Map<ArquivoDto>(arquivo);

            return arquivo != null
                ? Ok(arquivo)
                : NotFound("Arquivos não encontrads");
        }
    }
}
