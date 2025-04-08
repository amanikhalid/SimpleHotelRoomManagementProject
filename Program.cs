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

            Console.Write("How many rooms do you want to add? "); 
            int numRoomsToAdd = int.Parse(Console.ReadLine()); 

            if (roomCount + numRoomsToAdd > MAX_ROOMS)
            {

                Console.WriteLine("You can only add up to " + (MAX_ROOMS - roomCount) + "more rooms."); 
                return; 
            }

            for (int i = 0; i < numRoomsToAdd; i++) 
            {
                int roomNumber;
                bool isUnique;

                
                do
                {
                    isUnique = true; 
                    Console.Write("Enter room number : ");
                    roomNumber = int.Parse(Console.ReadLine());

                    for (int j = 0; j < roomCount; j++)
                    {
                        if (roomNumbers[j] == roomNumber) 
                        {
                            Console.WriteLine("Room number already exists! Please try again.");
                            isUnique = false; 
                            break; 
                        }
                    }

                } while (!isUnique); 

                double rate;

               
                do
                {
                    Console.Write("Enter room rate : "); 
                                                         
                    if (!double.TryParse(Console.ReadLine(), out rate) || rate < 100) 
                    {


                        Console.WriteLine("Invalid rate. Please enter a number Greater than or Equal to 100."); 
                    }

                } while (rate < 100); 

              
                roomNumbers[roomCount] = roomNumber; 
                roomRate[roomCount] = rate; 
                isReserved[roomCount] = false; 
                guestNames[roomCount] = ""; 
                nights[roomCount] = 0; 
                roomCount++; 

                Console.WriteLine("Room added successfully.\n"); 
            }

        }




        static void ViewAllRooms()
        {


            for (int i = 0; i < roomCount; i++) 

            {
                Console.Write("Room  " + roomNumbers[i] + "\n"); 

                if (isReserved[i]) 
                {
                    Console.WriteLine("Reserved by : " + guestNames[i]); 
                    Console.WriteLine("Booking Date : " + bookingDates[i]); 
                    Console.WriteLine("Nights : " + nights[i]); 
                    Console.WriteLine("Rate : " + roomRate[i]); 
                    double totalCost = roomRate[i] * nights[i]; 
                    Console.WriteLine("Total Cost : " + totalCost); 
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Available"); 
                }

            }

        }



        static void ReserveRoomForGuest()
        {

            Console.Write("Enter guest name: "); 
            string guest = Console.ReadLine(); 

            Console.Write("Enter room number: "); 
            int roomNumber = int.Parse(Console.ReadLine()); 

            
            int stayNights; 
            do
            {
                Console.Write("Enter number of nights : "); 
               
                if (!int.TryParse(Console.ReadLine(), out stayNights) || stayNights <= 0) 
                {
                    Console.WriteLine("Invalid input. Please enter a number greater than 0."); 
                    stayNights = 0; 

                }

            } while (stayNights <= 0); 

            
            for (int i = 0; i < roomCount; i++) 
            {
                if (roomNumbers[i] == roomNumber)
                {

                    if (isReserved[i]) 
                    {
                        Console.WriteLine("Room is already reserved."); 
                        return; 
                    }

                    isReserved[i] = true; 
                    guestNames[i] = guest; 
                    nights[i] = stayNights;
                    bookingDates[i] = DateTime.Now; 

                    Console.WriteLine("Room reserved successfully."); 
                    return; 
                }
            }

            Console.WriteLine("Room not found."); 

        }
        static void ViewAllReservations()
        {
            for (int i = 0; i < roomCount; i++) 
            {
                if (isReserved[i]) 
                {



                    Console.WriteLine("Room Number: " + roomNumbers[i]); 
                    Console.WriteLine("Reserved by : " + guestNames[i]); 
                    Console.WriteLine("Booking Date : " + bookingDates[i]); 
                    Console.WriteLine("Nights : " + nights[i]); 
                    Console.WriteLine("Rate : " + roomRate[i]); 
                    double totalCost = roomRate[i] * nights[i]; 
                    Console.WriteLine("Total Cost : " + totalCost); 
                    Console.WriteLine(); 




                }
            }
        }

        static void SearchReservation()
        {
            Console.Write("Enter guest name to search: "); 
            string searchName = Console.ReadLine().ToLower(); 
            bool found = false; 

            for (int i = 0; i < roomCount; i++) 
            {
                if (isReserved[i] && guestNames[i].ToLower() == searchName) 
                {

                    Console.WriteLine("Room Number : " + roomNumbers[i]); 
                    Console.WriteLine("Guest Name : " + guestNames[i]);
                    Console.WriteLine("Nights : " + nights[i]);
                    Console.WriteLine("Booking Dates : " + bookingDates[i]);
                    Console.WriteLine("Total Cost : " + (roomRate[i] * nights[i]));
                    Console.WriteLine("Room Rate : " + roomRate[i]);
                    Console.WriteLine("Room Statuse : Reserved");

                    found = true; 
                    break; 
                }
            }

            if (!found)
                Console.WriteLine("Reservation not found."); 
        }

        static void FindHighestPaying()
        {
            double maxCost = 0;
            int maxIndex = -1; 

            for (int i = 0; i < roomCount; i++) 

            {
                if (isReserved[i])
                {
                    double totalCost = roomRate[i] * nights[i]; 
                    if (totalCost > maxCost) 
                    {

                        maxCost = totalCost; 
                        maxIndex = i; 
                    }
                }
            }

            if (maxIndex != -1) 
            {

                Console.WriteLine("Highest Paying Guest: " + guestNames[maxIndex]); 
                Console.WriteLine("Total Amount = " + maxCost);


            }
            else 
            {
                Console.WriteLine("No reservations found."); 
            }
        }

        static void CancelReservation()
        {

            Console.Write("Enter room number to cancel reservation: "); 
            int roomNumber = int.Parse(Console.ReadLine()); 

            for (int i = 0; i < roomCount; i++) 
            {
                if (roomNumbers[i] == roomNumber) 
                {

                    if (isReserved[i]) 
                    {
                        isReserved[i] = false; 
                        guestNames[i] = "";
                        nights[i] = 0; 
                        Console.WriteLine("Reservation cancelled."); 
                        return; 
                    }
                    else 
                    {
                        Console.WriteLine("Room is not reserved."); 
                        return; 
                }
            }

            Console.WriteLine("Room not found."); 
        }
    }



    }
}
