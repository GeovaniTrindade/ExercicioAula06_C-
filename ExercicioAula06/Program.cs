using ExercicioAula06.Controllers;

namespace ExercicioAula06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nCADASTRO DE FUNCIONARIO:\n");

            Console.WriteLine("(1) CADASTRAR FUNCIONARIO");
            Console.WriteLine("(2) ATUALIZAR FUNCIONARIO");
            Console.WriteLine("(3) EXCLUIR FUNCIONARIO");
            Console.WriteLine("(4) CONSULTAR FUNCIONARIO");
            Console.WriteLine("(5) CONSULTAR UM FUNCIONARIO");

            Console.Write("\nINFORME A OPÇÃO DESEJADA...: ");
            var opcao = int.Parse(Console.ReadLine());

            var funcionarioController = new FuncionarioController();

            switch (opcao)
            {
                case 1:
                    funcionarioController.CadastrarFuncionario();
                    break;  

                case 2:
                    funcionarioController.AtualizarFuncionario();
                    break;

                case 3:
                    funcionarioController.ExcluirFuncionario();
                    break;

                case 4:
                    funcionarioController.ConsultarFuncionarios();
                    break;

                case 5:
                    funcionarioController.ConsultarFuncionarioPorId();
                    break;

                default:
                    Console.WriteLine("\nOPÇÃO INVÁLIDA.");
                    break;
            }

            Console.Write("\nDESEJA CONTINUAR? (S,N): ");
            var escolha = Console.ReadLine();

            if (escolha == "S" || escolha == "s")
            {
                Console.Clear(); //limpar o console do DOS
                Main(args); //recursividade
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }
    }
}
