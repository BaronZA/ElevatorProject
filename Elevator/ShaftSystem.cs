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
            Elevators.ForEach(t => new ElevatorProcess(t).ArriveAtNextFloor());
        }
    }
}