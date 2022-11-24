namespace BuscaMinas
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard();
            board.SetDimensions(9,9);
            board.GenerateBoard();
            board.Navigation();
        }
    }
}