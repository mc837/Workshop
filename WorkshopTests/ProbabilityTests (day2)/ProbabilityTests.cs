using NUnit.Framework;
using Workshop;

namespace WorkshopTests
{
    public class ProbabilityTests
    {
        [Test]
        public void Should_CompareIfTwoProbabilitiesAreSame()
        {
            var probability1 = new Probability(0.5);
            var probability2 = new Probability(0.5);

            Assert.That(probability1, Is.EqualTo(probability2));
        }

        [Test]
        public void Should_StateInverseProbability_Of_AStatedProbability()
        {
            var probability = new Probability(0.25);
            var inverseProbability = probability.InversedProbability;
            var expectedInverseProbability = new Probability(0.75);

            Assert.True(inverseProbability.Equals(expectedInverseProbability));
        }

        [Test]
        public void Should_CalculateCombinedProbabilityForTwoOdds()
        {
            var expectedProbability = new Probability(0.25);

            var probability1 = new Probability(0.5);
            var probability2 = new Probability(0.5);

            var combinedProbability = probability1.And(probability2);

            Assert.True(combinedProbability.Equals(expectedProbability));
        }


        [Test]
        public void Should_CalculateProbabilityForEitherOutcomeToOccur_WhenTwoProbabilitiesArePossible()
        {
            var expectedProbability = new Probability(0.55);
            var probability1 = new Probability(0.4);
            var probability2 = new Probability(0.25); ;
            var resultingProbability = probability1.Or(probability2);
            Assert.That(resultingProbability.Equals(expectedProbability));
        }
    }
}

