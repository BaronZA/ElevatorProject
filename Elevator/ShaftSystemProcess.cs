using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator
{
    public class ShaftSystemProcess
    {
        private ShaftSystem _shaftSystem;

        public ShaftSystemProcess(ShaftSystem shaftSystem)
        {
            _shaftSystem = shaftSystem;
        }

        // Check for elevator with the least movement, and closest after finish
        public void CallSoonestElevator(List<Person> people, int callingFloor)
        {
            Elevator elevatorToCall;

            int min = _shaftSystem.Elevators.Min(t => t.FloorMovement.Count());

            var elevatorsMinMovement = _shaftSystem.Elevators.Where(t => t.FloorMovement.Count() == min);

            if (elevatorsMinMovement.Count() > 1 && elevatorsMinMovement.Any(t => t.FloorMovement.Count() != 0))
            {
                elevatorToCall = elevatorsMinMovement.OrderBy(t => Math.Abs(callingFloor - t.FloorMovement.Last())).First();
            }
            else
            {
                elevatorToCall = elevatorsMinMovement.First();
            }

            elevatorToCall.PendingPassengers.AddRange(people);
            elevatorToCall.AddUniqueFloorMovement(callingFloor);
        }
    }
}
