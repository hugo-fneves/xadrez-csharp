namespace tabuleiro
{
    abstract class Peca
    {

        public Posicao Posicao { get; set; }

        public Cor Cor { get; protected set; }
        public int QteMovimento { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab,Cor cor)
        {
            //Quando se cria uma peça, a posição dela é nula
            Posicao = null;
            Tab = tab;
            Cor = cor;         
            //QteMovimento serve para contar quantas vezes foi movida. Útil pro peão no inicio do jogo.
            QteMovimento = 0;
        }      

        public void IncrementarQteMovimentos()
        {
            QteMovimento++;
        }

        public void DecrementarQteMovimentos()
        {
            QteMovimento--;
        }

        //verificar se a peça está bloqueada
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Linhas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
