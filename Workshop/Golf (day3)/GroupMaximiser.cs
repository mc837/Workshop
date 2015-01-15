using System.Collections.Generic;
using System.Linq;

namespace Workshop
{
    public class GroupMaximiser : IOrganiseGroups
    {
        private PlayingGroup _playingGroup;

        private readonly List<PlayingGroup> _playingGroups = new List<PlayingGroup>();


        public List<PlayingGroup> Organise(int [] que)
        {
            var totalPlayers = que.Sum();
            if (totalPlayers <= 4)
            {
                CreateNewGroup(totalPlayers);
            }
            else
            {
                var fullGroups = (totalPlayers / 4);
                var nonFullGroup = (totalPlayers % 4);
                while (fullGroups > 0)
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

}