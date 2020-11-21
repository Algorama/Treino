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
        public void Cachorro_GetIdade_em_Anos_Test()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = DateTime.Today.AddYears(-4);
            Assert.AreEqual("4 anos", cachorro.GetIdade());
        }

        [TestMethod]
        public void Cachorro_GetIdade_um_Ano_Test()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = DateTime.Today.AddYears(-1);
            Assert.AreEqual("1 ano", cachorro.GetIdade());
        }

        [TestMethod]
        public void Cachorro_GetIdade_em_Meses_Test()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = DateTime.Today.AddMonths(-11);
            Assert.AreEqual("11 meses", cachorro.GetIdade());
        }

        [TestMethod]
        public void Cachorro_GetIdade_um_Mes_Test()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = DateTime.Today.AddMonths(-1);
            Assert.AreEqual("1 mês", cachorro.GetIdade());
        }

        [TestMethod]
        public void Cachorro_Validar_Test()
        {
            try
            {
                var cachorro = new Cachorro
                {
                    DataNascimento = DateTime.Today.AddMonths(10),
                    Peso = 0
                };
                cachorro.Validar();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                var ok = ex.Message.Contains("Nome do Pet é Obrigatório!") &&
                         ex.Message.Contains("Data de Nascimento do Cachorro deve ser menor que a Data Atual!") &&
                         ex.Message.Contains("Peso do Cachorro deve ser maior que zero!");

                Assert.AreEqual(true, ok);
            }
        }

        [TestMethod]
        public void Cachorro_Associacao_Raca_Test()
        {
            var labrador = new Raca { Nome = "Labrador" };

            var tequila = new Cachorro 
            { 
                Nome = "Tequila",
                Raca = labrador
            };

            Console.WriteLine(tequila.Raca.Nome);

            Assert.AreEqual("Labrador", tequila.Raca.Nome);
        }

        [TestMethod]
        public void Cachorro_Associacao_Dono_Test()
        {
            var silvia = new Dono 
            { 
                Nome = "Silvia",
                Email = "silvia@email.com.br",
                Telefone = "(12) 3456 7890"
            };

            var tequila = new Cachorro
            {
                Nome = "Tequila",
                Dono = silvia
            };

            Console.WriteLine(tequila.Dono.Nome);

            Assert.AreEqual("Silvia", tequila.Dono.Nome);
        }

        [TestMethod]
        public void Cachorro_Enum_Sexo_Test()
        {
            var leia = new Cachorro
            {
                Nome = "Leia",
                Sexo = Sexo.Femea
            };

            Console.WriteLine(leia.Sexo);

            Assert.AreEqual(Sexo.Femea, leia.Sexo);
        }

        [TestMethod]
        public void Cachorro_Enum_Raca_Porte_Test()
        {
            var bulldog = new Raca 
            { 
                Nome = "Bulldog Francês",
                Porte = Porte.Medio
            };

            var yuri = new Cachorro
            {
                Nome = "Yuri",
                Raca = bulldog
            };

            Console.WriteLine(yuri.Raca.Porte);

            Assert.AreEqual(Porte.Medio, yuri.Raca.Porte);
        }

        [TestMethod]
        public void Cachorro_IPet_Test()
        {
            IPet pet = new Cachorro { Nome = "Léia", Peso = 2 };

            Assert.AreEqual("Léia", pet.Nome);
            Console.WriteLine(pet.Nome);

            var leia = pet as Cachorro;
            Assert.AreEqual(2, leia.Peso);
            Console.WriteLine(leia.Peso);
        }
    }
}