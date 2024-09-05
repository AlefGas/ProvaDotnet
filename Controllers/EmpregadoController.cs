using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empresa.Data;
using Empresa.Models;
using Empresa.Reapository;
using Empresa.Reapository.Interface;

namespace Empresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpregadoController : ControllerBase
    {
        private readonly IEmpregadoRepository iempregadoRepository;

        public EmpregadoController(IEmpregadoRepository empregadoRepository)
        {
            this.iempregadoRepository = empregadoRepository;
        }


        [HttpGet("Departamento/{depid}")]
        public async Task<ActionResult<List<Empregado>>> GetEmpregadosByDepId(int depid)
        {
            try
            {
                var empregados = await iempregadoRepository.GetEmpregadosByDepIdAsync(depid);

                if (empregados == null)
                {
                    return NotFound($"Nenhum empregado encontrado para o departamento com id = {depid}");
                }

                return Ok(empregados);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpregados()
        {
            try
            {
                return Ok(await iempregadoRepository.GetEmpregados());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmpregado(int id)
        {
            try
            {
                var result = await iempregadoRepository.GetEmpregado(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar usuario do banco de dados");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmpregado([FromBody] Empregado empregado)
        {
            try
            {
                var result = await iempregadoRepository.GetEmpregado(empregado.EmpId);

                if (result == null)
                    return NotFound($"Empregado com id = {empregado.EmpId} não encontrado");

                return Ok(await iempregadoRepository.UpdateEmpregado(empregado));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpregado([FromBody] Empregado empregado)
        {
            try
            {
                if (empregado == null)
                    return BadRequest();

                var result = await iempregadoRepository.AddEmpregado(empregado);

                return CreatedAtAction(nameof(GetEmpregado), new { id = result.EmpId }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados ao banco de dados");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Empregado>> DeleteEmpregado(int id)
        {
            try
            {
                var result = await iempregadoRepository.GetEmpregado(id);
                if (result == null)
                    return NotFound($"Empregado com id = {id} não encontrado");

                iempregadoRepository.DeleteEmpregado(id);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados do banco de dados");
            }
        }

      
    }
}
