using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhaDePagamento.Model;
namespace FolhaDePagamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionario funcionario = new Funcionario();
            Folha folha = new Folha();
            string opcao;
            
            do
            {
                Console.Clear();
                Console.WriteLine(" -- Sistema de Folha de Pagamento -- ");
                Console.WriteLine("\n1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Cadastrar Folha de pagamento");
                Console.WriteLine("3 - Listar Folhas de Pagamento");
                Console.WriteLine("0 - SAIR");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--** - Cadastrar Funcionários - **--");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("--** - Cadastrar Folha de Pagamento - **--");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("--** - Listar Folhas de Pagamento - **--");
                        break;
                    case "0":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
                Console.WriteLine("Aperte uma tecla para continuar...");
                Console.ReadKey();
            } while (!opcao.Equals ("0"));  
             
        }
    }
}
