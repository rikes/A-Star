namespace IA_Rotas
{
    class Cidade
    {
        private int peso;
        private int pos;
        private Cidade ant;

        public Cidade(int pos)
        {
            this.Peso = 0;
            this.Pos = pos;
            this.Ant = null;
        }

        public int Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public int Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        internal Cidade Ant
        {
            get { return ant; }
            set { ant = value; }
        }
    }
}