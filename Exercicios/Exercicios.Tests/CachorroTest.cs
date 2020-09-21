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
            Assert.AreEqual("Como tenho 1Kg, devo comer 50g/dia", quantidadeDeRacao);
        }

        [TestMethod]
        public void Tequila_QuantoDevoComer_Test()
        {
            Cachorro tequila = new Cachorro();
            string quantidadeDeRacao = tequila.QuantoDevoComer(30);

            Console.WriteLine(quantidadeDeRacao);
            Assert.AreEqual("Como tenho 30Kg, devo comer 1500g/dia", quantidadeDeRacao);
        }

        [TestMethod]
        public void Yuri_QuantoDevoComer_Test()
        {
            Cachorro yuri = new Cachorro();
            string quantidadeDeRacao = yuri.QuantoDevoComer(15);

            Console.WriteLine(quantidadeDeRacao);
            Assert.AreEqual("Como tenho 15Kg, devo comer 750g/dia", quantidadeDeRacao);
        }

        [TestMethod]
        public void Cachorro_Set_Get_Nome_Test()
        {
            Cachorro yuri = new Cachorro();

            yuri.SetNome("Yuri");
            string nome = yuri.GetNome();

            Console.WriteLine(nome);
            Assert.AreEqual("Yuri", nome);
        }
    }
}