using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Rotas
{
    class Program
    {
        static void Main(string[] args)
        {
            Leitura leitura = new Leitura("rotas.txt");
            AStar astar;
            astar = leitura.Astar;
            int origem,fim;

            Console.WriteLine("Digite sua origem (de 0 ate {0} ):", astar.tam-1);
            origem = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Digite o fim (de 0 ate {0} ):", astar.tam-1);
            fim = Convert.ToInt32(Console.ReadLine());

            astar.percorreCaminho(origem,fim);
            Console.ReadKey();


            /*Um bom exemplo é de 0 a 2
             Seria 0 - 3 - 2
             99 + 55 = 154
             */
        }
    }
}
