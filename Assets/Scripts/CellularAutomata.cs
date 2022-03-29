using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularAutomata : MonoBehaviour
{
    public static int ruleSize = 512;
    // Start is called before the first frame update
    void Start()
    {
        GetRandomRules();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //returns a random ruleset
    static int[] GetRandomRules()
    {
        int[] rules = new int[ruleSize];

        for(int i=0; i<rules.Length; i++)
        {
            rules[i] = Random.Range(0, 2);
        }

           // Debug.Log(string.Join(", ", rules));

        return rules;
    }



    //Applies CA rules on the given grid for specified number of iterations. 
    static int[] applyRulesForIterations(int[] grid, int[] rules, int iterations)
    {
        int[] temp = new int[grid.Length];

         for(int itr=0; itr<iterations; itr++) { 
            for(int i=0; i<grid.Length; i++)
            {
                if (shouldCellBeOn(grid, i, rules))
                {
                    temp[i] = 1;
                }
                else { 
                    temp[i] = 0; }
            }
            grid = temp;
        }

        return grid;
    }






     //checks Moore neighbours of a cell and compares with rule array, returns true if cell state should be on.
     static bool shouldCellBeOn(int[] grid, int centerPosition, int[] rules)
    {
        int[] neighbours = getNeighbours(grid, centerPosition);

        int value = 0;


        for(int i = 0; i<neighbours.Length; i++)
        {
            if (neighbours[i] == 1)
            {
                value += (int)Mathf.Pow(2, 8-i);
            }

        }

        if(rules[value] == 1)
        {
            return true;
        }

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
