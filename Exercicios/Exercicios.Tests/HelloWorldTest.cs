using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Exercicios.Domain;

namespace Exercicios.Tests
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void SayHello_Test()
        {
            string mensagem = HelloWorld.SayHello();

            Assert.AreEqual("Hello World!", mensagem);

            Console.WriteLine(mensagem);
        }

        [TestMethod]
        public void Tipos_Primitivos_e_Complexos_Test()
        {
            // Tipos Primitivos
            string mensagem = "Hello World!";            
            double peso = 1.2;
            int idade = 4;

            Console.WriteLine(mensagem);
            Console.WriteLine(idade);
            Console.WriteLine(peso);

            // Tipo complexo
            Cachorro leia = new Cachorro();
            Console.WriteLine(leia);
        }

        [TestMethod]
        public void Conversao_Implicita_Test()
        {
            int inteiro = 10;
            double valor = inteiro;

            Console.WriteLine(valor);
            Assert.AreEqual(inteiro, valor);
        }

        [TestMethod]
        public void Conversao_Explicita_Test()
        {
            double valor = 1.23;
            int inteiro = (int)valor;

            Console.WriteLine(inteiro);
            Assert.AreNotEqual(valor, inteiro);
        }

        [TestMethod]
        public void Tipo_de_Valor_Test()
        {
            int valor = 10;
            HelloWorld.PassaValor(valor);

            Console.WriteLine(valor);
            Assert.AreEqual(10, valor);
        }

        [TestMethod]
        public void Tipo_de_Referencia_Test()
        {
            Cachorro cachorro = new Cachorro();
            cachorro.Nome = "L�ia";

            HelloWorld.PassaReferencia(cachorro);

            string nomeDoCachorro = cachorro.Nome;

            Console.WriteLine(nomeDoCachorro);
            Assert.AreEqual("Tequila", nomeDoCachorro);
        }

        [TestMethod]
        public void Igualdade_entre_Tipos_de_Valor_Test()
        {
            int valor1 = 10;
            int valor2 = 10;

            Assert.AreEqual(valor1, valor2);
        }

        [TestMethod]
        public void Desigualdade_entre_Tipos_de_Referencia_Test()
        {
            Cachorro cachorro1 = new Cachorro();
            cachorro1.Nome = "L�ia";

            Cachorro cachorro2 = new Cachorro();
            cachorro2.Nome = "L�ia";

            Assert.AreNotEqual(cachorro1, cachorro2);
        }

        [TestMethod]
        public void Igualdade_entre_Tipos_de_Referencia_Test()
        {
            Cachorro cachorro1 = new Cachorro();
            cachorro1.Nome = "L�ia";

            Cachorro cachorro2 = cachorro1;

            Assert.AreEqual(cachorro1, cachorro2);

            Console.WriteLine(cachorro2.Nome);
        }

        [TestMethod]
        public void Tipos_Explicitos_Test()
        {                        
            string nome = "Leia";
            int idade = 1;
            double peso = 1.3;
            Cachorro cachorro = new Cachorro();

            Assert.AreEqual(typeof(string), nome.GetType());
            Assert.AreEqual(typeof(int), idade.GetType());
            Assert.AreEqual(typeof(double), peso.GetType());
            Assert.AreEqual(typeof(Cachorro), cachorro.GetType());
        }

        [TestMethod]
        public void Tipos_Implicitos_Test()
        {
            var nome = "Leia";
            var idade = 1;
            var peso = 1.3;
            var cachorro = new Cachorro();

            Assert.AreEqual(typeof(string), nome.GetType());
            Assert.AreEqual(typeof(int), idade.GetType());
            Assert.AreEqual(typeof(double), peso.GetType());
            Assert.AreEqual(typeof(Cachorro), cachorro.GetType());            
        }

        [TestMethod]
        public void Declarar_Sem_Inicializar_Test()
        {
            Cachorro leia;            // Isso est�:
            leia = new Cachorro();    // OK!!

            Assert.AreEqual(typeof(Cachorro), leia.GetType());

            //var tequila;              // N�o OK!
            //tequila = new Cachorro(); // Tipos Implicitos precisam ser inicializados
        }

        [TestMethod]
        public void Tipos_Que_Aceitam_Null_Test()
        {
            string nome = null;
            Cachorro cachorro = null;

            Assert.AreEqual(null, nome);
            Assert.AreEqual(null, cachorro);
        }

        [TestMethod]
        public void Tipos_Nulaveis_Test()
        {
            int? idade = null;
            double? peso = null;
            bool? vacinado = null;

            Assert.AreEqual(null, idade);
            Assert.AreEqual(null, peso);
            Assert.AreEqual(null, vacinado);
        }

        [TestMethod]
        public void DateTime_Test()
        {
            var hoje = DateTime.Today;
            Console.WriteLine(hoje);

            var agora = DateTime.Now;
            Console.WriteLine(agora);
        }

        [TestMethod]
        public void DateTime_Desmembrando_Test()
        {
            var agora = DateTime.Now;
            Console.WriteLine(agora);
            Console.WriteLine(agora.Year);
            Console.WriteLine(agora.Month);
            Console.WriteLine(agora.Day);
            Console.WriteLine(agora.Hour);
            Console.WriteLine(agora.Minute);
            Console.WriteLine(agora.Second);
            Console.WriteLine(agora.DayOfWeek);
            Console.WriteLine(agora.DayOfYear);
        }

        [TestMethod]
        public void DateTime_Add_Test()
        {
            var agora = DateTime.Now;
            Console.WriteLine(agora);

            var mais5horas = agora.AddHours(5);
            Console.WriteLine(mais5horas);

            var amanha = agora.AddDays(1);
            Console.WriteLine(amanha);

            var ontem = agora.AddDays(-1);
            Console.WriteLine(ontem);

            var mesQueVem = agora.AddMonths(1);
            Console.WriteLine(mesQueVem);
        }

        [TestMethod]
        public void DateTime_Inicializacao_Test()
        {
            var data = new DateTime(2020, 10, 13);
            Console.WriteLine(data);

            var dataHora = new DateTime(2020, 10, 13, 10, 30, 0);
            Console.WriteLine(dataHora);
        }

        [TestMethod]
        public void DateTime_Convertendo_de_String_Test()
        {
            var data = DateTime.Parse("13/10/2020");
            Console.WriteLine(data);

            var dataHora = DateTime.Parse("13/10/2020 10:30");
            Console.WriteLine(dataHora);
        }

        [TestMethod]
        public void DateTime_Quantidade_Dias_Mes_Test()
        {
            var diasMes = DateTime.DaysInMonth(2020, 10);
            Console.WriteLine(diasMes);

            var ultimoDiaDoMes = new DateTime(2020, 10, diasMes);
            Console.WriteLine(ultimoDiaDoMes);
        }

        [TestMethod]
        public void DateTime_Formatacoes_Test()
        {
            var agora = DateTime.Now;
            Console.WriteLine(agora.ToString("d")); // short date
            Console.WriteLine(agora.ToString("G")); // general long datetime
            Console.WriteLine(agora.ToString("f")); // full short datetime
            Console.WriteLine(agora.ToString("dd/MM/yyyy"));
            Console.WriteLine(agora.ToString("dd/MM/yyyy HH:mm"));
            Console.WriteLine(agora.ToString("MMM/yy"));
            Console.WriteLine(agora.ToString("MMMM"));            
        }

        [TestMethod]
        public void TimeSpan_Test()
        {
            var hoje = DateTime.Today;
            var amanha = hoje.AddDays(1);

            var dif = amanha.Subtract(hoje);

            Console.WriteLine(dif.TotalSeconds);
            Console.WriteLine(dif.TotalMinutes);
            Console.WriteLine(dif.TotalHours);
            Console.WriteLine(dif.TotalDays);
        }
    }
}