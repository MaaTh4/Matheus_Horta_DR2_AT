using System.Data;
using teste;
using teste.AlunosLista.Repositorio;
using teste.AlunosInformacoes.Model;

namespace AlunosInformacoes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositorio repositorio = new IRepositorio();

            while (true)
            {
                Console.WriteLine(" \n Escolha uma opção:");
                Console.WriteLine("1. Adicionar Aluno");
                Console.WriteLine("2. Pesquisar Aluno");
                Console.WriteLine("3. Remover Aluno");
                Console.WriteLine("4. Sair");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Opção inválida. Tente novamente. ");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Nome do Aluno: ");
                        string name = Console.ReadLine();
                        Console.Write("Data de Nascimento (dd/mm/yyyy): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birth))
                        {
                            Console.WriteLine("Data de Nascimento inválida. Tente novamente.");
                            continue;
                        }
                    
                        Console.Write("O Aluno está de recuperação? (Sim/Não): ");
                        bool EstaDeRec = Console.ReadLine().Trim().Equals("Sim", StringComparison.OrdinalIgnoreCase);
                        Console.Write("Média: ");
                        if (!double.TryParse(Console.ReadLine(), out double media))
                        {
                            Console.WriteLine("Média inválida. Tente novamente.");
                            continue;
                        }

                        Student student = new Student
                        {
                            Nome = name,
                            Aniversario = birth,
                            EstaDeRecuperacao = EstaDeRec,
                            Media = media
                        };

                        repositorio.AddStudent(student);
                        Console.WriteLine("Aluno adicionado!");
                        break;

                    case 2:
                        Console.Write("Digite o nome do aluno que deseja pesquisar: ");
                        string searchName = Console.ReadLine();
                        List<Student> searchResults = repositorio.SearchStudents(searchName);

                        if (searchResults.Count == 0)
                        {
                            Console.WriteLine("Nenhum aluno foi encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("Resultados da pesquisa:");
                            int index = 1;
                            foreach (var result in searchResults)
                            {
                                Console.WriteLine($"{index}. {result.Nome}");
                                index++;
                            }
                            //Detalhes dos alunos
                            Console.Write("Digite o número do aluno para ver detalhes: ");
                            if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= searchResults.Count)
                            {
                                Student selectedStudent = searchResults[selectedIndex - 1];
                                Console.WriteLine($"Nome: {selectedStudent.Nome}");
                                Console.WriteLine($"Data de Nascimento: {selectedStudent.Aniversario:dd/MM/yyyy}");
                                Console.WriteLine($"O aluno está de recuperação?: {(selectedStudent.EstaDeRecuperacao ? "Sim" : "Não")}");
                                Console.WriteLine($"Média: {selectedStudent.Media:F2}");
                                Console.WriteLine($"Idade: {selectedStudent.CalcularIdade()} anos");
                            }
                            else
                            {
                                Console.WriteLine("Número inválido. Tente novamente.");
                            }
                        }
                        break;

                    case 3:
                    
                        // Remover um aluno
                        List<Student> allStudents = repositorio.GettAllStudents();
                        Console.Write("Digite o nome do aluno a ser removido: ");
                        string NomeDoAlunoASerRemovido = Console.ReadLine();
                        repositorio.RemoveStudent(NomeDoAlunoASerRemovido);
                        Console.WriteLine($"{NomeDoAlunoASerRemovido} foi removido com sucesso.");
                        break;
                        

                    case 4:

                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
} 