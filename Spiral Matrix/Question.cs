using System;

// This is the text editor interface. 
// Anything you type or change here will be seen by the other person in real time.
class SpiralMatrix{
    static void Main(){
        int n = 5;
        Point start = new Point(){row =2, col= 2};
        PrintMatrix(n, start);
    }
    
    static void PrintMatrix(int n, Point start){
        int[,] matrix = new int[n,n];
        
        if ( n == 0)
        {
            return ;
        }
        if (n == 1)
        {
            Console.Write("1");
            return;
        }
        
        Direction direction = Direction.LEFT;
        int count = 1;
        int maxCount = 0;
        int availableMove = 4;
        matrix[start.row, start.col] = 1;
        Point current = start;
        while(availableMove >= 0){
            //Console.WriteLine("current: " + current.row + "," + current.col);
            switch(direction){
                case Direction.LEFT:
                    if(current.col + 1 < n && matrix[current.row,current.col + 1] == 0){
                        matrix[current.row,current.col + 1] = ++count;
                        current.col += 1;
                        availableMove = 4;
                        direction = Direction.BOTTOM;
                    }
                    else{
                        direction = Direction.TOP;
                        availableMove -= 1;
                    }
                    break;
                case Direction.BOTTOM:
                      if(current.row + 1 < n && matrix[current.row + 1,current.col] == 0){
                        matrix[current.row + 1,current.col] = ++count;
                        current.row += 1;
                         availableMove = 4;
                         direction = Direction.RIGHT;
                    }
                    else{
                        direction = Direction.LEFT;
                        availableMove -= 1;
                    }
                    break;
                case Direction.RIGHT:
                    if(current.col - 1 >= 0 && matrix[current.row,current.col - 1] == 0){
                        matrix[current.row,current.col - 1] = ++count;
                        current.col -= 1;
                         availableMove = 4;
                         direction = Direction.TOP;
                    }
                    else{
                        direction = Direction.BOTTOM;
                        availableMove -= 1;
                    }
                    break;
                case Direction.TOP:
                      if(current.row - 1 >= 0 && matrix[current.row - 1,current.col] == 0){
                        matrix[current.row - 1,current.col] = ++count;
                        current.row -= 1;
                        availableMove = 4;
                        direction = Direction.LEFT;
                    }
                    else{
                        direction = Direction.RIGHT;
                        availableMove -= 1;
                    }
                           
                    break;
            }
            maxCount += 1;
        }
        
        Console.WriteLine("");
        Console.WriteLine("Result:");
        for(int row = 0 ; row < n; row++){
            for(int col = 0; col < n; col ++){
                Console.Write(matrix[row,col] + " ");
            }
            Console.WriteLine();
        }
        
    }
}

enum Direction{
    LEFT, BOTTOM, RIGHT, TOP
}

class Point{
    public int row;
    public int col;
}