using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using OrtizMed.Infra.Data.Query.Queries.Medico.Get;
using OrtizMed.Infra.Data.Query.Queries.Medico;

namespace OrtizMed.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : BaseController
    {
        private readonly IMediator _mediator;

        public MedicoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => 
            await GenerateResponseAsync(async () => await _mediator.Send(new GetMedicoQuery()));

        /// <summary>Filtro: 0 - nome | 1 - região | 2 - especialidade</summary>
        [HttpGet("{tipoFiltro}/{filtro}")]
        public async Task<IActionResult> Get(FiltroPesquisa tipoFiltro, string filtro) => 
            await GenerateResponseAsync(async () => await _mediator.Send(new GetMedicoQuery(tipoFiltro, filtro)));

        [HttpPost]
        public void Post([FromBody] string request)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string request)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
