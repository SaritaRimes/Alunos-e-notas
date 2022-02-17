using System;

namespace Alunos
{
    class Program
    {
        static void Main(string[] args)
        {
            DadosAlunos[] alunos = new DadosAlunos[5];
            string opcaoUsuario = ObterOpcaoUsuario();

            int indiceAlunos = 0;
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        System.Console.WriteLine("Informe o nome do aluno:");
                        DadosAlunos aluno = new DadosAlunos();
                        aluno.Nome = Console.ReadLine();

                        System.Console.WriteLine("Informe a nota do aluno:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                            aluno.Nota = nota;
                        else
                            throw new ArgumentException("O valor da nota deve ser decimal.");

                        alunos[indiceAlunos] = aluno;
                        ++indiceAlunos;

                        System.Console.WriteLine();

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (a.Nome != null) //outra opcao: string.IsNullOrEmpty(a.Nome)
                                System.Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                        }

                        System.Console.WriteLine();

                        break;
                    case "3":
                        decimal notaTotal = 0;
                        int numeroDeAlunos = 0;

                        for (int i = 0; i < alunos.Length; ++i)
                        {
                            if (alunos[i].Nome != null)
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                ++numeroDeAlunos;
                            }
                        }

                        decimal mediaGeral = notaTotal/numeroDeAlunos;

                        Conceito conceitoGeral;
                        if (mediaGeral < 2)
                            conceitoGeral = Conceito.E;
                        else if (mediaGeral < 4)
                            conceitoGeral = Conceito.D;
                        else if (mediaGeral < 6)
                            conceitoGeral = Conceito.C;
                        else if (mediaGeral < 8)
                            conceitoGeral = Conceito.B;
                        else
                            conceitoGeral = Conceito.A;

                        System.Console.WriteLine($"Media geral: {mediaGeral} - Conceito: {conceitoGeral}");
                        System.Console.WriteLine();

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine("Informe a opção desejada:");
            System.Console.WriteLine("1- Inserir novo aluno");
            System.Console.WriteLine("2- Listar alunos");
            System.Console.WriteLine("3- Calcular média geral");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            System.Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
