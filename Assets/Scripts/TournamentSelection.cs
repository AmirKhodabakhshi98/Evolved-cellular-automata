
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentSelection : MonoBehaviour
{
    
   

    public static CellularAutomata PerformTournamentSelection(CellularAutomata[] population, int tournamentSize)
    {

     
        
        CellularAutomata[] tournamentArray = new CellularAutomata[tournamentSize]; // creates an array of candidates of size tournamentSize 
       
        for (int i = 0; i < tournamentArray.Length; i++)
        {             

            while (true)
            {
                bool exists = false;
                int randomCandidate = UnityEngine.Random.Range(0, population.Length); // picks a random candidate from the population
                CellularAutomata candidate = population[randomCandidate]; // sets a candidate
                for(int j = 0; j <= i; j++)
                {
                    if (tournamentArray[j] == candidate)
                    {
                        exists = true;
                        break;
                    }
                    
                }
                if (!exists)
                    {
                        tournamentArray[i] = candidate;
                        break;
                    }
            }
                             
        }

        Array.Sort(tournamentArray);
        return tournamentArray[0];       
    
        
    }

}
    









    
 


