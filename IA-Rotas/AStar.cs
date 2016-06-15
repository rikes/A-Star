using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Rotas
{
    /*A ideia é usar os principios de matriz de adjacencia e busca em profundidade, muito utilizada em grafos*/
    class AStar
    {

        public int[,] matrizDistancia { get; set; } //Distancia real  -Primeira matriz
        public int[,] matrizLigacao { get; set; } //Se ha distancia... - Segunda matriz
        public int tam { get; set; } //Tamanho matriz

        //Cidades auxiliares*
        Cidade fisrtCidade;
        Cidade finishCidade;
        Cidade actualCidade;

        /*A navegação será usando listas do tipo List
        Onde o temos as cidades vizinhas, as anteriores que já foram visitadas
        e as que não foram visitadas */
        List<Cidade> vizinhos, anteriores, desconhecidos;

        /* Inicializo as variaveis necessárias*/
        public AStar()
        {
            this.vizinhos = new List<Cidade>();
            this.anteriores = new List<Cidade>();
            this.desconhecidos = new List<Cidade>();

        }


        public void percorreCaminho(int origem, int fim)
        {
            setLista(origem, fim);

            //Percorre todas as cidades até a atual(q inicialmente é a primeira)
            while (finishCidade != actualCidade)
            {
                anteriores.Add(actualCidade);
                vizinhos.Remove(actualCidade);
                setVizinhos(actualCidade.Pos);
                actualCidade = proximaCidade();
                if (actualCidade == null)
                    throw new Exception("Não há caminho para esta cidade 2");
            }
            //Função retorna caminho
            retornaCaminho(finishCidade, finishCidade.Peso);
        }

        /*Inicializ~ção
        Adicionado um id com valores de 0 até quantidade de cidades
         recendo como para metro o caminho a ser percorrido*/
        private void setLista(int origem, int fim)
        {
            //this.fisrtCidade = getCidade(desconhecidos, origem);
            //this.desconhecidos.RemoveAt(origem);
            //this.actualCidade = fisrtCidade;

            for (int i = 0; i < tam; i++)
                this.desconhecidos.Add(new Cidade(i));

            //Recuperando a cidade inicial e final, a cidade recebida será a cidade inicial do percurso
            this.fisrtCidade = getCidade(desconhecidos, origem);
            this.finishCidade = getCidade(desconhecidos, fim);
            this.desconhecidos.RemoveAt(origem);
            actualCidade = fisrtCidade;

        }


        //Imprime o caminho e a distancia entre eles
        private void retornaCaminho(Cidade finishCidade, int peso)
        {
            string caminho = "";
            int[] pesos = new int[tam];
            int i = 0;
            while (finishCidade != null)
            {
                caminho = finishCidade.Pos + " - " + caminho;
                finishCidade = finishCidade.Ant;

            }
            Console.WriteLine("Cidades percorridas: {0} ", caminho);
            Console.WriteLine("Menor Distancia: {0} ", peso);
        }


        //Verica qual a próxima cidade com a menor distância
        private Cidade proximaCidade()
        {
            int menor = 0;
            int aux = 0;
            Cidade proxCidade;

            if (vizinhos == null)
                throw new Exception("Não há caminho para esta cidade");

            proxCidade = vizinhos[0];
            menor = proxCidade.Peso + matrizDistancia[proxCidade.Pos, finishCidade.Pos];
            /*Percorre os vizinhos
            Verificando se a cidade atual tem distancia menor*/
            foreach (var atual in vizinhos)
            {
                aux = matrizDistancia[atual.Pos, finishCidade.Pos];
                if ((atual.Peso + aux) < menor)
                {
                    menor = atual.Peso + aux;
                    proxCidade = atual;
                }
            }
            return proxCidade;
        }
        
        //Metodo que fará a inserção na lista
        private void setVizinhos(int pos)
        {
            Cidade aux;
            int peso = 0;
            //Percorre conforme a quantidade de cidades
            for (int i = 0; i < this.tam; i++)
            {
                //Pega somente cidades vizinhas
                if (matrizLigacao[pos, i] > 1)
                {
                    aux = getCidade(desconhecidos, i);
                    peso = matrizLigacao[pos, i] + actualCidade.Peso;
                    if (aux != null && !anteriores.Contains(aux))
                    {
                        aux.Peso = peso;
                        aux.Ant = actualCidade;
                        vizinhos.Add(aux);
                        desconhecidos.Remove(aux);
                    }
                    else
                    {
                        aux = getCidade(vizinhos, i);
                        if (aux != null)
                        {
                            if (aux.Peso > peso)
                            {
                                aux.Peso = peso;
                                aux.Ant = actualCidade;
                            }
                        }
                    }

                }
            }

        }
        
        //Retorna a cidade desejada
        private Cidade getCidade(List<Cidade> lista, int pos)
        {
            var item =  lista.Where(atual => atual.Pos == pos);
            foreach (var aux in item)
            {
                return aux;
            }
            return null;
        }
    }
}
