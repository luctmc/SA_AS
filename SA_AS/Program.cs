using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace SAAS

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            int subopcao = 0;


            string caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            string nomeBancoPeriodos = ConfigurationManager.AppSettings["nomeBancoPeriodos"];
            string nomeBancoCursos = ConfigurationManager.AppSettings["nomeBancoCursos"];
            string nomeBancoDisciplinas = ConfigurationManager.AppSettings["nomeBancoDisciplinas"];


            List<Periodo> periodos = CarregarPeriodosDoCsv(caminhoBanco + nomeBancoPeriodos);
            List<Curso> cursos = CarregarCursosDoCsv(caminhoBanco + nomeBancoCursos);
            List<Disciplina> disciplinas = CarregarDisciplinasDoCsv(caminhoBanco + nomeBancoDisciplinas);


            while (opcao != 9)
            {
                Console.Clear();
                Console.WriteLine("SA");
                Console.WriteLine("Períodos");
                Console.WriteLine("Cursos");
                Console.WriteLine("Disciplinas");
                Console.WriteLine("9. Sair");
                Console.Write("Digite a opção: ");
                opcao = int.Parse(Console.ReadLine());


                switch (opcao)
                {
                    case 1:
                        GerenciarPeriodos(periodos, caminhoBanco + nomeBancoPeriodos);
                        break;
                    case 2:
                        GerenciarCursos(cursos, periodos, caminhoBanco + nomeBancoCursos);
                        break;
                    case 3:
                        GerenciarDisciplinas(disciplinas, caminhoBanco + nomeBancoDisciplinas);
                        break;
                }
            }


            SalvarPeriodosEmCsv(periodos, caminhoBanco + nomeBancoPeriodos);
            SalvarCursosEmCsv(cursos, caminhoBanco + nomeBancoCursos);
            SalvarDisciplinasEmCsv(disciplinas, caminhoBanco + nomeBancoDisciplinas);
        }


        static void GerenciarPeriodos(List<Periodo> periodos, string caminhoArquivo)
        {
            int subopcao = 0;
            while (subopcao != 19)
            {
                Console.Clear();
                Console.WriteLine("PERÍODOS");
                Console.WriteLine("10. Inserir");
                Console.WriteLine("11. Excluir");
                Console.WriteLine("12. Pesquisar");
                Console.WriteLine("13. Exibir");
                Console.WriteLine("19. Voltar");
                Console.Write("Digite a opção: ");
                subopcao = int.Parse(Console.ReadLine());


                switch (subopcao)
                {
                    case 10:

                        Console.Write("ID do Período: ");
                        int perId = int.Parse(Console.ReadLine());
                        Console.Write("Nome do Período: ");
                        string perNome = Console.ReadLine();
                        Console.Write("Sigla do Período: ");
                        string perSigla = Console.ReadLine();
                        periodos.Add(new Periodo(perId, perNome, perSigla));
                        break;

                    case 11:

                        Console.Write("ID do Período para excluir: ");
                        int idExcluir = int.Parse(Console.ReadLine());
                        Periodo periodoExcluir = periodos.Find(p => p.PerId == idExcluir);
                        if (periodoExcluir != null)
                        {
                            periodos.Remove(periodoExcluir);
                        }
                        break;
                    case 12:

                        Console.Write("ID do Período para pesquisar: ");
                        int idPesquisar = int.Parse(Console.ReadLine());
                        Periodo periodoPesquisar = periodos.Find(p => p.PerId == idPesquisar);
                        if (periodoPesquisar != null)
                        {
                            periodoPesquisar.ExibirDados();
                            Console.ReadLine();
                        }
                        break;
                    case 13:

                        Console.Clear();
                        foreach (var periodo in periodos)
                        {
                            periodo.ExibirDados();
                        }
                        Console.ReadLine();
                        break;
                }
            }
        }


        static void GerenciarCursos(List<Curso> cursos, List<Periodo> periodos, string caminhoArquivo)
        {
            int subopcao = 0;
            while (subopcao != 29)
            {
                Console.Clear();
                Console.WriteLine("CURSOS");
                Console.WriteLine("20. Inserir");
                Console.WriteLine("21. Excluir");
                Console.WriteLine("22. Pesquisar");
                Console.WriteLine("23. Exibir");
                Console.WriteLine("29. Voltar");
                Console.Write("Digite a opção: ");
                subopcao = int.Parse(Console.ReadLine());

                switch (subopcao)
                {
                    case 20:

                        Console.Write("ID do Curso: ");
                        int curId = int.Parse(Console.ReadLine());
                        Console.Write("Nome do Curso: ");
                        string curNome = Console.ReadLine();
                        Console.Write("Sigla do Curso: ");
                        string curSigla = Console.ReadLine();
                        Console.Write("Observações do Curso: ");
                        string curObservacoes = Console.ReadLine();
                        Console.Write("ID do Período: ");
                        int perId = int.Parse(Console.ReadLine());
                        cursos.Add(new Curso(curId, curNome, curSigla, curObservacoes, perId));
                        break;

                }
            }
        }


        static void GerenciarDisciplinas(List<Disciplina> disciplinas, string caminhoArquivo)
        {
            int subopcao = 0;
            while (subopcao != 39)
            {
                Console.Clear();
                Console.WriteLine("DISCIPLINAS");
                Console.WriteLine("30. Inserir");
                Console.WriteLine("31. Excluir");
                Console.WriteLine("32. Pesquisar");
                Console.WriteLine("33. Exibir");
                Console.WriteLine("39. Voltar");
                Console.Write("Digite a opção: ");
                subopcao = int.Parse(Console.ReadLine());

                switch (subopcao)
                {
                    case 30:

                        Console.Write("ID da Disciplina: ");
                        int disId = int.Parse(Console.ReadLine());
                        Console.Write("Nome da Disciplina: ");
                        string disNome = Console.ReadLine();
                        Console.Write("Sigla da Disciplina: ");
                        string disSigla = Console.ReadLine();
                        Console.Write("Observações da Disciplina: ");
                        string disObservacoes = Console.ReadLine();
                        disciplinas.Add(new Disciplina(disId, disNome, disSigla, disObservacoes));
                        break;

                }
            }
        }


        static void SalvarPeriodosEmCsv(List<Periodo> periodos, string caminho)
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.WriteLine("PerId,PerNome,PerSigla");
                foreach (var periodo in periodos)
                {
                    writer.WriteLine($"{periodo.PerId},{periodo.PerNome},{periodo.PerSigla}");
                }
            }
        }

        static List<Periodo> CarregarPeriodosDoCsv(string caminho)
        {
            List<Periodo> periodos = new List<Periodo>();
            if (File.Exists(caminho))
            {
                using (StreamReader reader = new StreamReader(caminho))
                {
                    reader.ReadLine();  
                    string linha;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(',');
                        if (dados.Length == 3)
                        {
                            periodos.Add(new Periodo(int.Parse(dados[0]), dados[1], dados[2]));
                        }
                    }
                }
            }
            return periodos;
        }


        static void SalvarCursosEmCsv(List<Curso> cursos, string caminho)
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.WriteLine("CurId,CurNome,CurSigla,CurObservacoes,PerId");
                foreach (var curso in cursos)
                {
                    writer.WriteLine($"{curso.CurId},{curso.CurNome},{curso.CurSigla},{curso.CurObservacoes},{curso.PerId}");
                }
            }
        }

        static List<Curso> CarregarCursosDoCsv(string caminho)
        {
            List<Curso> cursos = new List<Curso>();
            if (File.Exists(caminho))
            {
                using (StreamReader reader = new StreamReader(caminho))
                {
                    reader.ReadLine();  
                    string linha;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(',');
                        if (dados.Length == 5)
                        {
                            cursos.Add(new Curso(int.Parse(dados[0]), dados[1], dados[2], dados[3], int.Parse(dados[4])));
                        }
                    }
                }
            }
            return cursos;
        }

        static void SalvarDisciplinasEmCsv(List<Disciplina> disciplinas, string caminho)
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.WriteLine("DisId,DisNome,DisSigla,DisObservacoes");
                foreach (var disciplina in disciplinas)
                {
                    writer.WriteLine($"{disciplina.DisId},{disciplina.DisNome},{disciplina.DisSigla},{disciplina.DisObservacoes}");
                }
            }
        }

        static List<Disciplina> CarregarDisciplinasDoCsv(string caminho)
        {
            List<Disciplina> disciplinas = new List<Disciplina>();
            if (File.Exists(caminho))
            {
                using (StreamReader reader = new StreamReader(caminho))
                {
                    reader.ReadLine();  
                    string linha;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(',');
                        if (dados.Length == 4)
                        {
                            disciplinas.Add(new Disciplina(int.Parse(dados[0]), dados[1], dados[2], dados[3]));
                        }
                    }
                }
            }
            return disciplinas;
        }
    }
}
