using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdotaPet.Console
{
    [DocComando(instrucao: "show",
        docuemntacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show
    {
        public void ExibirConteudoArquivo(string caminhoArquivoExibido)
        {
            LeitorDeArquivo leitor = new LeitorDeArquivo();
            var listaDePets = leitor.RealizaLeitura(caminhoArquivoExibido);
            foreach (var pet in listaDePets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
