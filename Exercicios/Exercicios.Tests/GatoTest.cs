﻿using Exercicios.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exercicios.Tests
{
    [TestClass]
    public class GatoTest
    {
        [TestMethod]
        public void Gato_Miar_Test()
        {
            var vesgo = new Gato();
            var miado = vesgo.Miar(3);

            Console.WriteLine(miado);

            Assert.AreEqual("Miau! Miau! Miau!", miado);
        }

        [TestMethod]
        public void Gato_Validar_Test()
        {
            try
            {
                var gato = new Gato();
                gato.Validar();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                var ok = ex.Message.Contains("Nome do Pet é Obrigatório!");

                Assert.AreEqual(true, ok);
            }
        }

        [TestMethod]
        public void Gato_QuantoDevoComer_Test()
        {
            var gato = new Gato { Peso = 6 };
            var quantidadeDeRacao = gato.QuantoDevoComer();

            Console.WriteLine(quantidadeDeRacao);
            Assert.AreEqual("Como tenho 6Kg, devo comer 60g/dia", quantidadeDeRacao);
        }
    }
}