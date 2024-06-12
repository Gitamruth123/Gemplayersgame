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
        switch(direction)
        {
           case 'U':
               if(Position.Y > 0) Position.Y -= 1;
                break;
           case 'D':
               if(Position.Y < 5) Position.Y += 1;
                break;
           case 'L':
               if(Position.X > 0) Position.X -= 1;
                break;
           case 'R':
               if(Position.X < 5) Position.X += 1;
                break;
        }

    }

}
public class Board
{
    private const int Size = 6;
    private string[,] grid;
    private Random random;

    public Board()
    {
        grid = new string[Size, Size];
        random = new Random();
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
                grid[i, j] = "-";

       PlaceItem("P1", 0, 0);
       PlaceItem("P2", 5, 5);
       PlaceRandomItems("G", 5);
       PlaceRandomItems("O", 5);
    }
    private void PlaceItem(string item, int x, int y)
    {
       grid[y, x] = item;
    }

    private void PlaceRandomItems(string item, int count)
    {
        for(int i = 0; i < count; i++)
        {
            int x, y;
            do
            {
               x = random.Next(Size);
               y = random.Next(Size);
            } while(grid[y, x] != "-");
            grid[y, x] = item;
        }
    }
}