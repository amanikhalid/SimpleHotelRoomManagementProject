namespace SimpleHotelRoomManagementProject
{
    internal class Program
    {
        static int[] RoomNumbers = new int[5];
        static string[] GuestNames = new string[5];
        static int[] Nights = new int[5];
        static double[] RoomRate = new double[5];
        static bool[] isReserved = new bool[5];
        static DateTime[] dates = new DateTime[5];
        static int RoomCounter = 0;
        static int MaxRooms = 5;


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

        }

        static void ViewAllRooms()
        {

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
