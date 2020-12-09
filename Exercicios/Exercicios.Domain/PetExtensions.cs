﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Exercicios.Domain
{
    public static class PetExtensions
    {
        public static string GetTipo(this IPet pet)
        {
            return pet.GetType().Name;
        }

        public static async Task CarregaPetsDoArquivo(this List<IPet> pets, string caminho)
        {
            var donos = new List<Dono>();
            var racas = new List<Raca>();            

            var linhas = await File.ReadAllLinesAsync(caminho);
            for (var i = 1; i < linhas.Length; i++)
            {
                var colunas = linhas[i].Split(";".ToCharArray());
                if (colunas[0] == "Cachorro")
                {
                    var cachorro = new Cachorro();
                    cachorro.SetPropriedadesComuns(donos, colunas);
                    cachorro.Raca = racas.GetRaca(colunas[5], colunas[6]);
                    cachorro.DataNascimento = Convert.ToDateTime(colunas[7]);
                    cachorro.Vacinado = colunas[8] == "sim";
                    pets.Add(cachorro);
                }
                else if (colunas[0] == "Gato")
                {
                    var gato = new Gato();
                    gato.SetPropriedadesComuns(donos, colunas);
                    pets.Add(gato);
                }
            }
        }

        private static void SetPropriedadesComuns(this IPet pet, List<Dono> donos, string[] colunas)
        {
            pet.Nome = colunas[1];
            pet.Sexo = colunas[2] == "Macho" ? Sexo.Macho : Sexo.Femea;
            pet.Peso = double.Parse(colunas[4]);

            var dono = donos.GetDono(colunas[3]);
            dono.AddPet(pet);
        }

        private static Dono GetDono(this List<Dono> donos, string donoNome)
        {
            foreach (var dono in donos)
            {
                if (dono.Nome == donoNome)
                    return dono;
            }

            var novoDono = new Dono { Nome = donoNome };
            donos.Add(novoDono);

            return novoDono;
        }

        private static Raca GetRaca(this List<Raca> racas, string racaNome, string porte)
        {
            foreach (var raca in racas)
            {
                if (raca.Nome == racaNome)
                    return raca;
            }

            var novaRaca = new Raca
            {
                Nome = racaNome,
                Porte = GetPorte(porte)
            };
            racas.Add(novaRaca);

            return novaRaca;
        }

        private static Porte GetPorte(string porte)
        {
            switch (porte)
            {
                case "Pequeno":
                    return Porte.Pequeno;
                case "Médio":
                    return Porte.Medio;
                default:
                    return Porte.Grande;
            }
        }
    }
}
