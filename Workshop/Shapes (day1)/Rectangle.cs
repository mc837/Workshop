namespace Workshop
{
    public class Rectangle
    {
        private readonly decimal _length;
        private readonly decimal _width;

        public Rectangle(decimal length, decimal width)
        {
            _length = length;
            _width = width;
        }

        public decimal Perimeter
        {
            get { return (_length*2) + (_width*2); } 
        }

        public object Area
        {
            get { return (_length * _width); }
        }
    }
}
    