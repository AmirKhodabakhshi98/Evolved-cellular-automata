using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnds : MonoBehaviour
{   
    
   public int deadEnds( int [,] level )
    {
        int score = 0;
        int[,] start = new int[0, 0];
        int destX;
        int destY;
        for (int col = 0; col < level.GetLength(0); col++)
        {
            for (int row = 0; row < level.GetLength(1); row++)
            {
                destX = level[col, 0];
                destY = level[0, row];
                score += LongestShortestPath.shortestPath(level, destX, destY);
                
            }
          
        }return score;
    }

}
