using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player('X');
            Player p2 = new Player('O');

            Morpion m = new Morpion(p1, p2, 3); // check the dim of the board it'll work with any dimension between (min 3) !

            Render r = new Render(m);

            while (!m.IsFinished() || m.doRestart())
            {
                var (x, y) = m.NextMove();
                if (m.InsertMove(x, y))
                    r.DrawField();
            }
        }
    }
}
