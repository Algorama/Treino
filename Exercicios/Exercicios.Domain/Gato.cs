using System;

namespace Exercicios.Domain
{
    public class Gato : Animal, IPet
    {
        public object Miar(int qtdeMiados)
        {
            var miados = "";

            for (var i = 1; i <= qtdeMiados; i++)
                miados += "Miau! ";

            return miados.TrimEnd();
        }

        public override string QuantoDevoComer()
        {
            // Calculando 1% do peso em Gramas
            return $"Como tenho {Peso}Kg, devo comer {Peso * 10}g/dia";
        }
    }
}
