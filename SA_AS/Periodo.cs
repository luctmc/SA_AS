using System;

namespace SAAS
{
    public class Periodo
    {
        public int PerId { get; set; }
        public string PerNome { get; set; }
        public string PerSigla { get; set; }

        public Periodo() { }

        public Periodo(int perId, string perNome, string perSigla)
        {
            PerId = perId;
            PerNome = perNome;
            PerSigla = perSigla;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"ID: {PerId}, Nome: {PerNome}, Sigla: {PerSigla}");
        }
    }
}
