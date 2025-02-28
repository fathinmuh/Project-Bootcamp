 using System;

public delegate void ButtonClickedEventHandler(object sender, EventArgs e);


public class Button
{
    public event ButtonClickedEventHandler Clicked;
    private void button1_Click(object sender, System.EventArgs e){}

    public void OnClicked()
    {
        if (Clicked != null)
        {
            Clicked(this, EventArgs.Empty);
        }
    }
}

public class Form
{
    public void HandleButtonClick(object sender, EventArgs e)
    {
        Console.WriteLine("Button was clicked!");
    }
}

class Program
{
    static void Main()
    {
        Form form = new Form();
        Button button = new Button();
        button.Clicked += form.HandleButtonClick;
        button.OnClicked();
    }
}