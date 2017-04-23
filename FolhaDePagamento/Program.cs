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
            string opcao, Cpf;
            double salarioBruto, Inss, Fgts, salarioLiquido, impostoRenda, totalSalarioLiquido = 0, totalSalarioBruto = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("         -- Sistema de Folha de Pagamento -- ");
                Console.WriteLine("\n            1 - Cadastrar Funcionário");
                Console.WriteLine("            2 - Cadastrar Folha de pagamento");
                Console.WriteLine("            3 - Consultar Folha de Pagamento");
                Console.WriteLine("            4 - Listar Folhas de Pagamento");
                Console.WriteLine("            5 - Listar Funcionários");
                Console.WriteLine("            6 - Listar Folhas Cadastradas");
                Console.WriteLine("            0 - SAIR");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        funcionario = new Funcionario();

                        Console.Clear();
                        Console.WriteLine("         -- Cadastrar Funcionário --");
                        Console.WriteLine("\n            Informe o CPF do Funcionário: ");
                        Cpf = Console.ReadLine();
                        Cpf = Cpf.Trim();
                        Cpf = Cpf.Replace(".", "").Replace("-", "");
                        funcionario.Cpf = Cpf;

                        if (ValidaCPF.ValidarCpf(funcionario.Cpf) == true)
                        {
                            Console.WriteLine("\n            CPF Válido...");
                            Console.WriteLine("\n            Informe o Nome do Funcionário: ");
                            funcionario.Nome = Console.ReadLine();
                            if(FuncionarioDAO.SalvarFuncionario(funcionario) == true)
                            {
                                 Console.WriteLine("\n            Funcionário Cadastrado com Sucesso!!!");
                            }
                            else
                            {
                                 Console.WriteLine("\n            Funcionário NÃO Cadastrado!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n            CPF INVÁLIDO!!!");
                        }
                        break;

                    case "2":
                        folhaPagamento = new FolhaPagamento();
                        funcionario = new Funcionario();

                        Console.Clear();
                        Console.WriteLine("         -- Cadastrar Folha de Pagamento --");
                        Console.WriteLine("\n            Informe o CPF do Funcionário: ");
                        Cpf = Console.ReadLine();
                        Cpf = Cpf.Trim();
                        Cpf = Cpf.Replace(".", "").Replace("-", "");
                        funcionario.Cpf = Cpf;

                        funcionario = FuncionarioDAO.BuscarFuncionarioCpf(funcionario);
                        if (funcionario != null)
                        {
                            folhaPagamento.Funcionario = funcionario;

                            Console.WriteLine("            Informe o Mês da Folha: ");
                            folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                            if (FolhaPagamentoDAO.ValidacaoSimplesMes(folhaPagamento.Mes) == true)
                            {
                                Console.WriteLine("            Informe o Ano da Folha: ");
                                folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                                if (FolhaPagamentoDAO.ValidacaoSimplesAno(folhaPagamento.Ano) == true)
                                {
                                    if (FolhaPagamentoDAO.BuscarFolhaPagamentoFuncionarioMesAno(funcionario,folhaPagamento) != null)
                                    {
                                        Console.WriteLine("            Informe Quantidade de Horas trabalhadas: ");
                                        folhaPagamento.HorasTrabalhadas = Convert.ToInt32(Console.ReadLine());

                                        Console.WriteLine("            Informe o Valor da Hora Trabalhada: ");
                                        folhaPagamento.ValorHora = Convert.ToDouble(Console.ReadLine());

                                        FolhaPagamentoDAO.SalvarFolhaPagamento(folhaPagamento);
                                        Console.WriteLine("\n              Informações da Folha de Pagamento Salvas com Sucesso!!!...");

                                    }
                                    else
                                    {
                                        Console.WriteLine("\n              Cadastro Não Realizado!!!...");
                                    }
                               }
                               else
                               {
                                   Console.WriteLine("\n              Ano Inválido!!!");
                               }
                           }
                           else
                           {
                               Console.WriteLine("\n              Mês Inválido!!!");
                           }
                       }
                       else
                       {
                          Console.WriteLine("\n              CPF Inválido! ");
                       }
                      break;

                    case "3":
                        funcionario = new Funcionario();
                        folhaPagamento = new FolhaPagamento();
                        calculoFolha = new CalculoFolha();

                        Console.Clear();
                        Console.WriteLine("         --  Consultar Folha de Pagamento --");
                        Console.WriteLine("\n              Informe o CPF do Funcionário a consultar a Folha: ");
                        Cpf = Console.ReadLine();
                        Cpf = Cpf.Trim();
                        Cpf = Cpf.Replace(".", "").Replace("-", "");
                        funcionario.Cpf = Cpf;
                    
                        funcionario = FuncionarioDAO.BuscarFuncionarioCpf(funcionario);
                        if (funcionario != null)
                        {
                            Console.WriteLine("            Informe o Mês da Folha de Pagamento: ");
                            folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                            
                            Console.WriteLine("            Informe o Ano da Folha de Pagamento: ");
                            folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                            
                            if (FolhaPagamentoDAO.BuscarFolhaPagamentoFuncionarioMesAno(funcionario, folhaPagamento) != null)
                            {
                                foreach (FolhaPagamento folhaPagamentoCadastrada in FolhaPagamentoDAO.BuscarFolhaPagamentoFuncionarioMesAno(funcionario, folhaPagamento))
                                {
                                    Console.WriteLine("\n            Funcionário: " + folhaPagamentoCadastrada.Funcionario.Nome);
                                    Console.WriteLine("            CPF: " + folhaPagamentoCadastrada.Funcionario.Cpf);
                                    Console.WriteLine("            Mês / Ano : " + folhaPagamentoCadastrada.Mes + "/ " + folhaPagamentoCadastrada.Ano);
                                    Console.WriteLine("            Horas Trabalhadas: " + folhaPagamentoCadastrada.HorasTrabalhadas);
                                    Console.WriteLine("\t            Valor da Hora: " + folhaPagamentoCadastrada.ValorHora.ToString("C2"));
                                    salarioBruto = calculoFolha.CalculoFolhaPagamentoSalarioBruto(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                                    Console.WriteLine("\t            Salário Bruto: " + salarioBruto.ToString("C2"));
                                    impostoRenda = calculoFolha.CalculoFolhaPagamentoIR(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                                    Console.WriteLine("\t            Imposto de Renda: " + impostoRenda.ToString("C2"));
                                    Inss = calculoFolha.CalculoFolhaPagamentoInss(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                                    Console.WriteLine("\t            INSS: " + Inss.ToString("C2"));
                                    Fgts = calculoFolha.CalculoFolhaPagamentoFgts(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                                    Console.WriteLine("\t            FGTS: " + Fgts.ToString("C2"));
                                    salarioLiquido = salarioBruto - impostoRenda - Inss;
                                    Console.WriteLine("\t            Salário Líquido: " + salarioLiquido.ToString("C2"));
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n            Mês ou Ano informado Não Encontrados!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n            CPF Inválido!");
                        }
                      break;

                    case "4":
                        funcionario = new Funcionario();
                        folhaPagamento = new FolhaPagamento();
                        calculoFolha = new CalculoFolha();

                        Console.Clear();
                        Console.WriteLine("            --  Listar Folhas de Pagamento --");
                        Console.WriteLine("\n            Informe o Mês que deseja Consultar: ");
                        folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("            Informe o Ano que deseja Consultar: ");
                        folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());

                        totalSalarioLiquido = 0;
                        totalSalarioBruto = 0;
                        foreach (FolhaPagamento folhaPagamentoCadastrada in FolhaPagamentoDAO.ListarFolhaPagamentoMesAno(folhaPagamento))
                        {
                            Console.WriteLine("\n            Funcionário: " + folhaPagamentoCadastrada.Funcionario.Nome);
                            Console.WriteLine("            CPF: " + folhaPagamentoCadastrada.Funcionario.Cpf);
                            Console.WriteLine("            Mês / Ano : " + folhaPagamentoCadastrada.Mes + "/ " + folhaPagamentoCadastrada.Ano);
                            Console.WriteLine("            Horas Trabalhadas: " + folhaPagamentoCadastrada.HorasTrabalhadas);
                            Console.WriteLine("\t            Valor da Hora: " + folhaPagamentoCadastrada.ValorHora.ToString("C2"));
                            salarioBruto = calculoFolha.CalculoFolhaPagamentoSalarioBruto(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                            Console.WriteLine("\t            Salário Bruto: " + salarioBruto.ToString("C2"));
                            impostoRenda = calculoFolha.CalculoFolhaPagamentoIR(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                            Console.WriteLine("\t            Imposto de Renda: " + impostoRenda.ToString("C2"));
                            Inss = calculoFolha.CalculoFolhaPagamentoInss(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                            Console.WriteLine("\t            INSS: " + Inss.ToString("C2"));
                            Fgts = calculoFolha.CalculoFolhaPagamentoFgts(folhaPagamentoCadastrada.HorasTrabalhadas, folhaPagamentoCadastrada.ValorHora);
                            Console.WriteLine("\t            FGTS: " + Fgts.ToString("C2"));
                            salarioLiquido = salarioBruto - impostoRenda - Inss;
                            Console.WriteLine("\t            Salário Líquido: " + salarioLiquido.ToString("C2"));

                            totalSalarioLiquido += salarioLiquido;
                            totalSalarioBruto += salarioBruto;
                        }
                        Console.WriteLine("\n\t            Total Salário Bruto: " + totalSalarioBruto.ToString("C2"));
                        Console.WriteLine("\t            Total Salário Líquido: " + totalSalarioLiquido.ToString("C2"));

                        break;

                    case "5":
                        funcionario = new Funcionario();

                        Console.Clear();
                        Console.WriteLine("         --  Listar Funcionários --");
                        foreach (Funcionario funcionarioCadastrado in FuncionarioDAO.RetornarLista())
                        {
                            Console.WriteLine("\n            Funcionário: " + funcionarioCadastrado.Nome);
                            Console.WriteLine("            CPF: " + funcionarioCadastrado.Cpf);
                        }
                        Console.ReadKey();

                        break;

                    case "6":
                        folhaPagamento = new FolhaPagamento();
                        funcionario = new Funcionario();

                        Console.Clear();
                        Console.WriteLine("         --  Listar Folha Cadastrada --");
                        foreach (FolhaPagamento folhaPagamentoCadastrada in FolhaPagamentoDAO.RetornarLista())
                        {
                            Console.WriteLine("\n            Funcionário: " + folhaPagamentoCadastrada.Funcionario.Nome);
                            Console.WriteLine("            CPF: " + folhaPagamentoCadastrada.Funcionario.Cpf);
                            Console.WriteLine("            Mês: " + folhaPagamentoCadastrada.Mes);
                            Console.WriteLine("            Ano: " + folhaPagamentoCadastrada.Ano);
                            Console.WriteLine("            Horas Trabalhadas: " + folhaPagamentoCadastrada.HorasTrabalhadas);
                            Console.WriteLine("            Valor da Hora: " + folhaPagamentoCadastrada.ValorHora.ToString("C2"));
                        }
                        Console.ReadKey();

                        break;

                    case "0":
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\n            Opção Inválida!");
                        break;
                }

                Console.WriteLine("\n            Aperte uma tecla para continuar...");
                Console.ReadKey();

            } while (!opcao.Equals("0"));

        }
    }
}
