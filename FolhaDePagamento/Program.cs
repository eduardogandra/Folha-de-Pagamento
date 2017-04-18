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
            string opcao;

            do
            {
                Console.Clear();
                Console.WriteLine(" -- Sistema de Folha de Pagamento -- ");
                Console.WriteLine("\n1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Cadastrar Folha de pagamento");
                Console.WriteLine("3 - Consultar Folha de Pagamento");
                Console.WriteLine("4 - Listar Folhas de Pagamento");
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
                            funcionario = FuncionarioDAO.BuscarFuncionarioCpf(funcionario);
                            if(funcionario!=null)
                            {
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
                                Console.WriteLine("\nCPF Pertence a outro Funcionário!!!");
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
                            //validar se o mês e ano já pertencem a este CPF atual
                            //será que são dois if, um para ano e um para mês?
                            //se não pertencer continuar a cadartrar a folha, seguindo com o cadastro


                            Console.WriteLine("Informe Quantidade de Horas trabalhadas: ");
                            folhaPagamento.HorasTrabalhadas = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Informe o Valor da Hora Trabalhada: ");
                            folhaPagamento.ValorHora = Convert.ToDouble(Console.ReadLine());

                            FolhaPagamentoDAO.SalvarFolhaPagamento(folhaPagamento);
                        }
                        else
                        {
                            Console.WriteLine("\nCPF Inválido! ");
                        }
                        break;

                    case "3":
                        funcionario = new Funcionario();
                        folhaPagamento = new FolhaPagamento();

                        Console.Clear();
                        Console.WriteLine(" --  Consultar Folha de Pagamento --");
                        break;

                    case "4":
                        funcionario = new Funcionario();
                        folhaPagamento = new FolhaPagamento();

                        Console.Clear();
                        Console.WriteLine("--  Listar Folhas de Pagamento --");
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
