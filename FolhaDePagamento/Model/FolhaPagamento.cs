using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhaDePagamento.DAL;
using FolhaDePagamento.Controller;

namespace FolhaDePagamento.Model
{
    class FolhaPagamento
    {
        public Funcionario Funcionario  { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int HorasTrabalhadas { get; set; }
        public double ValorHora { get; set; }

        public FolhaPagamento()
        {
            Funcionario = new Funcionario();
        }
    }
}
