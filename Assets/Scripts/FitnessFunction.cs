using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessFunction : MonoBehaviour
{
    
    public static CellularAutomata[] scoreLevels(CellularAutomata[] population)
    {
        for(int i=0; i<population.Length; i++)
        {
            float score = 0;
            for (int j = 0; j < population[i].getLevels().Length; j++) { 

                score += LongestShortestPath.shortestPath(population[i].getLevels()[j], 29 ,29);
                score += DeadEnds.deadEnds(population[i].getLevels()[j]);

            }
            population[i].setFitness(score);
        }
        return population;
    }
}
