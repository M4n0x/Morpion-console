namespace Morpion
{
    class Player
    {
        private char symb { get; set; } = ' ';
        public int victory { get; set; } = 0;

        public Player(char symb)
        {
            this.symb = symb;
        }

        public override string ToString()
        {
            return symb.ToString();
        }
    }
}
