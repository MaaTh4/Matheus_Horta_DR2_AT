using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste.AlunosInformacoes.Model;

namespace teste
{
    namespace AlunosLista.Repositorio
    {
        public class IRepositorio
        {
            private List<Student> students = new List<Student>();

            public void AddStudent(Student student)
            {
                student.Id = Guid.NewGuid();
                students.Add(student);
            }

            public List<Student> SearchStudents(string searchString)
            {
                List<Student> searchResults = new List<Student>();

                foreach (var student in students)
                {
                    if (student.Nome.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    {
                        searchResults.Add(student);
                    }
                }

                return searchResults;
            }
            //LISTA TODOS ALUNOS
            public List<Student> GettAllStudents()
            {
                return students;
            }


            //REMOVER ALUNO
            public void RemoveStudent(string studentName)
            {
                Student studentToRemove = students.FirstOrDefault(s => s.Nome.Equals(studentName, StringComparison.OrdinalIgnoreCase));

                if (studentToRemove != null)
                {
                    students.Remove(studentToRemove);
                }
            }
            internal void RemoveStudent(Student studentToRemove)
            {
                throw new NotImplementedException();
            }

            //EDITAR ALUNO
            public bool EditStudent(Guid studentId, string newNome, DateTime newAniversario, bool newEstaDeRecuperacao, double newMedia)
            {
                Student studentToEdit = students.FirstOrDefault(s => s.Id == studentId);

                if (studentToEdit != null)
                {
                    studentToEdit.Nome = newNome;
                    studentToEdit.Aniversario = newAniversario;
                    studentToEdit.EstaDeRecuperacao = newEstaDeRecuperacao;
                    studentToEdit.Media = newMedia;
                    return true; // Editado com sucesso
                }

                return false; // Aluno não encontrado
            }
        }
    }
}
