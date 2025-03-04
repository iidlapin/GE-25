using UnityEngine;
using AG3787
using System;
using System.Collections.Generic;


/*  RECAP TASK - EVENTS
 * 
     Task Instructions:

    1. Subscribe to the OnOpen and OnClose events using lambda expressions or separate methods.
    2. Trigger the Open() and Close() methods and observe how the events work.
    3.  Modify the code to remove an event handler before triggering an event.
   
 */
class Door
{
    public event Action OnOpen;
    public event Action OnClose;

    public void Open()
    {
        Console.WriteLine("Door is opening...");
        OnOpen?.Invoke();
    }

    public void Close()
    {
        Console.WriteLine("Door is closing...");
        OnClose?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        Door door = new Door();

        // TODO: Subscribe event handlers to the door events
        // door.OnOpen += () => Console.WriteLine("The door is now open!");
        // door.OnClose += () => Console.WriteLine("The door is now closed!");

        // TODO: Trigger the events
        // door.Open();
        // door.Close();
    }
}









/* SOLUTION ( SPOILER )
 * 
 * 
class Door
{
    public event Action OnOpen;
    public event Action OnClose;

    public void Open()
    {
        Console.WriteLine("Door is opening...");
        OnOpen?.Invoke();
    }

    public void Close()
    {
        Console.WriteLine("Door is closing...");
        OnClose?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        Door door = new Door();

        // Event handlers
        Action openHandler = () => Console.WriteLine("The door is now open!");
        Action closeHandler = () => Console.WriteLine("The door is now closed!");

        // Subscribing event handlers
        door.OnOpen += openHandler;
        door.OnClose += closeHandler;

        // Triggering the events
        door.Open();
        door.Close();

        // Removing an event handler
        door.OnOpen -= openHandler;

        Console.WriteLine("\nAfter removing the open handler:");
        
        // Triggering events again to see the effect of removal
        door.Open();
        door.Close();
    }
}
 * 
 * 
 * 
 * 
 * 
 */