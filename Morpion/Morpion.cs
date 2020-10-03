using System;

namespace Morpion
{
    class Morpion : ITerminable
    {
        public readonly int dim;
        Player[,] field ;
        Player currPlayer = null;
        Player nextPlayer = null;
        public Player winner { get; private set; } = null;

        public Morpion(Player p1, Player p2, int dim = 3)
        {
            currPlayer = p1;
            nextPlayer = p2;
            field = new Player[dim, dim];
            this.dim = dim;
        }

        public bool IsValid(int x, int y)
        {
            try
            {
                return field[x, y] == null;
            } catch
            {
                return false;
            }
            
        }

        public bool InsertMove(int x, int y)
        {
            if (IsValid(x,y)) {
                field[x, y] = currPlayer;
                (currPlayer, nextPlayer) = (nextPlayer, currPlayer);
                return true;
            } else
            {
                Console.WriteLine("Move not valid !");
            }

            return false;
        }

        /// <summary>
        /// Method used to check a win, can be used with any dimension !
        /// </summary>
        /// <returns> true if the game is finished, false otherwise</returns>
        public bool IsFinished()
        {
            int c = 0, r = 0, d = 0, a = 0, t = 0;
            Player pc, pr, pd = field[0, 0], pa = field[0, dim-1];
            for (int x = 0; x < dim; x++)
            {
                pr = field[x, 0];
                pc = field[0, x];
                if (pd != null && pd == field[x, x]) d++; // check diag win
                
                for (int y = 0; y < dim; y++)
                {
                    if (pr != null && pr == field[x, y]) r++; // check if row win
                    if (pc != null && pc == field[y, x]) c++; // check if col win
                    if (x + y == dim - 1)
                    {
                        if (pa != null && pa == field[x, y]) a++; // check if antidiag win
                    }
                    if (field[x, y] != null) t++;
                }
                if (c >= dim || r >= dim || d >= dim || a >= dim)
                {
                    winner = nextPlayer;
                    winner.victory++;
                    Console.WriteLine($"Player {winner} won ! (victories : {winner.victory})");
                    return true;
                }
                c = 0; r = 0;
            }

            if (t >= (dim * dim)) {
                Console.WriteLine("Draw game !");
                return true;
            }
            return false;
        }

        internal Tuple<int, int> NextMove()
        {
            string val;
            do
            {
                Console.Write($"Player {currPlayer} please enter x,y : ");
                val = Console.ReadLine();

                try
                {
                    if (val.Contains(","))
                    {
                        string[] nums = val.Split(',');

                        return Tuple.Create(int.Parse(nums[1]), int.Parse(nums[0]));
                    } else
                    {
                        throw new Exception("Wrong coordinates format");
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            } while (true);
        }

        internal bool doRestart()
        {
            string val;
            do
            {
                Console.Write($"Do you want to restart ? [Y]es or [N]o : ");
                val = Console.ReadLine();

                val = val.ToLower();

                if (val.Equals("n")) return false;
                if (val.Equals("y"))
                {
                    this.winner = null;
                    this.field = new Player[dim, dim];
                    return true;
                }

            } while (true);
        }

        public Player this[int x, int y]
        {
            get { return field[x, y]; }
        }
    }
}
