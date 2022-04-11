using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StartingStateGenerator 
{
     
    public static int gridSize = 900;
    public static int gridSide = 30;
    public static float chanceOfCellOn = 0.5F;

    //returns a starting state array based on size with a certain chance of each cell being on.
    public static int[,] getStartingState(){
        int[,] startingState = new int[gridSide,gridSide];
            for(int i= 0; i<gridSide-1; i++)
            {
                for(int j=0; j < gridSide - 1; j++)
                {
                if (randomChanceOn())
                {
                    startingState[i,j] = 1;
                }
                }
            }

        startingState[0, 0] = 2;
        startingState[gridSide - 1, gridSide - 1] = 3;


        //   Debug.Log(string.Join(", ", startingState));


        return startingState;
        }


    public static int[][,] getStartingStateCollection(int startingStatesAmount)
    {
        
        int[][,] startingStates = new int[startingStatesAmount][,];
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
