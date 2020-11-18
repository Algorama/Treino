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
            var vesgo = new Gato { Nome = "Vesgo" };
            var mingau = new Gato { Nome = "Mingau" };

            var silvia = new Dono { Nome = "Silvia" };
            silvia.AddPet(yuri);
            silvia.AddPet(leia);
            silvia.AddPet(vesgo);
            silvia.AddPet(mingau);

            foreach (var pet in silvia.Pets)
                Console.WriteLine($"{pet.GetType().Name}: {pet.Nome}");

            Assert.AreEqual(4, silvia.Pets.Count);
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(silvia, yuri.Dono);
            Assert.AreEqual(silvia, vesgo.Dono);
            Assert.AreEqual(silvia, mingau.Dono);
        }

        [TestMethod]
        public void Dono_RemovePet_Test()
        {
            var yuri = new Cachorro { Nome = "Yuri" };
            var leia = new Cachorro { Nome = "Leia" };
            var vesgo = new Gato { Nome = "Vesgo" };
            var mingau = new Gato { Nome = "Mingau" };

            var silvia = new Dono { Nome = "Silvia" };
            silvia.AddPet(yuri);
            silvia.AddPet(leia);
            silvia.AddPet(vesgo);
            silvia.AddPet(mingau);

            silvia.RemovePet(yuri);
            silvia.RemovePet(vesgo);

            foreach (var pet in silvia.Pets)
                Console.WriteLine($"{pet.GetType().Name}: {pet.Nome}");

            Assert.AreEqual(2, silvia.Pets.Count);
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(null, yuri.Dono);
            Assert.AreEqual(null, vesgo.Dono);
            Assert.AreEqual(silvia, mingau.Dono);
        }

        [TestMethod]
        public void Dono_AddPets_Test()
        {
            var yuri = new Cachorro { Nome = "Yuri" };
            var leia = new Cachorro { Nome = "Leia" };
            var vesgo = new Gato { Nome = "Vesgo" };
            var mingau = new Gato { Nome = "Mingau" };

            var silvia = new Dono { Nome = "Silvia" };

            silvia.AddPet(yuri, leia, vesgo, mingau);

            foreach (var pet in silvia.Pets)
                Console.WriteLine($"{pet.GetType().Name}: {pet.Nome}");

            Assert.AreEqual(4, silvia.Pets.Count);
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(silvia, yuri.Dono);
            Assert.AreEqual(silvia, vesgo.Dono);
            Assert.AreEqual(silvia, mingau.Dono);
        }

        [TestMethod]
        public void Dono_RemovePets_Test()
        {
            var yuri = new Cachorro { Nome = "Yuri" };
            var leia = new Cachorro { Nome = "Leia" };
            var vesgo = new Gato { Nome = "Vesgo" };
            var mingau = new Gato { Nome = "Mingau" };

            var silvia = new Dono { Nome = "Silvia" };

            silvia.AddPet(yuri, leia, vesgo, mingau);

            silvia.RemovePet(yuri, leia, vesgo, mingau);

            foreach (var pet in silvia.Pets)
                Console.WriteLine($"{pet.GetType().Name}: {pet.Nome}");

            Assert.AreEqual(0, silvia.Pets.Count);
            Assert.AreEqual(null, leia.Dono);
            Assert.AreEqual(null, yuri.Dono);
            Assert.AreEqual(null, vesgo.Dono);
            Assert.AreEqual(null, mingau.Dono);
        }
    }
}
