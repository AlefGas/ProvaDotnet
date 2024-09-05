using Empresa.Data;
using Empresa.Models;
using Empresa.Reapository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Reapository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly dbContext dbContext;

        public DepartamentoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Departamento> AddDepartamentoAsync(Departamento departamento)
        {
            var result = await dbContext.departamentos.AddAsync(departamento);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteDepartamentoAsync(int id)
        {
            var result = await dbContext.departamentos.FirstOrDefaultAsync(d => d.DepId == id);
            if (result != null)
            {
                dbContext.departamentos.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Departamento> GetDepartamentoAsync(int id)
        {
            return await dbContext.departamentos.FirstOrDefaultAsync(d => d.DepId == id);
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentosAsync()
        {
            return await dbContext.departamentos.ToListAsync();
        }

        public async Task<Departamento> UpdateDepartamentoAsync(Departamento departamento)
        {
            var result = await dbContext.departamentos.FirstOrDefaultAsync(d => d.DepId == departamento.DepId);
            if (result != null)
            {
                result.DepNome = departamento.DepNome;

                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
