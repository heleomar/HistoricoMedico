using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.Services.Interfaces;
using HistoricoMedico.Application.ViewsModels;
using HistoricoMedico.Core.Entities;
using HistoricoMedico.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Services.Implementations
{
    public class ConsultaService : IConsultaService
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public ConsultaService(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CriarNovaConsulta(NovaConsultaInputModel inputModel)
        {
            var consulta = new Consulta(inputModel.IdUsuario, inputModel.IdMedico, inputModel.Sintomas, inputModel.DataConsulta);
            
            _dbContext.Consultas.Add(consulta);

            _dbContext.SaveChanges();

            return consulta.Id;
        }

        public void DeletarConsulta(int id)
        {
            var consulta = _dbContext.Consultas.SingleOrDefault(p => p.Id == id);

            _dbContext.Consultas.Remove(consulta);

            _dbContext.SaveChanges();
        }

        public List<ConsultaViewModel> BuscarTodasConsultas()
        {
            var consultas = _dbContext.Consultas;
            var consultasViewModel = consultas
                .Select(c => new ConsultaViewModel(c.Id, c.DataConsulta))
                .ToList();

            return consultasViewModel;

        }

        public ConsultaUnicaViewModel BuscarConsultaEspecifica(int id)
        {
            var consulta = _dbContext.Consultas
                .Include(c => c.Usuario)
                .Include(c => c.Medico)
                .SingleOrDefault(c => c.Id == id); ;

            var ConsultaUnicaViewModel = new ConsultaUnicaViewModel(
                    consulta.Id,
                    consulta.IdUsuario,
                    consulta.IdMedico,
                    consulta.Sintomas,
                    consulta.PrescricaoMedica,
                    consulta.Observacoes,
                    consulta.Conclusoes,
                    consulta.DataConsulta,
                    consulta.Usuario.Nome,
                    consulta.Medico.Nome
                    );
                

            return ConsultaUnicaViewModel;
        }

        public void AtulizarConsulta(AtualizarConsultaInputModel InputModel)
        {
            var consulta = _dbContext.Consultas.SingleOrDefault(c => c.Id == InputModel.Id);

            consulta.Atualizar(InputModel.Sintomas, InputModel.PrescricaoMedica, InputModel.Observacoes, InputModel.Conclusoes, InputModel.DataConsulta);

            _dbContext.SaveChanges();
        }
    }
}
