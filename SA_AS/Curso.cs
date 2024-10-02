using System;

namespace SAAS
{
    public class Curso
    {
        public int CurId { get; set; }
        public string CurNome { get; set; }
        public string CurSigla { get; set; }
        public string CurObservacoes { get; set; }
        public int PerId { get; set; }  

        public Curso() { }

        public Curso(int curId, string curNome, string curSigla, string curObservacoes, int perId)
        {
            CurId = curId;
            CurNome = curNome;
            CurSigla = curSigla;
            CurObservacoes = curObservacoes;
            PerId = perId;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"ID: {CurId}, Nome: {CurNome}, Sigla: {CurSigla}, Observações: {CurObservacoes}, Período: {PerId}");
        }
    }
}
