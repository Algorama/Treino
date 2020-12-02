using System;

namespace Exercicios.Domain
{
    public class Cachorro : Animal, IPet
    {
        public Raca Raca { set; get; }
        public DateTime DataNascimento { get; set; }
        public bool Vacinado { get; set; }

        public string Latir(short qtdeLatidos)
        {
            var latidos = "";

            for (var i = 1; i <= qtdeLatidos; i++)
                latidos += "Au! ";

            return latidos.TrimEnd();
        }

        public override string QuantoDevoComer()
        {
            // Calculando 5% do peso em Gramas
            return $"Como tenho {Peso}Kg, devo comer {Peso * 50}g/dia";
        }

        public override void Validar()
        {
            var mensagens = ValidacoesComuns();

            if (DataNascimento > DateTime.Today)
                mensagens.Add("Data de Nascimento do Cachorro deve ser menor que a Data Atual!");

            if (Peso <= 0)
                mensagens.Add("Peso do Cachorro deve ser maior que zero!");

            var ex = mensagens.ToException();
            if (ex != null)
                throw ex;
        }

        public string GetIdade()
        {
            var anos = DateTime.Today.Year - DataNascimento.Year;
            var meses = DateTime.Today.Month - DataNascimento.Month + (12 * anos);

            if(meses < 12)
                return meses == 1 ? "1 mês" : $"{meses} meses";

            return anos == 1 ? "1 ano" : $"{anos} anos";
        }
    }
}