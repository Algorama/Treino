using Exercicios.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exercicios.Tests
{
    [TestClass]
    public class CachorroTest
    {
        [TestMethod]
        public void Cachorro_Latir_Test()
        {    
            Cachorro leia = new Cachorro();
            string latido = leia.Latir();

            Console.WriteLine(latido);

            Assert.AreEqual("Au! Au!", latido);
        }

        // Considerando que a Leia pesa 1Kg,
        // e come 5% do seu peso de ração, 
        // implemnte o Método "QuantoDevoComer" 
        // para passar no Teste

        [TestMethod]
        public void Leia_QuantoDevoComer_Test()
        {
            Cachorro leia = new Cachorro();
            string quantidadeDeRacao = leia.QuantoDevoComer(1);

            Console.WriteLine(quantidadeDeRacao);

            Assert.AreEqual("Como tenho 1Kg, devo comer 50g/dia", 
                quantidadeDeRacao);
        }

        // Criar os métodos de teste, para a Tequila e para o Yuri
    }
}



