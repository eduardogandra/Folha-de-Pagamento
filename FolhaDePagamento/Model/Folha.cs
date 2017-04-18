using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento.Model
{
    class Folha
    {
        private int Folha { get; set; }
        private double Salario { get; set; }
        private double Inss { get; set;
        private double ImpostoDeRenda{ get;set;}
        private double Fgts {get; set;}

        Folha Folha = new Folha();
        Salario salario = new Salario();
        Inss inss = new Inss();
        ImpostoDeRenda imposto = new ImpostoDeRenda();
        Fgts fgts = new Fgts();
    }
}
