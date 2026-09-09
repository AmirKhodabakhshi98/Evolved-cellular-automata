
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentSelection : MonoBehaviour
{
    
    //Randomly selects a tournamentSize number of candidates from population and returns the highest rated one.
    public static CellularAutomata PerformTournamentSelection(CellularAutomata[] population, int tournamentSize)
    {
        CellularAutomata[] tournamentArray = new CellularAutomata[tournamentSize]; 
        for (int i = 0; i < tournamentArray.Length; i++) {             
            //Loop ensures no duplicate candidate selection for tournament
            while (true) {
                bool exists = false;
                int randomCandidate = UnityEngine.Random.Range(0, population.Length); 
                CellularAutomata candidate = population[randomCandidate]; 
                for(int j = 0; j <= i; j++) {
                    if (tournamentArray[j] == candidate) {
                        exists = true;
                        break;
                    }
                }
                if (!exists){
                        tournamentArray[i] = candidate;
                        break;
                }
            }
            
        }
        Array.Sort(tournamentArray);
        return tournamentArray[0];       
    }
}
    









    
 


