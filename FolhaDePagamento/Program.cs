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
            int opt = 0;
             
            Console.WriteLine("Olá, vamos ao que interessa. Dinheiro.");
            Console.WriteLine("Diga agora o que deseja fazer!");
            Console.WriteLine("Escolha abaixo as opções disponíveis: ");
            opt = '9';
            do
            {
                Console.WriteLine("1 -- Cadastrar funcionário");
                Console.WriteLine("2 -- Cadastrar folha de pagamento");
                Console.WriteLine("3 -- Listar Folhas de Pagamento");
                Console.WriteLine("0 -- SAIR");
            } while (opt != '0');
             switch(opt){
                 case 1: 
                     Console.Clear();
                     Console.WriteLine ("--** - Cadastrar Funcionários - **--");
                     break;
                 case 2:
                     Console.Clear();
                     Console.WriteLine("--** - Cadastrar Folha de Pagamento - **--");
                     break;
                 case 3: 
                     Console.Clear();
                     Console.WriteLine("--** - Listar Folhas de Pagamento - **--");
                     break;
                     case '0':
                         Console.Clear();

             }
        }
    }
}
