using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhaDePagamento.Model;
using FolhaDePagamento.DAL;
using FolhaDePagamento.Controller;

namespace FolhaDePagamento.DAL
{
    class Dados
    {
        public static void Inicializar()
        {
            List<Funcionario> funcionario = new List<Funcionario>
        {
            new Funcionario()
            {
                Nome = "Diogo",
                Cpf = "11144477735"
            },
            new Funcionario()
            {
                Nome = "José",
                Cpf = "794.382.121-16"
            },
            new Funcionario()
            {
                Nome = "Maria",
                Cpf = "666.747.793-00"
            },
            new Funcionario()
            {
                Nome = "Joana",
                Cpf = "888.684.357-72"
            },
            new Funcionario()
            {
                Nome = "Marcos",
                Cpf = "007.180.863-92"
            },
        };
            List<FolhaPagamento> folhaPagamento = new List<FolhaPagamento>
        {
            new FolhaPagamento()
            {
                Mes = 05,
                Ano = 2016,
                HorasTrabalhadas = 160,
                ValorHora = 14.68
            },
            new FolhaPagamento()
            {
                Mes = 08,
                Ano = 2016,
                HorasTrabalhadas = 150,
                ValorHora = 18.32
            },
            new FolhaPagamento()
            {
                Mes = 09,
                Ano = 2016,
                HorasTrabalhadas = 170,
                ValorHora = 10.14
            },
            new FolhaPagamento()
            {
                Mes = 07,
                Ano = 2016,
                HorasTrabalhadas = 155,
                ValorHora = 23.75
            },
            new FolhaPagamento()
            {
                Mes = 06,
                Ano = 2016,
                HorasTrabalhadas = 160,
                ValorHora = 9.80
            },
        };

            funcionario.ForEach(x => FuncionarioDAO.SalvarFuncionario(x));
            folhaPagamento.ForEach(x => FolhaPagamentoDAO.SalvarFolhaPagamento(x));

        }
    }
}
