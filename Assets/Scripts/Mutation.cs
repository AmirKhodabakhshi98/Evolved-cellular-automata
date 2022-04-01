using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mutation : MonoBehaviour
{
    private float mutationRate;
    //private Random r;

      

    void mutate()
    {
      
        float randomValue = Random.Range(0,1);

        //  mutationRate = 1/(GeneticAlgorithm.RuleArray.length);
        // the bchance will be 1/512
        for (int i = 0; i <= GeneticAlgorithm.RuleArray.length; i++)
        {
            if (randomValue <= mutationRate)
            {
                //change cell at [i]
            }
        }
    }
}
