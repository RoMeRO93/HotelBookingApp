using System;
using System.Collections.Generic;

class HotelBookingApp
{
    static void Main()
    {
        Console.WriteLine("Welcome to Hotel Booking App!");

        List<HotelRoom> availableRooms = new List<HotelRoom>()
        {
            new HotelRoom("101", "Single", 1, 50),
            new HotelRoom("201", "Double", 2, 80),
            new HotelRoom("301", "Suite", 4, 150),
            new HotelRoom("401", "Penthouse", 6, 300)
        };

        List<HotelRoom> bookedRooms = new List<HotelRoom>();

        bool continueBooking = true;

        while (continueBooking)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. View available rooms");
            Console.WriteLine("2. Book a room");
            Console.WriteLine("3. Cancel a booked room");
            Console.WriteLine("4. View booked rooms");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Available Rooms:");
                    if (availableRooms.Count > 0)
                    {
                        foreach (HotelRoom room in availableRooms)
                        {
                            Console.WriteLine(room);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No available rooms found.");
                    }
                    break;
                case "2":
                    Console.Write("Enter the room number to book: ");
                    string roomNumber = Console.ReadLine();
                    HotelRoom roomToBook = availableRooms.Find(room => room.Number == roomNumber);
                    if (roomToBook != null)
                    {
                        bookedRooms.Add(roomToBook);
                        availableRooms.Remove(roomToBook);
                        Console.WriteLine($"Room '{roomToBook}' booked successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid room number.");
                    }
                    break;
                case "3":
                    Console.Write("Enter the room number to cancel: ");
                    string bookedRoomNumber = Console.ReadLine();
                    HotelRoom bookedRoomToCancel = bookedRooms.Find(room => room.Number == bookedRoomNumber);
                    if (bookedRoomToCancel != null)
                    {
                        availableRooms.Add(bookedRoomToCancel);
                        bookedRooms.Remove(bookedRoomToCancel);
                        Console.WriteLine($"Room '{bookedRoomToCancel}' cancelled successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid room number.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Booked Rooms:");
                    if (bookedRooms.Count > 0)
                    {
                        foreach (HotelRoom room in bookedRooms)
                        {
                            Console.WriteLine(room);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No booked rooms found.");
                    }
                    break;
                case "5":
                    continueBooking = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("\nThank you for using the Hotel Booking App!");
    }
}

class HotelRoom
{
    public string Number { get; set; }
    public string Type { get; set; }
    public int Capacity { get; set; }
    public decimal Price { get; set; }

    public HotelRoom(string number, string type, int capacity, decimal price)
    {
        Number = number;
        Type = type;
        Capacity = capacity;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Number} - {Type} (Capacity: {Capacity}, Price: {Price}$)";
    }
}
