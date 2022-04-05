using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StartingStateGenerator 
{
     
    public static int gridSize = 400;
    public static float chanceOfCellOn = 0.5F;

    //returns a starting state array based on size with a certain chance of each cell being on.
    public static int[] getStartingState(){
        int[] startingState = new int[gridSize];    

            for(int i =0; i<gridSize; i++)
            {
                if (randomChanceOn())
                {
                    
                    startingState[i] = 1;
                }
            
            }
       
     //   Debug.Log(string.Join(", ", startingState));


        return startingState;
        }


    public static int[][] getStartingStateCollection(int startingStatesAmount)
    {
        int[][] startingStates = new int[startingStatesAmount][];
        for(int i=0; i<startingStatesAmount; i++)
        {
            startingStates[i] = getStartingState();
        }
        return startingStates;
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



}
