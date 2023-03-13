using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator
{
    public class Elevator
    {
        /// <summary>
        /// Contructor allowing to create new Elevators with optional random floors, and person limit
        /// </summary>
        /// <param name="elevatorId">ID or Elevator Number</param>
        /// <param name="randomFloorSeed">Set to true to seed new elevator with a random floor</param>
        /// <param name="personLimit">Set person limit</param>
        public Elevator(int elevatorId, int startingFloor = 0, bool randomFloorSeed = false, int personLimit = 8)
        {
            ElevatorId = elevatorId;

            FloorMovement.Add(startingFloor);

            if (randomFloorSeed)
            {
                Random random = new Random();
                var randomFloor = random.Next(1,10);

                FloorMovement[0] = randomFloor;
            }

            

            PersonLimit = personLimit;
        }

        public int ElevatorId { get; set; }

        public List<int> FloorMovement { get; set; } = new List<int>();


        public int CurrentFloor 
        { 
            get
            {
                if (FloorMovement.Count == 0)
                    return 0;
                return FloorMovement[0];
            }
        }

        public int NextFloor 
        {
            get 
            { 
                if(FloorMovement.Count > 1)
                    return FloorMovement[1];
                return CurrentFloor;
            } 
        }

        public List<Person> PeopleInElevator { get; set; } = new List<Person>();

        public List<Person> PendingPassengers { get; set; } = new List<Person>();

        public int PersonLimit { get; set; }

        public ElevatorStatus Status { get {
                if (FloorMovement.Count > 1 && NextFloor > CurrentFloor)
                    return ElevatorStatus.MovingUp;
                if (FloorMovement.Count > 1 && NextFloor < CurrentFloor)
                    return ElevatorStatus.MovingDown;
                return ElevatorStatus.NotMoving;
            } }

        public void AddUniqueFloorMovement(int destinationFloor)
        {
            if (!FloorMovement.Contains(destinationFloor))
                FloorMovement.Add(destinationFloor);
        }

        public override string ToString()
        {
            return $"Elevator: {ElevatorId} | CurrentFloor: {CurrentFloor} | NextFloor: {NextFloor} | Passengers: {PeopleInElevator.Count} | Status: {Status}";
        }
    }
}
