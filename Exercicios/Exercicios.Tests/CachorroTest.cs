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
            var leia = new Cachorro();
            var latido = leia.Latir(3);

            Console.WriteLine(latido);

            Assert.AreEqual("Au! Au! Au!", latido);
        }

        [TestMethod]
        public void Leia_QuantoDevoComer_Test()
        {
            var leia = new Cachorro();
            var quantidadeDeRacao = leia.QuantoDevoComer(1);

            Console.WriteLine(quantidadeDeRacao);
            Assert.AreEqual("Como tenho 1Kg, devo comer 50g/dia", quantidadeDeRacao);
        }

        [TestMethod]
        public void Tequila_QuantoDevoComer_Test()
        {
            var tequila = new Cachorro();
            var quantidadeDeRacao = tequila.QuantoDevoComer(30);

            Console.WriteLine(quantidadeDeRacao);
            Assert.AreEqual("Como tenho 30Kg, devo comer 1500g/dia", quantidadeDeRacao);
        }

        [TestMethod]
        public void Yuri_QuantoDevoComer_Test()
        {
            var yuri = new Cachorro();
            var quantidadeDeRacao = yuri.QuantoDevoComer(15);

            Console.WriteLine(quantidadeDeRacao);
            Assert.AreEqual("Como tenho 15Kg, devo comer 750g/dia", quantidadeDeRacao);
        }

        [TestMethod]
        public void Cachorro_Set_Get_Peso_Test()
        {
            var leia = new Cachorro();

            leia.Peso = 1.2;
            var peso = leia.Peso;

            Console.WriteLine(peso);
            Assert.AreEqual(1.2, peso);
        }

        [TestMethod]
        public void Cachorro_Peso_Nao_Pode_Ser_Negativo_Test()
        {
            var leia = new Cachorro();

            leia.Peso = -1.2;
            var peso = leia.Peso;

            Console.WriteLine(peso);
            Assert.AreEqual(null, peso);
        }

        [TestMethod]
        public void Cachorro_Peso_Deve_Aceitar_Null_Test()
        {
            var leia = new Cachorro();

            leia.Peso = null;
            var peso = leia.Peso;

            Console.WriteLine(peso);
            Assert.AreEqual(null, peso);
        }

        [TestMethod]
        public void Cachorro_GetIdade_em_Anos()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = DateTime.Today.AddYears(-4);
            Assert.AreEqual("4 anos", cachorro.GetIdade());
        }

        [TestMethod]
        public void Cachorro_GetIdade_um_Ano()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = DateTime.Today.AddYears(-1);
            Assert.AreEqual("1 ano", cachorro.GetIdade());
        }

        [TestMethod]
        public void Cachorro_GetIdade_em_Meses()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = DateTime.Today.AddMonths(-11);
            Assert.AreEqual("11 meses", cachorro.GetIdade());
        }

        [TestMethod]
        public void Cachorro_GetIdade_um_Mes()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = DateTime.Today.AddMonths(-1);
            Assert.AreEqual("1 mês", cachorro.GetIdade());
        }

        [TestMethod]
        public void Cachorro_Nome_Obrigatorio()
        {
            var cachorro = new Cachorro
            {
                Sexo = "Fêmea",
                DataNascimento = new DateTime(2020, 7, 4),
                Peso = 2
            };

            var mensagens = cachorro.Validar();
            
            Assert.AreEqual("Nome do Cachorro é Obrigatório!", mensagens[0]);
            Console.WriteLine(mensagens[0]);
        }

        [TestMethod]
        public void Cachorro_Sexo_Deve_Ser_Femea_ou_Macho()
        {
            var cachorro = new Cachorro
            {
                Nome = "Léia",
                Sexo = "Xyz",
                DataNascimento = new DateTime(2020, 7, 4),
                Peso = 2
            };

            var mensagens = cachorro.Validar();

            Assert.AreEqual("Sexo do Cachorro deve ser Fêmea ou Macho!", mensagens[0]);
            Console.WriteLine(mensagens[0]);
        }

        [TestMethod]
        public void Cachorro_Data_Nascimento_Deve_ser_Menor_que_Hoje()
        {
            var cachorro = new Cachorro
            {
                Nome = "Léia",
                Sexo = "Fêmea",
                DataNascimento = DateTime.Today.AddMonths(10),
                Peso = 2
            };

            var mensagens = cachorro.Validar();

            Assert.AreEqual("Data de Nascimento do Cachorro deve ser menor que a Data Atual!", 
                mensagens[0]);
            Console.WriteLine(mensagens[0]);
        }

        [TestMethod]
        public void Cachorro_Peso_Deve_Ser_Maior_que_Zero()
        {
            var cachorro = new Cachorro
            {
                Nome = "Léia",
                Sexo = "Fêmea",
                DataNascimento = new DateTime(2020, 7, 4),
                Peso = 0
            };

            var mensagens = cachorro.Validar();

            Assert.AreEqual("Peso do Cachorro deve ser maior que zero!",
                mensagens[0]);
            Console.WriteLine(mensagens[0]);
        }
    }
}