using System;
using Xunit;
using Elevator;

namespace ElevatorTests
{
    public class ElevatorTest
    {
        [Fact]
        public void TestStatusNotMoving()
        {
            var elevator = new Elevator.Elevator(1);

            Assert.Equal(ElevatorStatus.NotMoving, elevator.Status);
        }

        [Fact]
        public void TestStatusMovingUp()
        {
            var elevator = new Elevator.Elevator(1);

            elevator.AddUniqueFloorMovement(3);

            Assert.Equal(ElevatorStatus.MovingUp, elevator.Status);
        }

        [Fact]
        public void TestStatusDown()
        {
            var elevator = new Elevator.Elevator(1, 5);

            elevator.AddUniqueFloorMovement(3);

            Assert.Equal(ElevatorStatus.MovingDown, elevator.Status);
        }

        //[Fact]
        //public void TestArriveAtNextFloor()
        //{
        //    var elevator = new Elevator.Elevator(1, 5);

        //    elevator.AddUniqueFloorMovement(3);

        //    elevator.ArriveAtNextFloor();

        //    Assert.Equal(ElevatorStatus.MovingDown, elevator.Status);
        //}
    }
}
