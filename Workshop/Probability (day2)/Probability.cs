namespace Workshop
{
    public class Probability
    {
        private readonly double _odds;

        public Probability(double odds)
        {
            _odds = odds;
        }
        public Probability InversedProbability
        {
            get { return new Probability(1 - _odds); }
        }

        public Probability And(Probability probability)
        {
            return new Probability(probability._odds * _odds);
        }

        public Probability Or(Probability probability)
        {
            return InversedProbability.And(probability.InversedProbability).InversedProbability;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Probability)) return false;
            var probability = obj as Probability;
            return _odds.Equals(probability._odds);
        }
    }
}