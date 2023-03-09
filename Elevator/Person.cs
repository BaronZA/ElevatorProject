namespace Elevator
{
    public class Person
    {
        public Person(int callingFloor, int destinationFloor)
        {
            CallingFloor = callingFloor;
            DestinationFloor = destinationFloor;
        }

        public int CallingFloor { get; set; }
        public int DestinationFloor { get; set; }
    }
}
