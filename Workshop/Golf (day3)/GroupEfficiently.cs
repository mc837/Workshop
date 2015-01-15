using System.Collections.Generic;

namespace Workshop.Golf__day3_
{
    public class GroupEfficiently : IOrganiseGroups
    {
        private PlayingGroup _playingGroup;

        private readonly List<PlayingGroup> _playingGroups = new List<PlayingGroup>();

        public List<PlayingGroup> Organise(int [] que)
        {
            for (var quePosition = 0; quePosition < que.Length; quePosition++)
            {
                var group = que[quePosition];

                if (group == 4)
                {
                    CreateNewGroup(group);
                }
                else
                {
                    var i = quePosition;
                    while ((i + 1) < que.Length)
                    {
                        while ((i + 1) < que.Length && group + que[(i + 1)] <= 4)
                        {
                            group += que[(quePosition + 1)];
                            quePosition++;
                            i++;
                        }
                        break;
                    }
                    CreateNewGroup(group);
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
