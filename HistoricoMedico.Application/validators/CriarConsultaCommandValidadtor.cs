using FluentValidation;
using HistoricoMedico.Application.Commands.CriarConsulta;
using System;

namespace HistoricoMedico.Application.validators
{
    public class CriarConsultaCommandValidadtor : AbstractValidator<CriarConsultaCommand>
    {
        public CriarConsultaCommandValidadtor()
        {
            RuleFor(p => p.Sintomas)
                .MaximumLength(100)
                .WithMessage("Tamanho máximo é de 100 caracteres.");

            RuleFor(p => p.DataConsulta)
                .LessThan(DateTime.Now)
                .WithMessage("Data de cadastro nao pode ser menor que a data atual");
        }
        
    }

}

