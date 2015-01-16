namespace Workshop
{
    public class Car
    {
        public string Reg { private get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Car)) return false;
            var car = obj as Car;
            return Reg.Equals(car.Reg);
        }
    }
}