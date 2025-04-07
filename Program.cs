namespace SimpleHotelRoomManagementProject
{
    internal class Program
    {
        static int[] roomNumbers = new int[5];
        static string[] guestNames = new string[5];
        static int[] nights = new int[5];
        static double[] roomRate = new double[5];
        static bool[] isReserved = new bool[5];
        static DateTime[] bookingDates = new DateTime[5];
        static int roomCount = 0;
        static int MAX_ROOMS = 5;


        static void Main(string[] args)
        {


            while (true)
            {
                //Menu System
                Console.Clear();
                Console.WriteLine("\nChoose an Operation:");
                Console.WriteLine("1. Add a new room ");
                Console.WriteLine("2. View all rooms: ");
                Console.WriteLine("3. Reserve a room for a guest ");
                Console.WriteLine("4. View all reservations with total cost");
                Console.WriteLine("5. Search reservation by guest name");
                Console.WriteLine("6. Find the highest-paying guest ");
                Console.WriteLine("7. Cancel a reservation by room number ");
                Console.WriteLine("8. Exit the system");

                Console.WriteLine("Choose a Number :");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddRoom(); break;
                    case 2: ViewAllRooms(); break;
                    case 3: ReserveRoomForGuest(); break;
                    case 4: ViewAllReservations(); break;
                    case 5: SearchReservation(); break;
                    case 6: FindHighestPaying(); break;
                    case 7: CancelReservation(); break;
                    case 8: return;
                    default: Console.WriteLine("Invalid choice! Try again."); break;

                }
                Console.WriteLine("Press Any Key ");
                Console.ReadLine();

            }
        }

        static void AddRoom()
        {
            
            
                char doAgain = ' ';
                do
                {
                    
                    Console.WriteLine("Enter number of rooms to add: ");

                    
                    int numberOfRooms = 0;
                    try
                    {
                        numberOfRooms = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue; 
                    }

                   
                    if (numberOfRooms + roomCount <= MAX_ROOMS)
                    {
                        
                        for (int i = roomCount; i < roomCount + numberOfRooms; i++)
                        {
                           
                            Console.WriteLine("Enter room number: ");
                            int roomNumber = 0;
                            try
                            {
                                roomNumber = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid room number. Please enter a valid number.");
                                i--; 
                                continue;
                            }

                            
                            bool roomExists = false;
                            for (int j = 0; j < roomCount; j++)
                            {
                                if (roomNumbers[j] == roomNumber)
                                {
                                    roomExists = true;
                                    break;
                                }
                            }

                            if (roomExists)
                            {
                                Console.WriteLine("Room number already exists. Please enter a unique room number.");
                                i--; 
                                continue;
                            }

                            
                            double roomRate = 0;
                            do
                            {
                               
                                try
                                {
                                Console.WriteLine("Enter room rate: ");
                                roomRate = double.Parse(Console.ReadLine());
                                    if (roomRate < 100)
                                    {
                                        Console.WriteLine("Room rate must be greater than or equal to 100.");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid room rate. Please enter a valid number.");
                                }
                            } while (roomRate < 100);

                            
                            roomNumbers[i] = roomNumber;
                            isReserved[i] = false; 
                            guestNames[i] = string.Empty; 
                            nights[i] = 0; 
                            bookingDates[i] = DateTime.MinValue; 

                            Console.WriteLine("Room added successfully.");
                        }

                        
                        roomCount += numberOfRooms;
                    }
                    else if (roomCount == MAX_ROOMS)
                    {
                        Console.WriteLine("You have reached the maximum room limit.");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input, remaining space is {MAX_ROOMS - roomCount}.");
                    }

                   
                    Console.WriteLine("Do you want to add more rooms? (y/n)");
                    doAgain = Console.ReadKey().KeyChar; 

                    
                    Console.ReadLine(); 

                } while (doAgain == 'y' || doAgain == 'Y'); 
            }


        

        static void ViewAllRooms()
        {
            static void ViewAllRooms()
            {
                Console.WriteLine("Displaying all rooms (Available + Reserved):");

                for (int i = 0; i < roomCount; i++)
                {
                    Console.WriteLine($"Room Number: {roomNumbers[i]}");

                    if (isReserved[i]) 
                    {
                        
                        double totalCost = nights[i] * roomRate[i];
                        Console.WriteLine($"Status: Reserved");
                        Console.WriteLine($"Guest Name: {guestNames[i]}");
                        Console.WriteLine($"Nights: {nights[i]}");
                        Console.WriteLine($"Room Rate: ${roomRate[i]:0.00}");
                        Console.WriteLine($"Total Cost: ${totalCost:0.00}");
                    }
                    else
                    {
                        Console.WriteLine($"Status: Available");
                    }

                    Console.WriteLine("-------------------------"); 
                }
            }

        }

        static void ReserveRoomForGuest()
        {

        }
        static void ViewAllReservations()
        {

        }

        static void SearchReservation()
        {

        }

        static void FindHighestPaying()
        {

        }

        static void CancelReservation()
        {

        }



    }
}
