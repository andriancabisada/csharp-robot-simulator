using System;

class Program
{
    static int[,] table = new int[5, 5];
    static int x = -1;
    static int y = -1;
    static string facing = null;

    static void Main(string[] args)
    {
        //test inputs
        string[] commands = new string[]
        {
            "PLACE 0,0,NORTH",
            "MOVE",
            "REPORT",
            "LEFT",
            "MOVE",
            "REPORT",
            "PLACE 1,2,EAST",
            "MOVE",
            "MOVE",
            "LEFT",
            "MOVE",
            "REPORT"
        };

        foreach (string command in commands)
        {
            string[] parts = command.Split(' ');
            string operation = parts[0];

            switch (operation)
            {
                case "PLACE":
                    string[] parameters = parts[1].Split(',');
                    int xValue = int.Parse(parameters[0]);
                    int yValue = int.Parse(parameters[1]);
                    string facingValue = parameters[2];

                    if (IsValidPosition(xValue, yValue))
                    {
                        x = xValue;
                        y = yValue;
                        facing = facingValue;
                    }
                    break;

                case "MOVE":
                    if (IsValidMove())
                    {
                        switch (facing)
                        {
                            case "NORTH":
                                y++;
                                break;
                            case "SOUTH":
                                y--;
                                break;
                            case "EAST":
                                x++;
                                break;
                            case "WEST":
                                x--;
                                break;
                        }
                    }
                    break;

                case "LEFT":
                    if (facing != null)
                    {
                        switch (facing)
                        {
                            case "NORTH":
                                facing = "WEST";
                                break;
                            case "SOUTH":
                                facing = "EAST";
                                break;
                            case "EAST":
                                facing = "NORTH";
                                break;
                            case "WEST":
                                facing = "SOUTH";
                                break;
                        }
                    }
                    break;

                case "RIGHT":
                    if (facing != null)
                    {
                        switch (facing)
                        {
                            case "NORTH":
                                facing = "EAST";
                                break;
                            case "SOUTH":
                                facing = "WEST";
                                break;
                            case "EAST":
                                facing = "SOUTH";
                                break;
                            case "WEST":
                                facing = "NORTH";
                                break;
                        }
                    }
                    break;

                case "REPORT":
                    if (facing != null)
                    {
                        Console.WriteLine($"{x},{y},{facing}");
                        Console.ReadLine();
                    }
                    break;

                default:
                    Console.WriteLine($"Invalid operation: {operation}");
                    break;
            }
        }
    }

    static bool IsValidPosition(int xValue, int yValue)
    {
        return xValue >= 0 && xValue < 5 && yValue >= 0 && yValue < 5;
    }

    static bool IsValidMove()
    {
        if (facing == null)
        {
            return false;
        }

        switch (facing)
        {
            case "NORTH":
                return y < 4;
            case "SOUTH":
                return y > 0;
            case "EAST":
                return x < 4;
            case "WEST":
                return x > 0;
            default:
                return false;
        }
    }
}
