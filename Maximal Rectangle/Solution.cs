// detect a rectangle
    //      traverse through the array, looking for 1. Once found begin checking for rectangle, and return it size
    // find all rectangle
    //      create a max counter, the position of the max rectangle while going through the array
    // keep track of each rectangle and return the largest
    //      return the max counter and the position of the max rectangle
public class Solution {
    public int MaximalRectangle(char[,] matrix) {
        if(matrix == null)
            return 0;
            
        int matrixRowSize = matrix.GetLength(0);
        int matrixColSize = matrix.GetLength(1);
            
        if(matrixRowSize == 0 && matrixColSize == 0)
            return 0;
            
        int[,] visited = new int[matrixRowSize, matrixColSize];
        
        for(int row = 0; row < matrix.GetLength(0); row++)
        {
            for(int col = 0; col < matrix.GetLength(1); col++)
            {
                if(matrix[row, col] == 1)
                {
                    Rectangle currentRect = GetRectangle(row ,col,matrix,visisted);
                }
            }
        }    
    }
    
    // Start at [row,col] do an loop and make sure the rectangle is filled, return its height and width
    // TODO: mark t the rectangle as visited.
    public Rectangle GetRectangle(int rowPos, int colPos, char[,] matrix, int[,] visited)
    {
        Rectangle result = new Rectangle(){
            Row = rowPos,
            Col = colPos,
            Height = 1,
            Width = 1
        };
        
        int rowCount = 1, 
            colCount = 1;
        for(int row = rowPos; row < matrix.GetLength(0); row++)
        {
            int rowColCount = 1;
            for(int col = colPos; col < matrix.GetLength(1); col++)
            {
                if(matrix[row,col] == 0)
                {
                    if(rowColCount < colCount)
                    {
                        colCount -= 1;
                    }
                    
                    break;
                }
                
                rowColCount += 1;
                
                if(row == rowPost)
                    colCount += 1;
            }
            
            rowCount += 1;
        }
        result.Width = rowCount;
        result.Height = colCount;
        
        return result;
    }
    
    public class Rectangle{
        public int Row {get;set;}
        public int Col {get;set;}
        public int Height {get;set;}
        public int Width {get;set;}
    }
}