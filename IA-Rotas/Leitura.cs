using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IA_Rotas
{
    class Leitura
    {
        private AStar astar;
        string arq;
        int n;
        public AStar Astar
        {
            get { return astar; }
        }

        public Leitura(string arquivo)
        {
            this.arq = arquivo;
            astar = new AStar();
            getCidades();
            
        }
        /* Leitura em arquivo*/
        private void getCidades()
        {
            string linha;
            using (StreamReader read = new StreamReader(arq))
            {
                linha = read.ReadLine();
                astar.tam = Convert.ToInt32(linha);
                this.n = astar.tam;
                linha = read.ReadLine();
                int j = 0;
                astar.matrizDistancia = new int[n, n];
                astar.matrizLigacao = new int[n, n];
                string[] vetLinha;
                //Ligações diretas entre cidades - Primeira matriz
                for (int k = 0; k < n; k++)
                {
                    linha = read.ReadLine();
                    //vetLinha = Regex.Split(linha, "\n");
                    vetLinha = linha.Split(' ');
                    foreach (var item in vetLinha)
                    {
                        astar.matrizDistancia[k, j] = Convert.ToInt32(item);
                        j++;
                    }
                    j = 0;
                }
                //Ligações entre cidades - Segunda matriz
                linha = read.ReadLine();
                for (int k = 0; k < n; k++)
                {
                    linha = read.ReadLine();
                    //vetLinha = Regex.Split(linha, "\n");
                    vetLinha = linha.Split(' ');
                    foreach (var item in vetLinha)
                    {
                        astar.matrizLigacao[k, j] = Convert.ToInt32(item);
                        j++;
                    }
                    j = 0;
                }
            }
        }
    }
}
