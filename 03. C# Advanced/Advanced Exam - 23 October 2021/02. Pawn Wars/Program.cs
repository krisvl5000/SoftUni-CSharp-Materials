using System;

namespace _01._Hello_Softuni
{
    class Pawn
    {
        public Pawn((int, int) coordinates, string colour)
        {
            Row = coordinates.Item1;
            Col = coordinates.Item2;
            Colour = colour;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public string Colour { get; set; }
    }

    internal class Program
    {
        const int n = 8;

        static void Main(string[] args)
        {

            char[,] board = new char[n, n];

            for (int row1 = 0; row1 < n; row1++)
            {
                string line = Console.ReadLine();
                for (int col1 = 0; col1 < n; col1++)
                {
                    board[row1, col1] = line[col1];
                }
            }
            
            Pawn white = new Pawn(GetPawnPostion(board, 'w'), "White");
            Pawn black = new Pawn(GetPawnPostion(board, 'b'), "Black");


            while (true)
            {
                if (black.Row == white.Row - 1 &&
                    (black.Col == white.Col - 1 ||
                     black.Col == white.Col + 1))
                {
                    white.Row = black.Row;
                    white.Col = black.Col;
                    PrintResult(white, false);
                    break;
                }
                else if (--white.Row == 0)
                {
                    PrintResult(white, true);
                    break;
                }

                if (white.Row == black.Row + 1 &&
                   (white.Col == black.Col - 1 ||
                    white.Col == black.Col + 1))
                {
                    black.Row = white.Row;
                    black.Col = white.Col;
                    PrintResult(black, false);
                    break;
                }
                else if (++black.Row == 7)
                {
                    PrintResult(black, true);
                    break;
                }
            }
        }

        private static void PrintResult(Pawn winner, bool promoted)
        {
            string coordinates = (char)('a' + winner.Col) + (8 - winner.Row).ToString();

            if (promoted)
            {
                Console.WriteLine($"Game over! {winner.Colour} pawn is promoted to a " +
                    $"queen at {coordinates}.");
            }
            else
            {
                Console.WriteLine($"Game over! {winner.Colour} capture on " +
                    $"{coordinates}.");
            }
        }

        static (int, int) GetPawnPostion(char[,] board, char colour)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (board[row, col] == colour)
                    {
                        return (row, col);
                    }
                }
            }

            return (n, n);
        }
    }
}