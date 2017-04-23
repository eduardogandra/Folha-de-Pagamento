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

        private double salarioBruto = 0, Inss = 0, Fgts = 0, impostoRenda = 0, aliquota = 0;

        public double CalculoFolhaPagamentoSalarioBruto (int horas, double valorHoras)
        {
            salarioBruto = 0;

            salarioBruto = horas * valorHoras;
            return salarioBruto;
        }

        public double CalculoFolhaPagamentoIR (int horas, double valorHoras)
        {
            salarioBruto = 0;
            impostoRenda = 0;
            aliquota = 0;

            salarioBruto = horas * valorHoras;

            if(salarioBruto <= 1903.98)
            {
                impostoRenda = 0;
                aliquota = 0;
            }
            if(salarioBruto >= 1903.99 && salarioBruto <= 2826.65)
            {
                aliquota = (salarioBruto * 7.5) / 100;
                impostoRenda = aliquota - 142.80;
            }
            if(salarioBruto >= 2826.66 && salarioBruto <= 3751.05)
            {
                aliquota = (salarioBruto * 15) / 100;
                impostoRenda = aliquota - 354.80;
            }
            if(salarioBruto >= 3751.06 && salarioBruto <= 4664.68)
            {
                aliquota = (salarioBruto * 22.5) / 100;
                impostoRenda = aliquota - 636.13;
            }
            if(salarioBruto >= 4664.69)
            {
                aliquota = (salarioBruto * 27.5) / 100;
                impostoRenda = aliquota - 869.36;
            }

            return impostoRenda;
        }

        public double CalculoFolhaPagamentoInss(int horas, double valorHoras)
        {
            salarioBruto = 0;
            Inss = 0;

            salarioBruto = horas * valorHoras;

            if(salarioBruto <= 1659.38)
            {
                Inss = (salarioBruto * 8) / 100;
            }
            if(salarioBruto >= 1659.39 && salarioBruto <= 2765.66)
            {
                Inss = (salarioBruto * 9) / 100;
            }
            if(salarioBruto >= 2765.67 && salarioBruto <= 5531.31)
            {
                Inss = (salarioBruto * 11) / 100;
            }
            if(salarioBruto > 5531.31)
            {
                Inss = 608.44;
            }

            return Inss;
        }

        public double CalculoFolhaPagamentoFgts(int horas, double valorHoras)
        {
            salarioBruto = 0;
            Fgts = 0;

            salarioBruto = horas * valorHoras;

            Fgts = (salarioBruto * 8) / 100;

            return Fgts;
        }

    }
}
