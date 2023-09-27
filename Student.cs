using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste
{
    namespace AlunosInformacoes.Model
    {
        public class Student
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public DateTime Aniversario { get; set; }
            public int Idade { get; set; }
            public bool EstaDeRecuperacao { get; set; }
            public double Media { get; set; }

            public int CalcularIdade()
            {
                DateTime dataAgora = DateTime.Now;
                int idade = dataAgora.Year - Aniversario.Year;

                if (Aniversario.Date > dataAgora.AddYears(-idade))
                {
                    idade--;
                }

                return idade;
            }
        }
    }
}
