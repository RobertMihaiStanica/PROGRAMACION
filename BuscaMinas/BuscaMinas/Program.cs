namespace BuscaMinas
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard(9,15,1);
            board.GameStart();
            //board.SetDimensions(9,9);
            //board.SetMines(5);
            //board.SetTreasure(1);
            //board.GenerateBoard();
            //board.PlaceItems(board.GetMines(),"[M]");
            //board.PlaceItems(board.GetTreasure(), "[T]");
            //board.Navigation();
        }
    }
}