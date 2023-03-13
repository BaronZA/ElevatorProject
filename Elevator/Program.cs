using System;
using System.Collections.Generic;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elevatorCount = 0;
            bool validElevatorCount = false;

            while (!validElevatorCount)
            {
                Console.WriteLine("Enter Amount of Elevators: ");
                var elevatrorCountInput = Console.ReadLine();

                validElevatorCount = int.TryParse(elevatrorCountInput, out elevatorCount);
            }

            var shaftSystem = new ShaftSystem(elevatorCount);

            int timeTick = 0;

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                Console.Clear();

                Console.WriteLine($"App Running - Tick: {timeTick++}. (Press [Esc] to quit)");
                Console.WriteLine();

                shaftSystem.RenderElevatorStatuses();

                bool enterNewPeople = true;

                while (enterNewPeople)
                {
                    string answer = "";
                    bool validAnswer = false;
                    int callingFloor = 0;
                    bool validCallingFloor = false;
                    int amountOfPeople = 0;
                    bool validAmountOfPeople = false;


                    while (!validAnswer)
                    {
                        Console.WriteLine("Would you like to call the elevator? (Y/N)");
                        answer = Console.ReadLine().ToUpper();

                        validAnswer = answer == "Y" || answer == "N";
                    }

                    if (answer == "N")
                    {
                        enterNewPeople = false;
                    }
                    else if (answer == "Y")
                    {
                        List<Person> people = new List<Person>();

                        while (!validCallingFloor)
                        {
                            Console.WriteLine("Enter which floor elevator is being called from: ");
                            var callingFloorInput = Console.ReadLine();

                            validCallingFloor = int.TryParse(callingFloorInput, out callingFloor);
                        }

                        while (!validAmountOfPeople)
                        {
                            Console.WriteLine("How many people: ");
                            var amountOfPeopleInput = Console.ReadLine();

                            validAmountOfPeople = int.TryParse(amountOfPeopleInput, out amountOfPeople);
                        }

                        for (int i = 1; i < amountOfPeople + 1; i++)
                        {
                            int destinationFloor = 0;
                            bool validDestinationFloor = false;

                            while (!validDestinationFloor)
                            {
                                Console.WriteLine($"Enter destination floor for person {i}: ");
                                var destinationFloorInput = Console.ReadLine();

                                validDestinationFloor = int.TryParse(destinationFloorInput, out destinationFloor);
                            }

                            people.Add(new Person(callingFloor, destinationFloor));
                        }

                        var shaftProcess = new ShaftSystemProcess(shaftSystem);
                        shaftProcess.CallSoonestElevator(people, callingFloor);
                    }
                }

                //Tick happens whenever user chooses not to add button presses
                shaftSystem.TimeTick();
            }
        }
    }
}
