using System;

namespace SAAS
{
    public class Disciplina
    {
        public int DisId { get; set; }
        public string DisNome { get; set; }
        public string DisSigla { get; set; }
        public string DisObservacoes { get; set; }

        public Disciplina() { }

        public Disciplina(int disId, string disNome, string disSigla, string disObservacoes)
        {
            DisId = disId;
            DisNome = disNome;
            DisSigla = disSigla;
            DisObservacoes = disObservacoes;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"ID: {DisId}, Nome: {DisNome}, Sigla: {DisSigla}, Observações: {DisObservacoes}");
        }
    }
}
