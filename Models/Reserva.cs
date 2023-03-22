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
            // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            
            bool comporta = (Suite.Capacidade >= hospedes.Count ? true : false);
            if (comporta)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                
                throw new Exception("A capacidade da suite não comporta a quantidade de hóspedes");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            
            int quantidade = Hospedes.Count;
            return quantidade;
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            

            decimal valor = Suite.ValorDiaria * DiasReservados;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            

            if (DiasReservados >= 10)
            {
                decimal desconto = valor * 0.10M;
                valor = valor - desconto;
            }

            return valor;
        }
    }
}