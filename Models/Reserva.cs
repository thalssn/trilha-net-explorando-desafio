namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // *Implementado*
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // *Implementado*
                throw new Exception("A quantidade de hóspedes é maior que a capacidade da suíte. Encerrando Programa!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // *Implementado*
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // *Implementado*
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // *Implementado*
            if (DiasReservados > 10)
            {
                decimal desconto = valor * 0.10M;
                valor = valor - desconto;
            }

            return valor;
        }
    }
}