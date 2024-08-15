using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdotaPet.Console
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DocComando : System.Attribute
    {
        public DocComando(string instrucao, string docuemntacao)
        {
            Instrucao = instrucao;
            Docuemntacao = docuemntacao;
        }

        public string Instrucao { get; }
        public string Docuemntacao { get; }
    }
}
