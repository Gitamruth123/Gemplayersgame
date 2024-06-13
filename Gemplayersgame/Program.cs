﻿using System;

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
    public void Display()
    {
        for(int i = 0; i < Size; i++)
        {
            for(int j = 0; j < Size; j++)
            Console.Write(grid[i, j] + " ");
            Console.WriteLine();
        }
    }
    public bool IsValidMove(Player player, char direction)
    {
       int newX = player.Position.X;
       int newY = player.Position.Y;

        switch(direction)
        {
           case 'U':
              newY -= 1;
              break;
           case 'D':
              newY += 1;
              break;
           case 'L':
              newX -= 1;
              break;
            
           case 'R':
              newX += 1;
              break;
        }

        return newX >= 0 && newX < Size && newY >= 0 && newY < Size && grid[newY, newX] != "O" && grid[newY, newX] != "P1" && grid[newY, newX] != "P2";
    }
    public void UpdatePosition(Player player, char direction)
    {
       int oldX = player.Position.X;
       int oldY = player.Position.Y;

        switch(direction)
        {
            
          case 'U':
             player.Position.Y -= 1;
             break;
          case 'D':
             player.Position.Y += 1;
             break;
          case 'L':
             player.Position.X -= 1;
             break;
          case 'R':
             player.Position.X += 1;
             break;
        }

        if(grid[player.Position.Y, player.Position.X] == "G")
        {
          player.GemCount++;
        }

        grid[oldY, oldX] = "-"; // Clear old position
        grid[player.Position.Y, player.Position.X] = player.Name; // Set new position
    }
}


