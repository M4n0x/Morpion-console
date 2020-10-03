using System;
using System.Linq;
using System.Text;

namespace Morpion
{
    class Render
    {
        private Morpion m;

        public Render(Morpion m)
        {
            this.m = m;
        }

        public void DrawField()
        {
            Console.WriteLine();
            for (int x = 0; x < m.dim; x++)
            {
                StringBuilder sb = new StringBuilder();

                for (int y = 0; y < m.dim; y++)
                {
                    sb.Append((y==0) ? "  " : "  |  ");
                    sb.Append((m[x, y] != null) ? m[x, y].ToString() : " ");
                }

                Console.WriteLine(sb);
                if (x < m.dim-1) Console.WriteLine(String.Join("", Enumerable.Repeat("-----+", m.dim - 1).Append("-----")));
            }
            Console.WriteLine();
        }
    }
}
