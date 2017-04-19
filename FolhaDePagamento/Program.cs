using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhaDePagamento.Model;
using FolhaDePagamento.DAL;
using FolhaDePagamento.Controller;

namespace FolhaDePagamento
{
    class Program
    {
        static void Main(string[] args)
        {

            Funcionario funcionario; 
            FolhaPagamento folhaPagamento;
            CalculoFolha calculoFolha;
            string opcao;
            double salarioBruto, Inss, Fgts, salarioLiquido, impostoRenda;

            do
            {
                Console.Clear();
                Console.WriteLine(" -- Sistema de Folha de Pagamento -- ");
                Console.WriteLine("\n1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Cadastrar Folha de pagamento");
                Console.WriteLine("3 - Consultar Folha de Pagamento");
                Console.WriteLine("4 - Listar Folhas de Pagamento");
                Console.WriteLine("5 - Listar Funcionários");
                Console.WriteLine("6 - Listar Folhas Cadastradas");
                Console.WriteLine("0 - SAIR");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        funcionario = new Funcionario();

                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Funcionário --");
                        Console.WriteLine("\nInforme o CPF do Funcionário: ");
                        funcionario.Cpf = Console.ReadLine();
                        
                        if (ValidaCPF.ValidarCpf(funcionario.Cpf) == true)
                        {
                            Console.WriteLine("\nCPF Válido!");
                            Console.WriteLine("\nInforme o Nome do Funcionário: ");
                            funcionario.Nome = Console.ReadLine();
                            if(FuncionarioDAO.SalvarFuncionario(funcionario) == true)
                            {
                                 Console.WriteLine("\nFuncionário Cadastrado com Sucesso!!!");
                            }
                            else
                            {
                                 Console.WriteLine("\nFuncionário NÃO Cadastrado!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nCPF INVÁLIDO!!!");
                        }
                        break;

                    case "2":
                        folhaPagamento = new FolhaPagamento();
                        funcionario = new Funcionario();

                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Folha de Pagamento --");
                        Console.WriteLine("\nInforme o CPF do Funcionário: ");
                        funcionario.Cpf = Console.ReadLine();
                        funcionario = FuncionarioDAO.BuscarFuncionarioCpf(funcionario);
                        if (funcionario != null)
                        {
                            folhaPagamento.Funcionario = funcionario;

                            Console.WriteLine("Informe o Mês da Folha: ");
                            folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                            
                            Console.WriteLine("Informe o Ano da Folha: ");
                            folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                                
                            Console.WriteLine("Informe Quantidade de Horas trabalhadas: ");
                            folhaPagamento.HorasTrabalhadas = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Informe o Valor da Hora Trabalhada: ");
                            folhaPagamento.ValorHora = Convert.ToDouble(Console.ReadLine());

                           FolhaPagamentoDAO.SalvarFolhaPagamento(folhaPagamento);
                           Console.WriteLine("\nInformações da Folha de Pagamento Salvas com Sucesso!!!...");     
                        }
                        else
                        {
                            Console.WriteLine("\nCPF Inválido! ");
                        }
                        break;

                    case "3":
                        funcionario = new Funcionario();
                        folhaPagamento = new FolhaPagamento();
                        calculoFolha = new CalculoFolha();

                        Console.Clear();
                        Console.WriteLine(" --  Consultar Folha de Pagamento --");
                        Console.WriteLine("\nInforme o CPF do Funcionário a consultar a Folha: ");
                        funcionario.Cpf = Console.ReadLine();
                        funcionario = FuncionarioDAO.BuscarFuncionarioCpf(funcionario);
                        if(funcionario != null)
                        {
                            Console.WriteLine("Informe o Mês da Folha de Pagamento: ");
                            folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                            folhaPagamento = FolhaPagamentoDAO.BuscarFolhaPagamentoMes(folhaPagamento);
                            if(folhaPagamento != null)
                            {
                                Console.WriteLine("Informe o Ano da Folha de Pagamento: ");
                                folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                                folhaPagamento = FolhaPagamentoDAO.BuscarFolhaPagamentoAno(folhaPagamento);
                                if(folhaPagamento != null)
                                {
                                    foreach(FolhaPagamento folhaPagamentoCadastrada in FolhaPagamentoDAO.BuscarFolhaPagamentoFuncionarioCpf(funcionario))
                                    {
                                        Console.WriteLine("\nFuncionário: " + folhaPagamentoCadastrada.Funcionario.Nome);
                                        Console.WriteLine("CPF: " + folhaPagamentoCadastrada.Funcionario.Cpf);
                                        Console.WriteLine("Mês / Ano : " + folhaPagamentoCadastrada.Mes + "/ " + folhaPagamentoCadastrada.Ano);
                                        Console.WriteLine("Horas Trabalhadas: " + folhaPagamentoCadastrada.HorasTrabalhadas);
                                        Console.WriteLine("\tValor da Hora: " + folhaPagamentoCadastrada.ValorHora.ToString("C2"));
                                        salarioBruto = calculoFolha.CalculoFolhaPagamentoSalarioBruto(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                                        Console.WriteLine("\tSalário Bruto: " + salarioBruto.ToString("C2"));
                                        impostoRenda = calculoFolha.CalculoFolhaPagamentoIR(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                                        Console.WriteLine("\tImposto de Renda: " + impostoRenda.ToString("C2"));
                                        Inss = calculoFolha.CalculoFolhaPagamentoInss(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                                        Console.WriteLine("\tINSS: " + Inss.ToString("C2"));
                                        Fgts = calculoFolha.CalculoFolhaPagamentoFgts(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                                        Console.WriteLine("\tFGTS: " + Fgts.ToString("C2"));
                                        salarioLiquido = salarioBruto - impostoRenda - Inss;
                                        Console.WriteLine("\tSalário Líquido: " + salarioLiquido.ToString("C2"));

                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("\nAno Inválido!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nMês Inválido!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nCPF Inválido!");
                        }
                        break;

                    case "4":
                        funcionario = new Funcionario();
                        folhaPagamento = new FolhaPagamento();

                        Console.Clear();
                        Console.WriteLine("--  Listar Folhas de Pagamento --");
                        break;

                    case "5":
                        funcionario = new Funcionario();

                        Console.Clear();
                        Console.WriteLine("--  Listar Funcionários --");
                        foreach (Funcionario funcionarioCadastrado in FuncionarioDAO.RetornarLista())
                        {
                            Console.WriteLine("\nFuncionário: " + funcionarioCadastrado.Nome);
                            Console.WriteLine("CPF: " + funcionarioCadastrado.Cpf);
                        }
                        Console.ReadKey();

                        break;

                    case "6":
                        folhaPagamento = new FolhaPagamento();
                        funcionario = new Funcionario();

                        Console.Clear();
                        Console.WriteLine("--  Listar Folha Cadastrada --");
                        foreach (FolhaPagamento folhaPagamentoCadastrada in FolhaPagamentoDAO.RetornarLista())
                        {
                            Console.WriteLine("\nFuncionário: " + folhaPagamentoCadastrada.Funcionario.Nome);
                            Console.WriteLine("CPF: " + folhaPagamentoCadastrada.Funcionario.Cpf);
                            Console.WriteLine("Mês: " + folhaPagamentoCadastrada.Mes);
                            Console.WriteLine("Ano: " + folhaPagamentoCadastrada.Ano);
                            Console.WriteLine("Horas Trabalhadas: " + folhaPagamentoCadastrada.HorasTrabalhadas);
                            Console.WriteLine("Valor da Hora: " + folhaPagamentoCadastrada.ValorHora.ToString("C2"));
                        }
                        Console.ReadKey();

                        break;

                    case "0":
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nOpção Inválida!");
                        break;
                }

                Console.WriteLine("\nAperte uma tecla para continuar...");
                Console.ReadKey();

            } while (!opcao.Equals("0"));

        }
    }
}
