﻿using Exercicios.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios.Tests
{
    [TestClass]
    public class PetTest
    {
        private static List<IPet> _pets;

        [ClassInitialize]
        public static async Task Setup(TestContext context)
        {
            _pets = new List<IPet>();
            await _pets.CarregaPetsDoArquivo("C:\\Aula030\\pets.csv");
        }

        private static void ImprimePets(IEnumerable<IPet> pets)
        {
            foreach (var pet in pets)
                Console.WriteLine($"[{pet.GetTipo()}] {pet.Nome} - {pet.Dono.Nome}");
        }

        [TestMethod]
        public void CarregaPetsDoArquivo_Test()
        {
            Assert.AreEqual(15, _pets.Count);
            ImprimePets(_pets);
        }

        [TestMethod]
        public void Linq_Test()
        {
            var query = from pet in _pets
                        where pet.GetTipo() == "Cachorro"
                        select pet;

            ImprimePets(query);
        }

        [TestMethod]
        public void Linq_Metodos_Test()
        {
            var query = _pets.Where(pet => pet.GetTipo() == "Gato");
            ImprimePets(query);
        }

        [TestMethod]
        public void Linq_Order_Test()
        {
            var query = from pet in _pets
                        where pet.GetTipo() == "Cachorro"
                        orderby pet.Nome
                        select pet;

            ImprimePets(query);
        }

        [TestMethod]
        public void Linq_Order_Metodos_Test()
        {
            var query = _pets.Where(pet => pet.GetTipo() == "Gato")
                             .OrderBy(pet => pet.Nome);

            ImprimePets(query);
        }


        [TestMethod]
        public void Linq_Projecao_Test()
        {
            var query = from pet in _pets
                        where pet.GetTipo() == "Cachorro"
                        orderby pet.Peso descending
                        select new { pet.Nome, pet.Peso };

            foreach (var pet in query)
                Console.WriteLine($"{pet.Nome}: {pet.Peso}");
        }

        [TestMethod]
        public void Linq_Projeca_Metodos_Test()
        {
            var query = _pets.Where(pet => pet.GetTipo() == "Gato")
                             .OrderByDescending(pet => pet.Peso)
                             .Select(pet => new { pet.Nome, pet.Peso });

            foreach (var pet in query)
                Console.WriteLine($"{pet.Nome}: {pet.Peso}");
        }

        [TestMethod]
        public void Linq_Take_Skip_Test()
        {
            var query = (from pet in _pets
                         where pet.GetTipo() == "Cachorro"
                         orderby pet.Peso descending
                         select new { pet.Nome, pet.Peso }).Skip(2).Take(4);

            foreach (var pet in query)
                Console.WriteLine($"{pet.Nome}: {pet.Peso}");
        }

        [TestMethod]
        public void Linq_First_Last_Test()
        {
            var query = from pet in _pets
                        where pet.GetTipo() == "Cachorro"
                        orderby pet.Peso descending
                        select new { pet.Nome, pet.Peso };

            var primeiro = query.FirstOrDefault();
            var ultimo = query.LastOrDefault();

            Console.WriteLine($"{primeiro.Nome}: {primeiro.Peso}");
            Console.WriteLine($"{ultimo.Nome}: {ultimo.Peso}");
        }

        [TestMethod]
        public void Linq_Agregacoes_Test()
        {
            var query = from pet in _pets
                        where pet.GetTipo() == "Cachorro"
                        orderby pet.Peso descending
                        select new { pet.Nome, pet.Peso };

            var somaPeso = query.Sum(pet => pet.Peso);
            var maiorPeso = query.Max(pet => pet.Peso);
            var menorPeso = query.Min(pet => pet.Peso);
            var mediaPeso = query.Average(pet => pet.Peso);

            Console.WriteLine($"Soma Peso: {somaPeso}");
            Console.WriteLine($"Maior Peso: {maiorPeso}");
            Console.WriteLine($"Menor Peso: {menorPeso}");
            Console.WriteLine($"Média Peso: {mediaPeso}");
        }

        [TestMethod]
        public void Linq_Group_Test()
        {
            var query = from pet in _pets
                        group pet by pet.Sexo into g
                        select new { Sexo = g.Key, Total = g.Count() };

            foreach (var x in query)
                Console.WriteLine($"{x.Sexo}: {x.Total}");
        }

        [TestMethod]
        public void Linq_Group_Dono_Test()
        {
            var query = from pet in _pets
                        group pet by pet.Dono into g
                        orderby g.Key.Nome
                        select new 
                        { 
                            Dono = g.Key.Nome, 
                            TotalCaes = g.Key.Pets.Count(x => x.GetTipo() == "Cachorro"),
                            TotalGatos = g.Key.Pets.Count(x => x.GetTipo() == "Gato")
                        };

            foreach (var x in query)
                Console.WriteLine($"{x.Dono}: Cães= {x.TotalCaes} - Gatos= {x.TotalGatos}");
        }

        [TestMethod]
        public void Linq_Cachorro_MaisVelhor_e_MaisNovo_Test()
        {
            var cachorros = _pets.Where(x => x.GetTipo() == "Cachorro").Cast<Cachorro>();

            var maisVelho = cachorros.Aggregate((min, x) => x.DataNascimento < min.DataNascimento ? x : min);
            var maisNovo = cachorros.Aggregate((max, x) => x.DataNascimento > max.DataNascimento ? x : max);

            Console.WriteLine($"Mais Velho: {maisVelho.Nome} - {maisVelho.DataNascimento} : {maisVelho.GetIdade()}");
            Console.WriteLine($"Mais Novo: {maisNovo.Nome} - {maisNovo.DataNascimento} : {maisNovo.GetIdade()}");
        }
    }
}