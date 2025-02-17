using System;

namespace Intermediate;

public class Room
{
    public string Name { get; set; }
    public Room(string name)
    {
        Name = name;
    }
}

public class House
{
    private List<Room> rooms;

    public House()
    {
        rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        rooms.Add(room);
    }

    public void ShowRooms()
    {
        foreach (var room in rooms)
        {
            Console.WriteLine(room.Name);
        }
    }
}

/****
 //In composition, new instance of the child class is generally created in the parent class initialization process.
//So when the parent class is destroyed, the child class is also destroyed as the child class is a part of the parent class.
//Composition is a "has a" relationship.The child class cannot exist without the parent class.
//It is mainly useful for cases where the child class is a part of the parent class and cannot exist without the parent class like a car and an engine.
House house = new House();
house.AddRoom(new Room("Living Room"));
house.AddRoom(new Room("Kitchen"));
house.ShowRooms();
 ****/