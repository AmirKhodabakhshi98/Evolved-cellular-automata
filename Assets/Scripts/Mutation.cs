using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mutation : MonoBehaviour
{
    private static float mutationProbability = 1f/512f;
    
    //Mutates(flips) each rule cell based on above probability
    public static CellularAutomata Mutate(CellularAutomata candidate) {
        for (int j = 1; j < candidate.getRuleSize()-1; j++){
            float randomValue = Random.Range(0f, 1f);
            if (randomValue <= mutationProbability){
                candidate.flipRuleAtPos(j);
            }
        }
        return candidate;
    }
}
