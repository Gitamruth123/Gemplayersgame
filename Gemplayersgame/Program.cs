using System;

public class Position
{
    public int X{ get; set; }
    public int Y{ get; set; }

    public Position(int x, int y)
    {
       X = x;
       Y = y;
    }
}

public class Player
{
    public string Name{ get; set; }
    public Position Position{ get; set; }
    public int GemCount{ get; set; }

    public Player(string name, Position position)
    {
       Name = name;
       Position = position;
       GemCount = 0;
    }
    public void Move(char direction)
    {
        switch (direction)
        {
            case 'U':
                if (Position.Y > 0) Position.Y -= 1;
                break;
            case 'D':
                if (Position.Y < 5) Position.Y += 1;
                break;
            case 'L':
                if (Position.X > 0) Position.X -= 1;
                break;
            case 'R':
                if (Position.X < 5) Position.X += 1;
                break;
        }

    }

}