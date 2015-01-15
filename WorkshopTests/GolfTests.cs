using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WorkshopTests.Annotations;

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
            var players = new Que(que);
            var result = players.OrganiseEfficientGroups();
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

        public void Should_CountTheAmountOfAllowedPlayingGroups_From_Que_When_PlayersAreGroupedInFours(int[] que, int count, string name)
        {
            var players = new Que(que);
            var result = players.OrganiseMaxGroups();
            Assert.That(result.Count, Is.EqualTo(count));
        }
    }

    internal class Que
    {
        private readonly int[] _que;
        private PlayingGroup _playingGroup;
        private readonly List<PlayingGroup> _playingGroups = new List<PlayingGroup>();

        public Que(int[] que)
        {
            _que = que;
        }

        public List<PlayingGroup> OrganiseEfficientGroups()
        {
            for (var quePosition = 0; quePosition < _que.Length; quePosition++)
            {
                var group = _que[quePosition];

                if (group == 4)
                {
                    CreateNewGroup(group);
                }
                else
                {
                    var i = quePosition;
                    while ((i + 1) < _que.Length)
                    {
                        while ((i + 1) < _que.Length && group + _que[(i + 1)] <= 4)
                        {
                            group += _que[(quePosition + 1)];
                            quePosition++;
                            i++;
                        }
                        break;
                    }
                    CreateNewGroup(group);
                }

            } return _playingGroups;
        }


        public List<PlayingGroup> OrganiseMaxGroups()
        {
            var totalPlayers = _que.Sum();
            if (totalPlayers <= 4)
            {
                CreateNewGroup(totalPlayers);
            }
            else
            {
                var fullGroups = (totalPlayers / 4);
                var nonFullGroup = (totalPlayers%4);
                while(fullGroups > 0)
                {
                    CreateNewGroup(4);
                    fullGroups = (fullGroups - 1);
                }

                if (nonFullGroup != 0)
                {
                    CreateNewGroup(nonFullGroup);
                }
            }
            return _playingGroups;
        }

        private void CreateNewGroup(int groupNumber)
        {
            _playingGroup = new PlayingGroup { Members = groupNumber };
            AddGroupToList(_playingGroup);
        }

        private void AddGroupToList(PlayingGroup group)
        {
            _playingGroups.Add(group);
        }
    }

    internal class PlayingGroup
    {
        public int Members { [UsedImplicitly] private get; set; }
    }
}
