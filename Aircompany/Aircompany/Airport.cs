using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public IEnumerable<Plane> Planes { get; set; }

        public IEnumerable<PassengerPlane> GetPassengersPlanes()
        {
            return Planes.OfType<PassengerPlane>();
        }

        public IEnumerable<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.OfType<MilitaryPlane>();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().OrderBy(x => x.PassengersCapacity).Last();
        }

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(plane => plane.Type == MilitaryTypes.Transport);
        }
        public Airport SortByMaxDistance()
        {
            return new Airport
            {
                Planes = Planes.OrderBy(w => w.MaxFlightDistance),
            };
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport
            {
                Planes = Planes.OrderBy(w => w.MaxSpeed)
            };
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport
            {
                Planes = Planes.OrderBy(w => w.MaxLoadCapacity)
            };
        }

        public override string ToString()
        {
            var planesString = string.Join(", ", Planes.Select(x => x.Model));
            return $"Airport{{planes={planesString}}}";
        }
    }
}
