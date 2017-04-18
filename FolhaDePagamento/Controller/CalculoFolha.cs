using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhaDePagamento.DAL;
using FolhaDePagamento.Model;

namespace FolhaDePagamento.Controller
{
    class CalculoFolha
    {
        public double salarioBruto, salarioLiquido, Inss, Fgts, impostoRenda;

        public double CalculoFolhaPagamento (int horas, double valorHoras)
        {
            salarioBruto = horas * valorHoras;

            return salarioBruto;
        }
       
    }
}
