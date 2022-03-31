using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossover : MonoBehaviour
{



    //takes 2 candidates and performs onepoint crossover. Returns unchanged candidates if random roll fails.
    static (int[] child1, int[] child2) singlePointCrossover(int[] candidate1, int[]candidate2, float crossoverProbability)
    {
        float rndValue = Random.value;

        //return unchanged candidates if random value isnt within crossoverProbability
        if(rndValue > crossoverProbability)
        {
            return (candidate1, candidate2);
        }


        int length = candidate1.Length;


        int crossoverPoint = Random.Range(1, length - 1); //end range is exclusive. Crossoverpoint cant be 0 or at last bit, because then children are copies of parents

        //   int crossoverPoint2 = Random.Range(0, length); 


        int[] child1 = candidate1;

        for(int i=crossoverPoint; i<length; i++)
        {
            child1[i] = candidate2[i];
        }


        int[] child2 = candidate2;

        for (int i=crossoverPoint; i<length; i++)
        {
            child2[i] = candidate1[i];
        }


        return (child1, child2);

    }



    

    






}
