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
                    Sexo = "XYz",
                    DataNascimento = DateTime.Today.AddMonths(10),
                    Peso = 0
                };
                cachorro.Validar();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                var ok = ex.Message.Contains("Nome do Cachorro é Obrigatório!") &&
                         ex.Message.Contains("Sexo do Cachorro deve ser Fêmea ou Macho!") &&
                         ex.Message.Contains("Data de Nascimento do Cachorro deve ser menor que a Data Atual!") &&
                         ex.Message.Contains("Peso do Cachorro deve ser maior que zero!");

                Assert.AreEqual(true, ok);
            }
        }

        [TestMethod]
        public void Cachorro_Associacao_Raca_Teste()
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
        public void Cachorro_Associacao_Dono_Teste()
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
    }
}