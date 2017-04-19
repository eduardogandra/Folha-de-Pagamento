using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhaDePagamento.Controller;
using FolhaDePagamento.Model;

namespace FolhaDePagamento.DAL
{
    class FolhaPagamentoDAO
    {
        private static List<FolhaPagamento> folhaPagamento = new List<FolhaPagamento>();

        public static void SalvarFolhaPagamento(FolhaPagamento folhasPagamentos)
        {
            folhaPagamento.Add(folhasPagamentos);
        }


        public static List<FolhaPagamento> BuscarFolhaPagamentoFuncionarioCpf(Funcionario funcionario)
        {
            List<FolhaPagamento> folhaPagamentoAux = new List<FolhaPagamento>();
            foreach (FolhaPagamento folhaPagamentoCadastrada in folhaPagamento)
            {
                if (folhaPagamentoCadastrada.Funcionario.Cpf.Equals(funcionario.Cpf))
                {
                    
                    folhaPagamentoAux.Add(folhaPagamentoCadastrada);
                }
            }
            return folhaPagamentoAux;
        }

        public static FolhaPagamento BuscarFolhaPagamentoMes(FolhaPagamento folhasPagamentos)
        {
            foreach (FolhaPagamento folhaPagamentoCadastrada in folhaPagamento)
            {
                if (folhasPagamentos.Mes.Equals(folhaPagamentoCadastrada.Mes))
                {
                    return folhaPagamentoCadastrada;
                }
            }
            return null;
        }

        public static FolhaPagamento BuscarFolhaPagamentoAno(FolhaPagamento folhasPagamentos)
        {
            foreach (FolhaPagamento folhaPagamentoCadastrada in folhaPagamento)
            {
                if (folhasPagamentos.Ano.Equals(folhaPagamentoCadastrada.Ano))
                {
                    return folhaPagamentoCadastrada;
                }
            }
            return null;
        }
    }
}
