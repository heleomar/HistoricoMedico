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
    public class MedicoService : IMedicoService
    {
        private readonly HistoricoMedicoDbContext _dbContext;

        public MedicoService(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarMedico(AtualizarMedicoInputModel InputModel)
        {
            var medico = _dbContext.Medicos.SingleOrDefault(m => m.Id == InputModel.Id);

            medico.Atualizar(InputModel.Especialidade, InputModel.Telefone, InputModel.Celular);

            _dbContext.SaveChanges();
        }

        public MedicoUnicoViewModel BuscarMedicoEspecifico(int id)
        {
            var medico = _dbContext.Medicos
                .Include(m => m.Usuario)
                .SingleOrDefault(m => m.Id == id);

            if (medico == null) return null; //só para evitar excessão Camada API - Parte 2 / 05:15

            var medicoUnicoViewModel = new MedicoUnicoViewModel(
                medico.Id,            
                medico.Nome, 
                medico.IdUsuario, 
                medico.Especialidade, 
                medico.Telefone, 
                medico.Celular, 
                medico.Endereco,
                medico.Usuario.Nome
                );

            return medicoUnicoViewModel;

        }

        public List<MedicoViewModel> BuscarTodosMedicos()
        {
            var medicos = _dbContext.Medicos;
            var medicosViewModel = medicos
                .Select(m => new MedicoViewModel(m.Id, m.Nome, m.Especialidade))
                .ToList();

            return medicosViewModel;
        }

        public int CriarNovoMedico(NovoMedicoInputModel inputModel)
        {
            var medico = new Medico(inputModel.Nome, inputModel.IdUsuario, inputModel.Especialidade, inputModel.Celular);
            
            _dbContext.Medicos.Add(medico);

            _dbContext.SaveChanges();

            return medico.Id;
        }

        public void DeletarMedico(int id)
        {
            var medico = _dbContext.Medicos.SingleOrDefault(m => m.Id == id);

            _dbContext.Medicos.Remove(medico);

            _dbContext.SaveChanges();
        }
    }
}
