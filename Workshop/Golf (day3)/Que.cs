using System.Collections.Generic;

namespace Workshop
{
    public class Que
    {
        private readonly int[] _que;
        private readonly IOrganiseGroups _groupOrganiser;

        public Que(int[] que, IOrganiseGroups groupOrganiser)
        {
            _que = que;
            _groupOrganiser = groupOrganiser;
        }

        public List<PlayingGroup> Organise()
        {
            return _groupOrganiser.Organise(_que);
        }

        
    }
}
