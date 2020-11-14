using Exercicios.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Exercicios.Tests
{
    [TestClass]
    public class DonoTest
    {
        [TestMethod]
        public void Dono_AddPet_Test()
        {
            var yuri = new Cachorro { Nome = "Yuri" };
            var leia = new Cachorro { Nome = "Leia" };

            var silvia = new Dono { Nome = "Silvia" };
            silvia.AddPet(yuri);
            silvia.AddPet(leia);

            foreach (var pet in silvia.Pets)
                Console.WriteLine(pet.Nome);

            Assert.AreEqual(2, silvia.Pets.Count);
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(silvia, yuri.Dono);
        }

        [TestMethod]
        public void Dono_RemovePet_Test()
        {
            var yuri = new Cachorro { Nome = "Yuri" };
            var leia = new Cachorro { Nome = "Leia" };

            var silvia = new Dono { Nome = "Silvia" };
            silvia.AddPet(yuri);
            silvia.AddPet(leia);

            silvia.RemovePet(yuri);

            foreach (var pet in silvia.Pets)
                Console.WriteLine(pet.Nome);

            Assert.AreEqual(1, silvia.Pets.Count);
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(null, yuri.Dono);
        }

        [TestMethod]
        public void Dono_AddPets_Test()
        {
            var yuri = new Cachorro { Nome = "Yuri" };
            var leia = new Cachorro { Nome = "Leia" };

            var silvia = new Dono { Nome = "Silvia" };

            silvia.AddPet(yuri, leia);

            foreach (var pet in silvia.Pets)
                Console.WriteLine(pet.Nome);

            Assert.AreEqual(2, silvia.Pets.Count);
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(silvia, yuri.Dono);
        }

        [TestMethod]
        public void Dono_RemovePets_Test()
        {
            var yuri = new Cachorro { Nome = "Yuri" };
            var leia = new Cachorro { Nome = "Leia" };

            var silvia = new Dono { Nome = "Silvia" };

            silvia.AddPet(yuri, leia);
            silvia.RemovePet(yuri, leia);

            foreach (var pet in silvia.Pets)
                Console.WriteLine(pet.Nome);

            Assert.AreEqual(0, silvia.Pets.Count);
            Assert.AreEqual(null, leia.Dono);
            Assert.AreEqual(null, yuri.Dono);
        }
    }
}
