using System.Runtime.InteropServices;
using System.Threading;
using NUnit.Framework;

namespace WorkshopTests
{
    class GolfTests
    {
        [TestCase(new[] { 4 }, 1)]
        [TestCase(new[] { 4, 3, 1 }, 2)]
        [TestCase(new[] { 4, 3, 4 }, 3)]
        public void Should_CountTheAmountOfAllowedGroups_From_Que(int [] que, int count)
        {
            var organiser = new PlayerOrganiser(que);
            var result = organiser.Organise();
            Assert.That(result.Count, Is.EqualTo(count));
        }
    }

    internal class PlayerOrganiser
    {
        private readonly int[] _que;

        public PlayerOrganiser(int[] que)
        {
            _que = que;
        }

        public Que Organise()
        {
            var count = 0;
            for (int quePosition = 0; quePosition < _que.Length; quePosition++)
            {
                var group = _que[quePosition];
                switch (group)
                {
                    case 4:
                        count ++;
                        break;
                    case 3:
                        if (_que[(quePosition + 1)] == 1)
                        {
                            count++;
                            quePosition++;
                        }
                        else
                        {
                            count++;
                        }
                        break;
                }
            }

            return new Que
            {
                Count = count
            };
        }
    }

    internal class Que  
    {
        public int Count { get; set; }
    }
}
