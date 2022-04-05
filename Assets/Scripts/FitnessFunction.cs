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

    public static void scoreLevels(CellularAutomata[] population)
    {
        for(int i=0; i<population.Length; i++)
        {
            float score = 0;      
            score += PercentageOn(population[i].getLevels());


            population[i].setFitness(score);//ändra
        }
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

    static float PercentageOn(int[][] levels)
    {
        float percentageOnTotal = 0f;
        float totalOn = 0;
        for(int i=0; i<levels.Length; i++)
        {
            int on = 0;

            for(int j=0; j<levels[i].Length; j++)
            {
                if (levels[i][j] == 1)
                {
                    on++;
                    totalOn++;
                }
            }

            percentageOnTotal += ((float)on) / ((float)levels[i].Length);

        }


        // float percentageOnAverage = percentageOnTotal / ((float) levels.Length);

        //  return percentageOnAverage;
        return totalOn;

    }


}
