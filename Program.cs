using System;

namespace Program
{
    class Automobile
    {
        private string name;
        private int maxSpeed;

        public Automobile(string name, int maxSpeed)
        {
            this.name = name;
            this.maxSpeed = maxSpeed;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value == "")
                {
                    Console.WriteLine("Error");
                }
                name = value;
            }
        }

        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error");
                }
                maxSpeed = value;
            }
        }

        public virtual void PrintAutomobile()
        {
            Console.WriteLine($"The name of the car is {name}");
            Console.WriteLine($"Maximum speed - {maxSpeed}");
        }

    }

    class Car : Automobile
    {
        private int numberOfSeatsForPassengers;

        public Car(string name, int maxSpeed, int numberOfSeatsForPassengers) : base(name, maxSpeed)
        {
            this.numberOfSeatsForPassengers = numberOfSeatsForPassengers;
        }

        public int NumberOfSeatsForPassengers
        {
            get
            {
                return numberOfSeatsForPassengers;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error");
                }
                numberOfSeatsForPassengers = value;
            }
        }

        public override void PrintAutomobile()
        {
            Console.WriteLine($"The name of the car is {Name}");
            Console.WriteLine($"Maximum speed - {MaxSpeed}");
            Console.WriteLine($"Number of seats for passengers - {numberOfSeatsForPassengers}");
        }
    }

    class Vehicle : Automobile
    {
        private int maximumCargoWeight;

        public Vehicle(string name, int maxSpeed, int maximumCargoWeight) : base(name, maxSpeed)
        {
            this.maximumCargoWeight = maximumCargoWeight;
        }

        public int MaximumCargoWeight
        {
            get
            {
                return maximumCargoWeight;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error");
                }
                maximumCargoWeight = value;
            }
        }

        public override void PrintAutomobile()
        {
            Console.WriteLine($"The name of the car is {Name}");
            Console.WriteLine($"Maximum speed - {MaxSpeed}");
            Console.WriteLine($"Maximum cargo weight - {maximumCargoWeight}");
        }
    }
    class Program
    {
        public static Car InputCar()
        {
            string name;
            int maxSpeed, numberOfSeatsForPassengers;

            do
            {
                Console.Write("Enter car name: ");
                name = Console.ReadLine();
            } while (name == "");
            do
            {
                Console.Write($"Enter the speed {name}: ");
                maxSpeed = Convert.ToInt32(Console.ReadLine());
            } while (maxSpeed < 0);

            do
            {
                Console.Write($"Enter the number of seats for passengers {name}: ");
                numberOfSeatsForPassengers = Convert.ToInt32(Console.ReadLine());
            } while (numberOfSeatsForPassengers < 0);

            return new Car(name, maxSpeed, numberOfSeatsForPassengers);
        }

        public static Vehicle InputVehicle()
        {
            string name;
            int maxSpeed, maximumCargoWeight;

            do
            {
                Console.Write("Enter vehicle name: ");
                name = Console.ReadLine();
            } while (name == "");

            do
            {
                Console.Write($"Enter the speed {name}: ");
                maxSpeed = Convert.ToInt32(Console.ReadLine());
            } while (maxSpeed < 0);

            do
            {
                Console.Write("Enter the number of maximum cargo weight: ");
                maximumCargoWeight = Convert.ToInt32(Console.ReadLine());
            } while (maximumCargoWeight < 0);

            Vehicle vehicle = new Vehicle(name, maxSpeed, maximumCargoWeight);

            return vehicle;
        }

        public static void InformationAboutTheFastestAutomobile(Automobile automobile)
        {
            Console.WriteLine("Information about the fastest automobile.");
            automobile.PrintAutomobile();
        }

        public static void Main() 
        {
            Automobile[] automobiles = new Automobile[2];
            automobiles[0] = InputCar();
            Console.WriteLine();
            automobiles[1] = InputVehicle();
            Console.WriteLine("\n");

            if (automobiles[0].MaxSpeed > automobiles[1].MaxSpeed)
            {
                InformationAboutTheFastestAutomobile(automobiles[0]);
            }
            else if (automobiles[0].MaxSpeed < automobiles[1].MaxSpeed)
            {
                InformationAboutTheFastestAutomobile(automobiles[1]);
            }
            else
            {
                Console.WriteLine("Both automobiles have the same speed.\n");
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"Here is information about {i + 1} car:");
                    automobiles[i].PrintAutomobile();
                    Console.WriteLine();
                }
            }
        }
    }
}