using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int[,] map = new int[,] {
            {1, 1, 0, 0, 0},
            {0, 1, 0, 0, 1},
            {1, 0, 0, 1, 1},
            {0, 0, 0, 0, 0},
            {1, 0, 1, 0, 1}
        };

        IslandCounter islandCounter = new IslandCounter();
        Console.WriteLine(islandCounter.Count(map));
    }    
}

public class IslandCounter
{
    // iterate through each location in the map
    // if the location value is 0 skip
    // if the location value is 1 begin doing a DFS to mark the island as visited
    //      marking the island by visiting all surrounding location that is connected to the origin location
    // once done, continue check other locations        
    // need a map to keep track of the visited location
    public int Count(int[,] map)
    {
        int rowCount = map.GetLength(0);
        int colCount = map.GetLength(1);
        bool[,] visitedMap = new bool[rowCount, colCount];
        int islandCount = 0;
        for(int row = 0; row < rowCount; row++)
        {
            for(int col = 0; col < colCount; col++)
            {
                if(map[row,col] == 1 && !visitedMap[row,col])
                {
                    islandCount++;                    
                    DFS(map, row, col, visitedMap);
                }
            }
        }
        return islandCount;
    }

    public void DFS(int[,] map, int row, int col, bool[,] visitedMap){        
        List<Neighbor> neighbors = new List<Neighbor>();
        neighbors.Add(new Neighbor(row-1, col-1));
        neighbors.Add(new Neighbor(row-1, col));
        neighbors.Add(new Neighbor(row-1, col+1));
        neighbors.Add(new Neighbor(row, col-1));
        neighbors.Add(new Neighbor(row, col));        
        neighbors.Add(new Neighbor(row, col+1));
        neighbors.Add(new Neighbor(row+1, col-1));
        neighbors.Add(new Neighbor(row+1, col));
        neighbors.Add(new Neighbor(row+1, col+1));
        int rowCount = map.GetLength(0);
        int colCount = map.GetLength(1);

        foreach(var neighbor in neighbors)
        {
            if(neighbor.Row >= 0 && neighbor.Row < rowCount
                && neighbor.Col >= 0 && neighbor.Col < colCount
                && map[neighbor.Row,neighbor.Col] == 1 
                && !visitedMap[neighbor.Row,neighbor.Col])
                {
                    visitedMap[neighbor.Row,neighbor.Col] = true;
                    DFS(map, neighbor.Row, neighbor.Col, visitedMap);
                }
        }
    }

    public void IterativeDFS(int[,] map, int row, int col, bool[,] visitedMap){
        int rowCount = map.GetLength(0);
        int colCount = map.GetLength(1);
        Stack<Neighbor> stack = new Stack<Neighbor>();
        stack.Push(new Neighbor(row,col));

        while( stack.Count > 0 )
        {
            Neighbor currentNeighbor = stack.Pop();
            if(currentNeighbor.Row >= 0 && currentNeighbor.Row < rowCount
                && currentNeighbor.Col >= 0 && currentNeighbor.Col < colCount
                && map[currentNeighbor.Row, currentNeighbor.Col] == 1 
                && !visitedMap[currentNeighbor.Row, currentNeighbor.Col])
                {
                    visitedMap[currentNeighbor.Row, currentNeighbor.Col] = true;
                    stack.Push(new Neighbor(row-1, col-1));
                    stack.Push(new Neighbor(row-1, col));
                    stack.Push(new Neighbor(row-1, col+1));
                    stack.Push(new Neighbor(row, col-1));        
                    stack.Push(new Neighbor(row, col+1));
                    stack.Push(new Neighbor(row+1, col-1));
                    stack.Push(new Neighbor(row+1, col));
                    stack.Push(new Neighbor(row+1, col+1));
                }
        }
    }
}

public class Neighbor{
    public int Row {get;set;}
    public int Col {get;set;}

    public Neighbor(int row, int col)
    {
        Row = row;
        Col = col;
    }
}