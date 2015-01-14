using System.Collections.Generic;
using NUnit.Framework;

namespace WorkshopTests
{
    class GolfTests
    {
        //[TestCase(new[] { 4 }, 1)]
        [TestCase(new[] { 4, 3 }, 2)]
        [TestCase(new[] { 4, 3, 4 }, 3)]
        [TestCase(new[] { 4, 1, 4 }, 3)]
        [TestCase(new[] { 4, 1, 4, 2 }, 4)]
        [TestCase(new[] { 4, 1, 2, 2 }, 3)]
        [TestCase(new[] { 1, 1, 1, 1 }, 1)]
        [TestCase(new[] { 1, 2, 3, 4, 4, 2, 2, 1, 1 }, 6)]
        public void Should_CountTheAmountOfAllowedGroups_From_Que(int[] que, int count)
        {
            var organiser = new Que(que);
            var result = organiser.Organise();
            Assert.That(result.Count, Is.EqualTo(count));
        }
    }

    internal class Que
    {
        private readonly int[] _que;
        private PlayingGroup _playingGroup;
        private List<PlayingGroup> playingGroups = new List<PlayingGroup>();

        public Que(int[] que)
        {
            _que = que;
        }

        public List<PlayingGroup> Organise()
        {
            for (int quePosition = 0; quePosition < _que.Length; quePosition++)
            {
                var group = _que[quePosition];

                if (group == 4)
                {
                    CreateNewGroup(group);
                }
                else
                {
                    var pos = quePosition;
                    while ((pos + 1) < _que.Length)
                    {
                        while ((pos + 1) < _que.Length && group + _que[(pos + 1)] <= 4)
                        {
                            group += _que[(quePosition + 1)];
                            quePosition ++;
                            pos++;
                        }
                        break;
                    }
                    CreateNewGroup(group);
                }

            } return playingGroups;
        }

        private void CreateNewGroup(int groupNumber)
        {
            _playingGroup = new PlayingGroup { Members = groupNumber };
            AddGroupToList(_playingGroup);
        }

        private void AddGroupToList(PlayingGroup group)
        {
            playingGroups.Add(_playingGroup);
        }
    }

    internal class PlayingGroup
    {
        public int Members { get; set; }
    }
}
