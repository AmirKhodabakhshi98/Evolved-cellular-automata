using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnds : MonoBehaviour
{



   public static int deadEnds( int [,] level )
    {
        
        int score = 0;
        //int destX;
        //int destY;
        int[,] pathLengths = new int[level.GetLength(0), level.GetLength(1)];

        for (int row = 0; row < level.GetLength(0); row++)
        {   
            for (int col = 0; col < level.GetLength(1); col++)
            {
                // destX = level[col, 0];
                // destY = level[0, row];
                if (level[row, col] == 1)
                {   
                    pathLengths[row , col] = LongestShortestPath.shortestPath(level, row, col);
                }
            }

        }

        int nbrOfDeadEnds = 0;
        for (int row = 0; row < level.GetLength(0); row++)
        {
            for (int col = 0; col < level.GetLength(1); col++)
            {
                if (isDeadEnd(pathLengths, row, col))
                {
                    nbrOfDeadEnds++;
                }
            }
        }
                return nbrOfDeadEnds;
    }

    //4 grannar ska ha lägre path för o va true!
    // a map cell that has no neighboring cell with a longer path length to the entrance cell
    private static bool isDeadEnd(int[,] pathLengths, int row, int col)
    {
        int currPathLength = pathLengths[row, col];

        //check left neighbour
        if(row-1 >0 && pathLengths[row-1, col] > currPathLength)
        {
            return false;
        }

        //right neighbour
        if(row+1 < pathLengths.GetLength(0) && pathLengths[row+1, col] > currPathLength)
        {
            return false;
        }

        //below neighbour
        if (col + 1 < pathLengths.GetLength(1) && pathLengths[row , col+1] > currPathLength)
        {
            return false;
        }

        //above
        if (col-1 >0 && pathLengths[row, col-1] > currPathLength)
        {
            return false;
        }

        return true;

    }

}
