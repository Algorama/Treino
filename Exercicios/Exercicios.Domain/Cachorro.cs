namespace Exercicios.Domain
{
    public class Cachorro
    {
        private string _nome;
        private string _sexo;
        private string _raca;
        private string _porte;
        private int _idade;
        private double _peso;

        public string Latir()
        {
            return "Au! Au!";
        }

        public string QuantoDevoComer(int pesoKg)
        {
            // Calculando 5% do peso em Gramas
            return $"Como tenho {pesoKg}Kg, devo comer {pesoKg * 50}g/dia";
        }

        public void SetNome(string nome)
        {
            _nome = nome;
        }

        public string GetNome()
        {
            return _nome;
        }
    }
}