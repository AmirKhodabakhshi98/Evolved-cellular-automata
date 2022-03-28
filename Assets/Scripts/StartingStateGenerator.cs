using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingStateGenerator : MonoBehaviour
{

    public static int size = 400;
    public static float chanceOfCellOn = 0.5F;

    //returns a starting state array based on size with a certain chance of each cell being on.
    public static int[] getStartingStateGenerator(){
        int[] startingState = new int[size];    

            for(int i =0; i<size; i++)
            {
                if (randomChanceOn())
                {
                    
                    startingState[i] = 1;
                }
            
            }
       
     //   Debug.Log(string.Join(", ", startingState));


        return startingState;
        }

    //generates a random number between 0..1(inclusive), if the number is below RandomChanceOn, returns true
    private static bool randomChanceOn()
    {
       
        float rndNbr = Random.value;
        
        if (rndNbr<=chanceOfCellOn)
        {
            return true;
        }
        return false;

    }


    /*
    public void Start()
    {
        for(int i =0; i<20; i++)
        {
            getStartingStateGenerator();
        }
    }

    */

}
