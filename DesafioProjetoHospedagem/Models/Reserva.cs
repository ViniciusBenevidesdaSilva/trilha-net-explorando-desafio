using System;
using System.Collections.Generic;
using System.Linq;

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
            // Implementado: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if(Suite == null)
            {
                throw new Exception("É preciso informar qual a suíte antes de cadastrar os hospedes!");
            }

            if (Suite.Capacidade >= hospedes.Count())
            {
                Hospedes = hospedes;
            }
            else
            {
                // Implementado: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("A quantidade de hospedes não pode exceder a capacidade da suíte!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Implementado: Retorna a quantidade de hóspedes (propriedade Hospedes)
            if(Hospedes == null)
            {
                return 0;
            }

            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Implementado: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            if(Suite == null)
            {
                throw new Exception("É preciso informar qual a suíte antes de calcular a diária!");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= (decimal)0.9;
            }

            return valor;
        }
    }
}
