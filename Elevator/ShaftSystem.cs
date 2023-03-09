using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator
{
    public class ShaftSystem
    {
        public ShaftSystem(int elevatorCount)
        {
            for(int i = 1; i < elevatorCount + 1; i++)
            {
                Elevators.Add(new Elevator(i));
            }
        }

        public List<Elevator> Elevators { get; set; } = new List<Elevator>();

        // Check for elevator with the least movement, and closest after finish
        public void CallSoonestElevator(List<Person> people, int callingFloor)
        {
            Elevator elevatorToCall;

            int min = Elevators.Min(t => t.FloorMovement.Count());

            var elevatorsMinMovement = Elevators.Where(t => t.FloorMovement.Count() == min);

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

        public void RenderElevatorStatuses()
        {
            foreach (var elevator in Elevators)
            {
                Console.WriteLine(elevator.ToString());
            }
        }

        // Assume the movement of elevators to next destination is the tick
        public void TimeTick()
        {
            Elevators.ForEach(t => t.ArriveAtNextFloor());
        }
    }
}