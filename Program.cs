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
            try
            {
                Console.Write("How many rooms do you want to add? "); // ask user how many rooms to add
                int numRoomsToAdd = int.Parse(Console.ReadLine()); // read the number of rooms to add

                if (roomCount + numRoomsToAdd > MAX_ROOMS) // check if adding the rooms exceeds the maximum
                {
                    Console.WriteLine("You can only add up to " + (MAX_ROOMS - roomCount) + " more rooms."); // show the remaining space
                    return; // exit the method
                }

                for (int i = 0; i < numRoomsToAdd; i++) // loop for the number of rooms to be added
                {
                    int roomNumber;
                    bool isUnique; // to check if the room number is unique

                    // Check unique room number using a do-while loop
                    do
                    {
                        isUnique = true; // Assume the room number is unique
                        Console.Write("Enter room number : ");
                        roomNumber = int.Parse(Console.ReadLine()); // may throw exception if input is not a valid integer

                        for (int j = 0; j < roomCount; j++) // all the room numbers that are already in the array
                        {
                            if (roomNumbers[j] == roomNumber) // check if the room number is already in the array
                            {
                                Console.WriteLine("Room number already exists! Try again."); // message appears if the room number is already in the array
                                isUnique = false; // set isUnique to false
                                break; // exit the loop
                            }
                        }

                    } while (!isUnique); // repeat until a unique room number is found

                    double rate;

                    // Validating rate
                    do
                    {
                        Console.Write("Enter room rate : "); // ask user to enter the room rate

                        // Try to parse the rate. It may fail if the user enters non-numeric values or values less than 100
                        if (!double.TryParse(Console.ReadLine(), out rate) || rate < 100)
                        {
                            Console.WriteLine("Invalid rate. Please enter a number >= 100."); // show error message
                        }

                    } while (rate < 100); // repeat until a valid rate is entered

                    // Store the room details
                    roomNumbers[roomCount] = roomNumber; // store the room number in the array
                    roomRate[roomCount] = rate; // store the room rate in the array
                    isReserved[roomCount] = false; // set the room as not reserved
                    guestNames[roomCount] = ""; // store an empty string for guest name
                    nights[roomCount] = 0; // set the number of nights to 0
                    roomCount++; // increment the room count

                    Console.WriteLine("Room added successfully.\n"); // show success message
                }
            }
            catch (Exception e)
            {
                // Catch the exception when the user enters an invalid number or format
                Console.WriteLine("Invalid input format. Please enter numeric values where expected. Error: " + e.Message);
            }
            
        }

        static void ViewAllRooms()
        {
           
                if (roomCount == 0) // Check if there are no rooms to display
                {
                    Console.WriteLine("No rooms available to display.");
                    return; // Exit if no rooms are available
                }

                for (int i = 0; i < roomCount; i++) // start looping from 0 until reach all rooms that are available in array
                {
                    if (isReserved[i]) // check if the room is reserved (true)
                    {
                        Console.WriteLine("Room Number: " + roomNumbers[i]); // show the room number
                        Console.WriteLine("Reserved by: " + guestNames[i]); // show the guest name
                        Console.WriteLine("Booking Date: " + bookingDates[i]); // show the booking date
                        Console.WriteLine("Nights: " + nights[i]); // show the number of nights
                        Console.WriteLine("Rate: " + roomRate[i]); // show the room rate

                        // Calculate total cost
                        double totalCost = roomRate[i] * nights[i];
                        Console.WriteLine("Total Cost: " + totalCost); // show the total cost
                        Console.WriteLine(); // add an empty line for readability
                    }
                }
            
        }

        static void ReserveRoomForGuest()
        {
            try
            {
                Console.Write("Enter guest name: ");
                string guest = Console.ReadLine(); // user input for guest name

                Console.Write("Enter room number: ");
                int roomNumber = int.Parse(Console.ReadLine()); // user input for room number

                int stayNights;
                do
                {
                    Console.Write("Enter number of nights: ");

                    // validate stayNights input
                    if (!int.TryParse(Console.ReadLine(), out stayNights) || stayNights <= 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a number greater than 0.");
                        stayNights = 0; // reset stayNights to 0 if invalid
                    }

                } while (stayNights <= 0); // repeat until a valid number of nights is entered

                // Search for the room number in the room list
                bool roomFound = false;
                for (int i = 0; i < roomCount; i++)
                {
                    if (roomNumbers[i] == roomNumber)
                    {
                        roomFound = true;

                        if (isReserved[i]) // check if the room is already reserved
                        {
                            Console.WriteLine("Room is already reserved.");
                            return;
                        }

                        // Reserve the room
                        isReserved[i] = true;
                        guestNames[i] = guest;
                        nights[i] = stayNights;
                        bookingDates[i] = DateTime.Now;

                        Console.WriteLine("Room reserved successfully.");
                        return; // exit the method after successful reservation
                    }
                }

                // If room was not found
                if (!roomFound)
                {
                    Console.WriteLine("Room not found.");
                }
            }
            catch (Exception e)
            {
                // Catch any format exceptions that occur during the parsing of integers
                Console.WriteLine("Invalid input format. Please enter valid numbers. Error: " + e.Message);
            }
            
        }

        static void ViewAllReservations()
        {
           
                if (roomCount == 0) // Check if there are no rooms to display
                {
                    Console.WriteLine("No reservations available.");
                    return; // Exit the method if there are no reservations
                }

                for (int i = 0; i < roomCount; i++) // Start looping from 0 until all rooms are checked
                {
                    if (isReserved[i]) // Check if the room is reserved (true)
                    {
                        // Print room details if the room is reserved
                        Console.WriteLine("Room Number: " + roomNumbers[i]); // Show the room number
                        Console.WriteLine("Reserved by : " + guestNames[i]); // Show the guest name
                        Console.WriteLine("Booking Date : " + bookingDates[i]); // Show the booking date
                        Console.WriteLine("Nights : " + nights[i]); // Show the number of nights
                        Console.WriteLine("Rate : " + roomRate[i]); // Show the room rate

                        // Calculate total cost and display it
                        double totalCost = roomRate[i] * nights[i];
                        Console.WriteLine("Total Cost : " + totalCost); // Show the total cost
                        Console.WriteLine(); // Add an empty line for readability
                    }
                }
          
        }

        static void SearchReservation()
        {
            try
            {
                Console.Write("Enter guest name to search: "); // ask user to enter the guest name
                string searchName = Console.ReadLine().ToLower(); // convert the string input to lower case
                bool found = false; // initialize found variable to false

                // Loop through the rooms to check for the reservation
                for (int i = 0; i < roomCount; i++)
                {
                    if (isReserved[i] && guestNames[i].ToLower() == searchName) // check if the room is reserved and the guest name matches the search name
                    {
                        // Display reservation details
                        Console.WriteLine("Room Number : " + roomNumbers[i]); // show the room number
                        Console.WriteLine("Guest Name : " + guestNames[i]); // show the guest name
                        Console.WriteLine("Nights : " + nights[i]); // show the number of nights
                        Console.WriteLine("Booking Dates : " + bookingDates[i]); // show the booking date
                        Console.WriteLine("Total Cost : " + (roomRate[i] * nights[i])); // show the total cost
                        Console.WriteLine("Room Rate : " + roomRate[i]); // show the room rate
                        Console.WriteLine("Room Status : Reserved"); // show the room status

                        found = true; // set found variable to true
                        break; // exit the loop
                    }
                }

                // If no reservation was found
                if (!found)
                {
                    Console.WriteLine("Reservation not found."); // show error message
                }
            }
            catch (NullReferenceException e)
            {
                // Catch if any of the arrays or objects are null
                Console.WriteLine("Error: A null reference occurred. " + e.Message);
            }
            catch (Exception e)
            {
                // Catch any other unexpected exceptions
                Console.WriteLine("An unexpected error occurred: " + e.Message);
            }
        }

        static void FindHighestPaying()
        {
            try
            {
                double maxCost = 0; // initialize maxCost variable to 0
                int maxIndex = -1;  // initialize maxIndex variable to -1 --> (-1 is a flag value to mean "No reservation found")

                // Loop through all rooms to find the highest paying guest
                for (int i = 0; i < roomCount; i++)
                {
                    if (isReserved[i]) // Check if the room is reserved (true).
                    {
                        double totalCost = roomRate[i] * nights[i]; // Calculate the total cost
                        if (totalCost > maxCost) // Check if the total cost is greater than maxCost
                        {
                            maxCost = totalCost; // Set maxCost to totalCost
                            maxIndex = i; // Set maxIndex to i (this room has the highest cost)
                        }
                    }
                }

                // If we found a reservation with the highest cost, display the details
                if (maxIndex != -1)
                {
                    Console.WriteLine("Highest Paying Guest: " + guestNames[maxIndex]); // Show the guest name of the highest paying guest
                    Console.WriteLine("Total Amount = " + maxCost); // Show the total cost of the highest paying guest
                }
                else // If no reservation found
                {
                    Console.WriteLine("No reservations found."); // Show error message
                }
            }
            
            catch (NullReferenceException e)
            {
                // Catch a NullReferenceException if any of the arrays or variables are not initialized correctly
                Console.WriteLine("Error: A null reference occurred. " + e.Message);
            }
            catch (Exception e)
            {
                // Catch any other unexpected exceptions
                Console.WriteLine("An unexpected error occurred: " + e.Message);
            }
        }

        static void CancelReservation()
        {
            try
            {
                Console.Write("Enter room number to cancel reservation: "); // Ask user to enter the room number
                int roomNumber = int.Parse(Console.ReadLine()); // Read the room number

                // Loop through all rooms to find the room number entered
                for (int i = 0; i < roomCount; i++)
                {
                    if (roomNumbers[i] == roomNumber) // Check if the room number matches
                    {
                        if (isReserved[i]) // Check if the room is reserved (true)
                        {
                            // Cancel the reservation
                            isReserved[i] = false; // Set the room as not reserved
                            guestNames[i] = ""; // Clear the guest name
                            nights[i] = 0; // Reset the number of nights
                            Console.WriteLine("Reservation cancelled."); // Show success message
                            return; // Exit the method
                        }
                        else // If the room is not reserved
                        {
                            Console.WriteLine("Room is not reserved."); // Show error message
                            return; // Exit the method
                        }
                    }
                }

                Console.WriteLine("Room not found."); // Show error message if room not found
            }
           
            
            catch (NullReferenceException e)
            {
                // Catch NullReferenceException if any of the arrays are null
                Console.WriteLine("Error: A null reference occurred. " + e.Message);
            }
            catch (Exception e)
            {
                // Catch any other unexpected exceptions
                Console.WriteLine("An unexpected error occurred: " + e.Message);
            }
        }
        

    }
}

