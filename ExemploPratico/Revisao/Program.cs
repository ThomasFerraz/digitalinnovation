using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        {
                            Console.WriteLine("Informe o nome do aluno:");
                            var aluno = new Aluno();
                            aluno.Nome = Console.ReadLine();

                            Console.WriteLine("Informe a nota:");

                            if (decimal.TryParse(Console.ReadLine(),out decimal nota))
                            {
                                aluno.Nota = nota;
                            }
                            else
                            {
                                throw new ArgumentException("O valor deve ser Decimal");
                            }

                            alunos[indiceAluno] = aluno;
                            indiceAluno++;
                            //TODO: adicionar aluno 
                            break;
                        }
                    case "2":
                        {
                            foreach(var a in alunos)
                            {
                                if (!string.IsNullOrEmpty(a.Nome))
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota} ");
                            }
                            //TODO: listar alunos
                            break;
                        }
                    case "3":
                        {
                            decimal notaTotal = 0;
                            var nrAlunos = 0;

                            for(int j=0; j < alunos.Length;j++)
                            {
                                if (!string.IsNullOrEmpty(alunos[j].Nome))
                                {
                                    notaTotal = notaTotal + alunos[j].Nota;
                                    nrAlunos++;
                                }
                            }
                            var mediaGeral = notaTotal/nrAlunos;
                            Conceito conceitoGeral;

                            if (mediaGeral < 2)
                            {
                                conceitoGeral = Conceito.E;
                            }
                            else if (mediaGeral < 4)
                            {
                                conceitoGeral = Conceito.D;
                            }
                            else if (mediaGeral < 6)
                            {
                                conceitoGeral = Conceito.C;
                            }
                            else if (mediaGeral < 8)
                            {
                                conceitoGeral = Conceito.B;
                            }
                            else
                            {
                                conceitoGeral = Conceito.A;
                            }

                            Console.WriteLine($"Media Geral: {mediaGeral} - Conceito: {conceitoGeral}");

                            //TODO: Calcular Média Geral
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("Informe a opção Desejada");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine("");
            return opcaoUsuario;
        }
    }
}
