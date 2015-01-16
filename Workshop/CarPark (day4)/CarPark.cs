using System.Collections.Generic;
using System.Linq;

namespace Workshop
{
    public class CarPark
    {
        private int _spaces;
        public readonly Dictionary<int, Car> CarSpaces = new Dictionary<int, Car>();
        private int _nextAvailableSpaceId;

        public CarPark(int spaces)
        {
            _spaces = spaces;

            for (var i = 0; i < _spaces; i++)
            {
                CarSpaces.Add(i, null);
            }
        }

        public string SpacesLeft()
        {
            return _spaces <= 0 ? "Full" : "Not Full";
        }

        public Ticket AddCarToSpace(Car car)
        {
            CarSpaces[_nextAvailableSpaceId] = car;
            _spaces -= 1;
            var ticket = new Ticket(_nextAvailableSpaceId);
            FindNextAvailableSpace();
            return ticket;
        }

        public Car RetrieveFromSpace(int carSpaceId)
        {
            var car = CarSpaces[carSpaceId];
            CarSpaces[carSpaceId] = null;
            _spaces = +1;
            FindNextAvailableSpace();

            return car;
        }

        private void FindNextAvailableSpace()
        {
            if (_spaces != 0)
            {
                _nextAvailableSpaceId = CarSpaces.First(s => s.Value == null).Key;
            }
        }

        public class Ticket
        {
            public readonly int SpaceId;

            //internal constructor allows property to only be set within class / parent class. 
            //object is still publicly available.
            internal Ticket(int spaceId)
            {
                SpaceId = spaceId;
            }

            public override bool Equals(object obj)
            {
                if (obj.GetType() != typeof(Ticket)) return false;
                var ticket = obj as Ticket;
                return SpaceId.Equals(ticket.SpaceId);
            }
        }
    }
}