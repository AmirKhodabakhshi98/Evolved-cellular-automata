using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossover : MonoBehaviour
{



    //takes 2 candidates and performs onepoint crossover. Returns unchanged candidates if random roll fails.
    public static (int[] child1, int[] child2) SinglePointCrossover(int[] candidate1, int[]candidate2, float crossoverProbability)
    {
        float rndValue = Random.value; //kolla så decimalr o sånt nt ställer till d vid slumpgenerering

        //return unchanged candidates if random value isnt within crossoverProbability
        if(rndValue > crossoverProbability)
        {
            return (candidate1, candidate2);
        }


        int length = candidate1.Length;


        int crossoverPoint = Random.Range(1, length);  //if crossoverpoint is 0 then children will just be copies of parents.



        int[] child1 = new int[length];
        int[] child2 = new int[length];

        for(int i=0; i<crossoverPoint; i++)
        {
            child1[i] = candidate2[i];
            child2[i] = candidate1[i];        
        }


        for (int i=crossoverPoint; i<length; i++)
        {
            child2[i] = candidate1[i];
            child1[i] = candidate2[i];
        }


        return (child1, child2);

    }








    

    






}
