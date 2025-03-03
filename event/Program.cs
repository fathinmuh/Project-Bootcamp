// Define a delegate
public delegate void AlarmHandler();

// Define an event based on the delegate
public class Broadcaster{
    public event AlarmHandler FireAlarm;

    // Method to trigger the alarm
    public void DetectFire()
    {
        Console.WriteLine("Fire detected!");
        FireAlarm?.Invoke(); // Notify all subscribers
    }
}


public class Subs{
// Methods that respond to the event
    public void CallFireDepartment()
    {
        Console.WriteLine("Calling the fire department...");
    }

    public void OpenEmergencyExits()
    {
        Console.WriteLine("Opening emergency exits...");
    }
}

class Program{
    static void Main(){
        // Subscribing to the event
        Broadcaster broadcaster = new Broadcaster();
        Subs subs = new Subs();

        broadcaster.FireAlarm += subs.CallFireDepartment;
        broadcaster.FireAlarm += subs.OpenEmergencyExits;

        // Trigger the fire alarm
        broadcaster.DetectFire();
    }
}
