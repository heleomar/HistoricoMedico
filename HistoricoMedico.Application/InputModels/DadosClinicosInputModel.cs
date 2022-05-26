using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.InputModels
{
    public class DadosClinicosInputModel
    {
        public DadosClinicosInputModel(int id, int idUsuario, string tipoSanguineo, float altura, float peso, string doenca, string alergia, string medicacao)
        {
            IdUsuario = idUsuario;
            TipoSanguineo = tipoSanguineo;
            Altura = altura;
            Peso = peso;
            Doenca = doenca;
            Alergia = alergia;
            Medicacao = medicacao;
        }

        public int Id { get; private set; }
        public string TipoSanguineo { get; private set; }
        public float Altura { get; private set; }
        public float Peso { get; private set; }
        public string Doenca { get; private set; }
        public string Alergia { get; private set; }
        public string Medicacao { get; private set; }
        public Usuario Usuario { get; private set; }
        public int IdUsuario { get; private set; }


    }
}
