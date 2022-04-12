using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static CellularAutomata[] scoreLevels(CellularAutomata[] population)
    {
        for(int i=0; i<population.Length; i++)
        {
            float score = 0;
            //  score += PercentageOn(population[i].getLevels());
            for (int j = 0; j < population[i].getLevels().Length; j++) { 

               // score += LongestShortestPath.shortestPath(population[i].getLevels()[j], 29 ,29);
                score += DeadEnds.deadEnds(population[i].getLevels()[j]);

            }
            population[i].setFitness(score);//ändra
        }
        return population;
    }

    /*
    static float PercentageOn(int[][] level)
    {
        int on = 0;
        for(int i=0; i < level.Length; i++)
        {
            for(int j=0; j<level.Length; j++)
            {
                if (level[i][j] == 1)
                {
                    on++;
                }
            }
            
        }

        float percentage = ((float)on) / ((float)level.Length);

        return percentage;

    }
    */

    static float PercentageOn(int[][,] levels)
    {
        float percentageOnTotal = 0f;
        float totalOn = 0;
        for(int n=0; n<levels.Length; n++)
        {
            int on = 0;
            for(int i=0; i<levels[0].GetLength(0); i++)
            {

            for(int j=0; j<levels[0].GetLength(1); j++)
            {
                if (levels[n][i,j] == 1)
                {
                    on++;
                    totalOn++;
                }
            }
            }

            percentageOnTotal += ((float)on) / ((float)levels[n].Length);

        }


        // float percentageOnAverage = percentageOnTotal / ((float) levels.Length);

        //  return percentageOnAverage;
        return totalOn;

    }


}
