namespace Workshop
{
    public class Square
    {
        private readonly decimal _side;

        public Square(decimal side)
        {
            _side = side;
        }

        public decimal Perimeter
        {
            get { return (_side*4); }
        }

        public decimal Area
        {
            get { return (_side *_side); }
        }
    }
}