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
    }
}
