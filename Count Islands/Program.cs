using System.Collections.Generic;

public class Solution
{
    public int NumIslands(char[,] grid)
    {
        int numberOfIslands = 0;
        Stack<Node> visitingNodes = new Stack<Node>();
        int rowLength = grid.GetLength(0);
        int colLength = grid.GetLength(1);
        for (int row = 0; row < rowLength; row++)
        {
            for (int col = 0; col < colLength; col++)
            {
                if (grid[row, col] == '1')
                {
                    numberOfIslands += 1;
                    visitingNodes.Push(new Node(row, col));
                    while (visitingNodes.Count > 0)
                    {
                        var node = visitingNodes.Pop();
                        grid[node.Row, node.Column] = '0';
                        int directions = 3;
                        while (directions >= 0)
                        {
                            switch (directions)
                            {
                                case (int)Direction.Top:
                                    if (node.Row + 1 < rowLength && grid[node.Row + 1, node.Column] == '1')
                                        visitingNodes.Push(new Node(node.Row + 1, node.Column));
                                    break;
                                case (int)Direction.Bottom:
                                    if (node.Row - 1 >= 0 && grid[node.Row - 1, node.Column] == '1')
                                        visitingNodes.Push(new Node(node.Row - 1, node.Column));
                                    break;
                                case (int)Direction.Left:
                                    if (node.Column - 1 >= 0 && grid[node.Row, node.Column - 1] == '1')
                                        visitingNodes.Push(new Node(node.Row, node.Column - 1));
                                    break;
                                case (int)Direction.Right:
                                    if (node.Column + 1 < colLength && grid[node.Row, node.Column + 1] == '1')
                                        visitingNodes.Push(new Node(node.Row, node.Column + 1));
                                    break;
                            }
                            directions--;
                        }
                    }
                }
            }
        }

        return numberOfIslands;
    }
}

public class Node
{
    public int Row { get; set; }
    public int Column { get; set; }
    public Node(int row, int column)
    {
        this.Row = row;
        this.Column = column;
    }
}

public enum Direction
{
    Top,
    Left,
    Right,
    Bottom
}