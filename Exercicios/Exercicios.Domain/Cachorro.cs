using System;

namespace Exercicios.Domain
{
    public class Cachorro
    {
        #region Nome
        public void SetNome(string nome)
        {
            _nome = nome;
        }
        public string GetNome()
        {
            return _nome;
        }
        private string _nome;
        #endregion

        #region Sexo
        public void SetSexo(string sexo)
        {
            _sexo = sexo;
        }
        public string GetSexo()
        {
            return _sexo;
        }
        private string _sexo;
        #endregion

        #region Raça
        public void SetRaca(string raca)
        {
            _raca = raca;
        }
        public string GetRaca()
        {
            return _raca;
        }
        private string _raca;
        #endregion

        #region Porte
        public void SetPorte(string porte)
        {
            _porte = porte;
        }
        public string GetPorte()
        {
            return _porte;
        }
        private string _porte;
        #endregion

        #region Idade
        public void SetIdade(int idade)
        {
            _idade = idade;
        }

        public int GetIdade()
        {
            return _idade;
        }
        private int _idade;
        #endregion

        #region Peso
        public void SetPeso(double peso)
        {
            if (peso < 0)
            {
                _peso = 0;
            }
            else
            {
                _peso = peso;
            }
        }
        public double GetPeso()
        {
            return _peso;
        }
        private double _peso;
        #endregion

        public string Latir()
        {
            return "Au! Au!";
        }

        public string QuantoDevoComer(int pesoKg)
        {
            // Calculando 5% do peso em Gramas
            return $"Como tenho {pesoKg}Kg, devo comer {pesoKg * 50}g/dia";
        }
    }
}