using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnds : MonoBehaviour
{
    
    //returns number of dead ends in a grid. Dead end is defined as a cell with nowhere else to go but backtrack.
   public static int deadEnds( int [,] level )
    {
        int[,] pathLengths = new int[level.GetLength(0), level.GetLength(1)];

        for (int row = 0; row < level.GetLength(0); row++)
        {   
            for (int col = 0; col < level.GetLength(1); col++)
            {
                if (level[row, col] == 1)
                {
                    pathLengths[row, col] = LongestShortestPath.shortestPath(level, row, col);
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

    private static bool isDeadEnd(int[,] pathLengths, int row, int col)
    {
        int currPathLength = pathLengths[row, col];
        if(currPathLength <= 0)
        {
            return false;
        }
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
