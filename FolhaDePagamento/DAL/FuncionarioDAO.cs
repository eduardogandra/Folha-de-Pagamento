using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhaDePagamento.Model;

namespace FolhaDePagamento.DAL
{  
    class FuncionarioDAO
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();

        public static bool SalvarFuncionario(Funcionario funcionario)
        {
            if (BuscarFuncionarioCpf(funcionario) != null)
            {
                return false;
            }
            funcionarios.Add(funcionario);
            return true;
        }

        public static Funcionario BuscarFuncionarioCpf(Funcionario funcionario)
        {
            foreach (Funcionario funcionarioCadastrado in funcionarios)
            {
                if (funcionario.Cpf.Equals(funcionarioCadastrado.Cpf))
                {
                    return funcionarioCadastrado;
                }
            }
            return null;
        }

        public static List<Funcionario> RetornarLista()
        {
            return funcionarios;
        }
    }
}
