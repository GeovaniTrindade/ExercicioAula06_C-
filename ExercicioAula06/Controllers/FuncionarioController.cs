using ExercicioAula06.Entities;
using ExercicioAula06.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAula06.Controllers
{
    public class FuncionarioController
    {
        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE FUNCIONARIO:\n");

                var funcionario = new Funcionario();
                funcionario.Id = Guid.NewGuid();
               
                Console.Write("\nENTRE COM O NOME DO FUNCIONARIO....: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("\nENTRE COM O CPF..............: ");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("\nENTRE COM A MATRICULA.........: ");
                funcionario.Matricula = Console.ReadLine();

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Add(funcionario);

                Console.WriteLine("\nFUNCIONARIO CADASTRADO COM SUCESSO!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO CADASTRAR FUNCIONARIO:");
                Console.WriteLine(e.Message);
            }
        }

        public void AtualizarFuncionario()
        {
            try
            {
                Console.WriteLine("\nEDIÇÃO DE FUNCIONARIO:\n");

                Console.Write("\nENTRE COM O ID DO FUNCIONARIO......: ");
                var id = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if (funcionario != null)
                {
                    Console.Write("\nENTRE COM O NOME DO FUNCIONARIO....: ");
                    funcionario.Nome = Console.ReadLine();

                    Console.Write("\nENTRE COM O CPF..............: ");
                    funcionario.Cpf = Console.ReadLine();

                    Console.Write("\nENTRE COM A MATRICULA.........: ");
                    funcionario.Matricula = Console.ReadLine();

                   funcionarioRepository.Update(funcionario);

                    Console.WriteLine("\nFUNCIONARIO ATUALIZADO COM SUCESSO.");
                }
                else
                {
                    Console.WriteLine("\nFUNCIONARIO NÃO ENCONTRADO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO ATUALIZAR FUNCIONARIO:");
                Console.WriteLine(e.Message);
            }
        }

        public void ExcluirFuncionario()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE FUNCIONARIO:\n");

                Console.Write("\nENTRE COM O ID DO FUNCIONARIO......: ");
                var id = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if (funcionario != null)
                {
                    funcionarioRepository.Delete(funcionario);

                    Console.WriteLine("\nFUNCIONARIO EXCLUIDO COM SUCESSO.");
                }
                else
                {
                    Console.WriteLine("\nFUNCIONARIO NÃO ENCONTRADO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO EXCLUIR FUNCIONARIO:");
                Console.WriteLine(e.Message);
            }
        }

        public void ConsultarFuncionarios()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE FUNCIONARIOS:\n");

                var funcionarioRepository = new FuncionarioRepository();
                var funcionarios = funcionarioRepository.GetAll();

                foreach (var item in funcionarios)
                {
                    Console.WriteLine("ID DO PRODUTO....: " + item.Id);
                    Console.WriteLine("NOME.............: " + item.Nome);
                    Console.WriteLine("CPF............: " + item.Cpf);
                    Console.WriteLine("MATRICULA.......: " + item.Matricula);
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO CONSULTAR FUNCIONARIOS:");
                Console.WriteLine(e.Message);
            }
        }

        public void ConsultarFuncionarioPorId()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE FUNCIONARIO POR ID:\n");

                Console.Write("\nENTRE COM O ID DO FUNCIONARIO......: ");
                var id = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if (funcionario != null)
                {

                    Console.WriteLine("ID DO PRODUTO....: " + funcionario.Id);
                    Console.WriteLine("NOME.............: " + funcionario.Nome);
                    Console.WriteLine("CPF............: " + funcionario.Cpf);
                    Console.WriteLine("MATRICULA.......: " + funcionario.Matricula);
                    Console.WriteLine("...");

                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFUNCIONARIO NÃO ENCONTRADO.");
                Console.WriteLine(e.Message);
            }
        }


    }
}
