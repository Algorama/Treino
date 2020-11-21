﻿using System;
using System.Collections.Generic;

namespace Exercicios.Domain
{
    public class Animal
    {
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public string Foto { get; set; }
        public Dono Dono { get; set; }

        public virtual string QuantoDevoComer(int pesoKg)
        {
            throw new NotImplementedException();
        }

        protected List<string> ValidacoesComuns()
        {
            var mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(Nome))
                mensagens.Add("Nome do Pet é Obrigatório!");

            return mensagens;
        }

        public virtual void Validar()
        {
            var mensagens = ValidacoesComuns();
           
            if (mensagens.Count > 0)
            {
                var exceptionMessage = string.Empty;
                foreach (var msg in mensagens)
                    exceptionMessage += msg + Environment.NewLine;

                throw new Exception(exceptionMessage);
            }
        }
    }
}
