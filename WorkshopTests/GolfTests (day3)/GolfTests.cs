using NUnit.Framework;
using Workshop;
using Workshop.Golf__day3_;

namespace WorkshopTests
{
    class GolfTests
    {
        [TestCase(new[] { 4 }, 1, "1")]
        [TestCase(new[] { 4, 3 }, 2, "2")]
        [TestCase(new[] { 4, 3, 4 }, 3, "3")]
        [TestCase(new[] { 4, 1, 4 }, 3, "4")]
        [TestCase(new[] { 4, 1, 4, 2 }, 4, "5")]
        [TestCase(new[] { 4, 1, 2, 2 }, 3, "6")]
        [TestCase(new[] { 1, 1, 1, 1 }, 1, "7")]
        [TestCase(new[] { 1, 2, 3, 4, 4, 2, 2, 1, 1 }, 6, "8")]
        [TestCase(new[] { 1 }, 1, "9")]
        public void Should_CountTheAmountOfAllowedGroups_From_Que(int[] que, int count, string name)
        {
            var players = new Que(que, new GroupEfficiently());
            var result = players.Organise();
            Assert.That(result.Count, Is.EqualTo(count));
        }

        [TestCase(new[] { 4, 3 }, 2, "1")]
        [TestCase(new[] { 4, 3, 4 }, 3, "2")]
        [TestCase(new[] { 4, 1, 4 }, 3, "3")]
        [TestCase(new[] { 4, 1, 4, 2 }, 3, "4")]
        [TestCase(new[] { 4, 1, 2, 2 }, 3, "5")]
        [TestCase(new[] { 1, 1, 1, 1 }, 1, "6")]
        [TestCase(new[] { 1, 2, 3, 4, 4, 2, 2, 1, 1 }, 5, "7")]
        [TestCase(new[] { 1, 2 }, 1, "8")]
        [TestCase(new[] { 4, 4 }, 2, "9")]
        [TestCase(new[] { 4, 4, 1 }, 3, "10")]
        [TestCase(new[] { 1, 2, 3, 4, 4, 2, 2, 1, 1, 3 }, 6, "11")]
        [TestCase(new[] { 1, 2, 3, 4, 4, 2, 2, 1, 1, 3, 2 }, 7, "12")]
        [TestCase(new[] { 1, 1, 1 }, 1, "13")]
        [TestCase(new[] { 1, 7, 1 }, 3, "13")]


        public void Should_CountTheAmountOfAllowedPlayingGroups_From_Que_When_PlayersAreGroupedInFours(int[] que, int count, string name)
        {
            var players = new Que(que, new GroupMaximiser());
            var result = players.Organise();
            Assert.That(result.Count, Is.EqualTo(count));
        }

        [TestCase(new[] { 1, 7, 1 }, 3, "13")]


        public void AShould_CountTheAmountOfAllowedPlayingGroups_From_Que_When_PlayersAreGroupedInFours(int[] que, int count, string name)
        {
            var players = new GroupMaximiser();
            var result = players.Organise(que);
            Assert.That(result.Count, Is.EqualTo(count));
        }

        [TestCase(new[] { 1, 4, 1 }, 2, "1")]
        [TestCase(new[] { 3, 3, 3, 1 }, 3, "2")]
        public void Should_ReturnListWith_When_OrganiseIsEnvoked(int[] que, int count, string name)
        {
            var players = new GroupNonConsecutive();
            var result = players.Organise(que);
            Assert.That(result.Count, Is.EqualTo(count));
        }

        [Test]
        public void Should_ReturnAListContaining433_When_OrganiseIsEnvokedWith3331()
        {
            var players = new GroupNonConsecutive();
            var result = players.Organise(new []{ 3, 3, 3, 1});
//            Assert.That(result[0].Members, Is.EqualTo(4));
//            Assert.That(result[1].Members, Is.EqualTo(3));
//            Assert.That(result[2].Members, Is.EqualTo(3));

            Assert.That(result.Count, Is.EqualTo(3));
        }

    }
}
