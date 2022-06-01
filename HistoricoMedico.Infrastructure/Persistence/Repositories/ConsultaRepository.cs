using HistoricoMedico.Core.Entities;
using HistoricoMedico.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Infrastructure.Persistence.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public ConsultaRepository(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Consulta>> ObterTodas()
        {
            return await _dbContext.Consultas.ToListAsync();
        }

        public async Task<Consulta> ObterUmaConsulta(int id)
        {
            return await _dbContext.Consultas
                .Include(c => c.Usuario)
                .Include(c => c.Medico)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task Criar(Consulta consulta)
        {            
            await _dbContext.Consultas.AddAsync(consulta);
            await _dbContext.SaveChangesAsync();

        }

        public async Task Deletar(Consulta consulta)
        {
            _dbContext.Consultas.Remove(consulta);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SalvarAlteracoes()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
