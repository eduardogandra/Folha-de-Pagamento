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

        public static List<FolhaPagamento> BuscarFolhaPagamentoFuncionarioMesAno (Funcionario funcionario, FolhaPagamento folhasPagamentos)
        {
            List<FolhaPagamento> folhaPagamentoAux = new List<FolhaPagamento>();
            foreach (FolhaPagamento folhaPagamentoCadastrada in folhaPagamento)
            {
                if (folhaPagamentoCadastrada.Funcionario.Cpf.Equals(funcionario.Cpf))
                {
                    if(folhaPagamentoCadastrada.Mes.Equals(folhasPagamentos.Mes))
                    {
                        if(folhaPagamentoCadastrada.Ano.Equals(folhasPagamentos.Ano))
                        {
                            folhaPagamentoAux.Add(folhaPagamentoCadastrada);
                        }
                    }
                }
            }
            return folhaPagamentoAux;
        }

        public static List<FolhaPagamento> ListarFolhaPagamentoMesAno(FolhaPagamento folhasPagamentos)
        {
            List<FolhaPagamento> folhaPagamentoAux = new List<FolhaPagamento>();
            foreach (FolhaPagamento folhaPagamentoCadastrada in folhaPagamento)
            {
                if (folhaPagamentoCadastrada.Mes.Equals(folhasPagamentos.Mes))
                 {
                    if (folhaPagamentoCadastrada.Ano.Equals(folhasPagamentos.Ano))
                    {
                        folhaPagamentoAux.Add(folhaPagamentoCadastrada);
                    }
                }
            }
            return folhaPagamentoAux;
        }

        public static FolhaPagamento ValidarFolhaPagamentoMesAno (FolhaPagamento folhasPagamentos)
        {
            foreach (FolhaPagamento folhaPagamentoCadastrada in folhaPagamento)
            {
                if (folhaPagamentoCadastrada.Mes.Equals(folhasPagamentos.Mes))
                {
                    if (folhaPagamentoCadastrada.Ano.Equals(folhasPagamentos.Ano))
                    {
                        return folhaPagamentoCadastrada;
                    }
                }
            }
            return null;
        }

        public static bool ValidacaoSimplesMes (int mes)
        {
            if(mes >= 1 && mes <= 12 )
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool ValidacaoSimplesAno(int ano)
        {
            if (ano > 2000 && ano <= Convert.ToInt32(DateTime.Now.Year))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        
        public static List<FolhaPagamento> RetornarLista()
        {
            return folhaPagamento;
        }
    }
}
