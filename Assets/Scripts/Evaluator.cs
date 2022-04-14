using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluator : MonoBehaviour
{


    public static string evaluateLevels(CellularAutomata ca)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //loop through levels created by CA 
        for(int i=0; i<ca.getLevels().Length; i++)
        {
            sb.Append("Level " + i + "\t");
            (int nbrOfDeadEnds, float percOn, int unreachable) = deadEnds(ca.getLevels()[i]);
            int shortestPath = LongestShortestPath.shortestPath(ca.getLevels()[i], 29, 29);

            sb.Append("Dead ends: " + nbrOfDeadEnds + "\tunreachable cells: " + unreachable + "\t shortest path: " + shortestPath + "\tPercentage traversable: " + percOn);
            sb.Append("\n");
        }


        return sb.ToString();
    }


    private static (int nbrOfDeadEnds, float percOn, int unreachable) deadEnds(int[,] level)
    {

        int score = 0;
        //int destX;
        //int destY;
        int[,] pathLengths = new int[level.GetLength(0), level.GetLength(1)];
           
        int on=0;
        int unreachable = 0;

        for (int row = 0; row < level.GetLength(0); row++)
        {
            for (int col = 0; col < level.GetLength(1); col++)
            {
                // destX = level[col, 0];
                // destY = level[0, row];
                if (level[row, col] == 1)
                {
                    pathLengths[row, col] = LongestShortestPath.shortestPath(level, row, col);
                    if (pathLengths[row, col] == -1)
                    {
                        unreachable++;
                    }
                    on++;
                }
                // else pathLengths[row, col] = -1;
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
        float total = level.GetLength(0) * level.GetLength(1);
        float percOn = on / total;
        return (nbrOfDeadEnds, percOn, unreachable);
    }

    //4 grannar ska ha lägre path för o va true!
    // a map cell that has no neighboring cell with a longer path length to the entrance cell
    private static bool isDeadEnd(int[,] pathLengths, int row, int col)
    {
        int currPathLength = pathLengths[row, col];

        //utan denna if satsen uppstod nån bugg där non-traversable celler hade 0 som currpathlength och de gynnades typ.
        //extra check så att celler utan en väg till start inte räknas.
        if (currPathLength <= 0)
        {
            return false;
        }
        //check left neighbour
        if (row - 1 > 0 && pathLengths[row - 1, col] > currPathLength)
        {
            return false;
        }

        //right neighbour
        if (row + 1 < pathLengths.GetLength(0) && pathLengths[row + 1, col] > currPathLength)
        {
            return false;
        }

        //below neighbour
        if (col + 1 < pathLengths.GetLength(1) && pathLengths[row, col + 1] > currPathLength)
        {
            return false;
        }

        //above
        if (col - 1 > 0 && pathLengths[row, col - 1] > currPathLength)
        {
            return false;
        }

        return true;

    }


}
