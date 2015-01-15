using System.Collections.Generic;
using System.Linq;

namespace Workshop.Golf__day3_
{
    public class GroupNonConsecutive: IOrganiseGroups
    {
         private PlayingGroup _playingGroup;

        private readonly List<PlayingGroup> _playingGroups = new List<PlayingGroup>();


        public List<PlayingGroup> Organise(int[] que)
        {
            var playingQue = que.ToList();

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
                        if (que[(i + 1)] == 0) continue;

//                        while ((i + 1) < que.Length && group + que[(i + 1)] <= 4)
//                        {
//                            if (que[(i + 1)] == 0) continue;
//                            group += que[(quePosition + 1)];
//                            quePosition++;
//                            i++;
//
//                            if (group == 4)
//                            {
//                                que[i] = 0; 
//                                
//                                break;
//                            }
//                        }

                        var index = playingQue.FindIndex(g => g.Equals(4 - playingQue[i]));
                        if (index != null)
                        {
                            group += que[index];
                            que[index] = 0;
                            break;
                        }

                            CreateNewGroup(group);


                        
                        
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
