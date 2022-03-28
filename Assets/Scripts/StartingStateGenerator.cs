using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingStateGenerator : MonoBehaviour
{

    public int size = 400;
    public float chanceOfCellOn = 0.5F;

    //returns a starting state array based on size with a certain chance of each cell being on.
    public int[] getStartingStateGenerator(){
        int[] startingState = new int[size];    

            for(int i =0; i<size; i++)
            {
                if (randomChanceOn())
                {
                    
                    startingState[i] = 1;
                }
            
            }

        return startingState;
        }

    //generates a random number between 0..1(inclusive), if the number is below RandomChanceOn, returns true
    private bool randomChanceOn()
    {
       
        float rndNbr = Random.value;
        Debug.Log(rndNbr);
        
        if (rndNbr<=chanceOfCellOn)
        {
            return true;
        }
        return false;

    }


    public void Start()
    {
        for(int i =0; i<20; i++)
        {
            getStartingStateGenerator();
        }
    }


}
