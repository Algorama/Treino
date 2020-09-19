using System;

namespace Exercicios.Domain
{
    public class Cachorro
    {
        public string Latir()
        {
            return "Au! Au!";
        }

        public string QuantoDevoComer(int pesoKg)
        {
            // Calculando 5% do peso em Gramas
            return $"Como tenho {pesoKg}Kg, devo comer {pesoKg * 50}g/dia";
        }
    }
}


