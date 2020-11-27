using System;
using System.Collections.Generic;

namespace Exercicios.Domain
{
    public static class Helpers
    {
        public static Exception ConvertListToException(List<string> mensagens)
        {
            var exceptionMessage = string.Empty;
            foreach (var msg in mensagens)
                exceptionMessage += msg + Environment.NewLine;

            return exceptionMessage == string.Empty
                ? null
                : new Exception(exceptionMessage);
        }
    }
}
