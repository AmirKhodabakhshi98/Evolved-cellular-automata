using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mutation : MonoBehaviour
{
    private static float mutationRate = 1f/512f;



    //runs through entire population and mutates based on a certain probability
    //startAt variable to skip first elite members 
    static void Mutate(CellularAutomata[] pop, int startAt)
    {
      
    

        //loop entire population
        for (int i = startAt; i < pop.Length; i++)
        {
            //loop through each rule array
            for(int j=0; j<CellularAutomata.ruleSize; j++)
            {
                float randomValue = Random.Range(0f, 1f);
               
                // the chance will be 1/512
                if (randomValue <= mutationRate)
                {
                    pop[i].flipRuleAtPos(j);
                }
            }
        }
    }
}
