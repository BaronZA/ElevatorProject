using System.Linq;

namespace Elevator
{
    public class ElevatorProcess
    {
        private Elevator _elevator { get; set; }

        public ElevatorProcess(Elevator elevator)
        {
            _elevator = elevator;    
        }

        public void ArriveAtNextFloor()
        {
            // Previous floor removed, now first element is current floor
            if (_elevator.FloorMovement.Count > 1)
                _elevator.FloorMovement.RemoveAt(0);

            // Remove people in elevator that wanted to go to current floor
            var peopleAtRightFloor = _elevator.PeopleInElevator.Where(t => t.DestinationFloor == _elevator.CurrentFloor).ToList();

            foreach (var person in peopleAtRightFloor)
            {
                _elevator.PeopleInElevator.Remove(person);
            }

            // Add pending people at this floor *****Check capacity
            var pendingPeopleForFloor = _elevator.PendingPassengers.Where(p => p.CallingFloor == _elevator.CurrentFloor);

            // Add pending people
            _elevator.PeopleInElevator.AddRange(pendingPeopleForFloor);

            // Add floors to series if they aren't already one of the destinations
            foreach (var newPassengers in pendingPeopleForFloor)
            {
                _elevator.AddUniqueFloorMovement(newPassengers.DestinationFloor);
            }

            // Remove passengers that boarded
            _elevator.PendingPassengers.RemoveAll(p => p.CallingFloor == _elevator.CurrentFloor);
        }
    }
}
