using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularAutomata : MonoBehaviour
{
    public static int ruleSize = 512;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRules();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static int[] GenerateRules()
    {
        int[] rules = new int[ruleSize];

        for(int i=0; i<rules.Length; i++)
        {
            rules[i] = Random.Range(0, 2);
        }

           // Debug.Log(string.Join(", ", rules));

        return rules;
    }


     //checks Moore neighbours of a cell and compares with rule array, returns true if cell state should be on.
     static bool ApplyRuleOnCenterCell(int[] grid, int centerPosition, int[] rules)
    {



        return false;

    }

    //returns an array of the Moore neighbour values of a cell
    private static int[] getNeighbours(int[] grid, int centerPosition)
    {
        int size = grid.Length;
        int sideLength = (int)Mathf.Sqrt(size);
        int[] neighbours = new int[9];
        
        int j = 0;
        
        for(int i = -1; i<=1; i++)
        {
            if (centerPosition - sideLength + i > 0)
            {
                neighbours[j] = grid[centerPosition - sideLength + i];
            }
            j++;
        }

        for(int i=-1; i<=1; i++)
        {
            if(centerPosition+i>0 && centerPosition+i < size)
            {
                neighbours[j] = grid[centerPosition + i];
            }
            j++;
        }

        for(int i=-1; i<=1; i++)
        {
            if(centerPosition+sideLength+i < size)
            {
                neighbours[j] = grid[centerPosition + sideLength + i];
            }
            j++;
        }

        return neighbours;

    }

    

}
