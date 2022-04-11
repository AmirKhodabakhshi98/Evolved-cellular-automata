using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CellularAutomata : System.IComparable<CellularAutomata>
{
    public int ruleSize=512;
    private float fitnessScore = 0f;
    private int[] rules;
    private int[][,] levels;
   


    // Start is called before the first frame update
    void Start()
    {
     //   GetRandomRules();

    }
    public CellularAutomata(CellularAutomata ca)
    {
        this.fitnessScore = ca.getFitness();
        this.rules = new int[ruleSize];
        this.levels = new int[ca.getLevels().Length][,];
        Array.Copy(ca.getRules(), this.rules, ca.getRules().Length);
        Array.Copy(ca.getLevels(), this.levels, ca.getLevels().Length);
        

    }

    
    public CellularAutomata(){
        this.rules = GetRandomRules();
        
    }

    public int getRuleSize()
    {
        return this.ruleSize;
    }

    public int[][,] getLevels()
    {
        return levels;
    }



    //takes in starting states and runs this instances CA rules on them
    public void setLevels(int[][,] startingStates, int iterations)
    {
        int[][,] levels = new int[startingStates.Length][,];
        for(int i=0; i<startingStates.Length; i++)
        {
            levels[i] = applyRulesForIterations(startingStates[i], this.rules, iterations);
        }
        this.levels = levels;
    }

    public int[] getRules()
    {
        return rules;
    }

    public void setRules(int[] newRules)
    {
        this.rules = newRules;
    }

    //changes rule
    public void flipRuleAtPos(int pos)
    {
        if (rules[pos] == 1)
        {
            rules[pos] = 0;
        }
        else { rules[pos] = 1; }
    }

    public void setFitness(float score)
    {
        fitnessScore = score;
    }

    public float getFitness()
    {
        return fitnessScore;
    }

    public void addScore(float score)
    {
        fitnessScore += score;
    }

    public int CompareTo(CellularAutomata other)
    {
        if (this.fitnessScore > other.fitnessScore)
        {
            return -1;
        }
        if (this.fitnessScore < other.fitnessScore)
        {
            return 1;
        }

        return 0;

    }


    //returns a random ruleset
     int[] GetRandomRules()
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
    int[,] applyRulesForIterations(int[,] grid, int[] rules, int iterations)
    {
        int[,] temp = new int[grid.GetLength(0),grid.GetLength(1)];
         
        for(int itr=0; itr<iterations; itr++) { 
            for(int i=0; i<grid.GetLength(0); i++)
            {
                for(int j =0; j < grid.GetLength(1); j++)
                {

                
                if (shouldCellBeOn(grid, i, j, rules))
                {
                    temp[i,j] = 1;
                }
                else { 
                    temp[i,j] = 0; }
                }
            }
            grid = temp;
        }

        temp[0,0] = 2;
        temp[grid.GetLength(0)-1, grid.GetLength(1)-1] = 3;


        return grid;
    }






     //checks Moore neighbours of a cell and compares with rule array, returns true if cell state should be on.
     bool shouldCellBeOn(int[,] grid, int i, int j, int[] rules)
    {
        int[] neighbours = getNeighbours(grid, i, j );

        int value = 0;


        for(int n = 0; n<neighbours.Length; n++)
        {
            if (neighbours[n] == 1)
            {
                value += (int)Mathf.Pow(2, 8-n);
            }

        }

        
        if(rules[value] == 1)
        {
            return true;
        }

        return false;

    }

    //returns an array of the Moore neighbour values of a cell
    private int[] getNeighbours(int[,] grid, int i, int j)
    {
        int size = grid.Length;
        int sideLength = grid.GetLength(0);
        int[] neighbours = new int[9];
        
        int p = 0;
        
        //3 neighbours on above row
        for(int x = i-1; x <= i+1; x++)
        {
            if(x >=0 && x<sideLength && j-1 >= 0 )
            {
                neighbours[p] = grid[x, j - 1];
            }
            p++;
        }

        //middle row
        for(int x=i-1; x<=i+1; x++)
        {
            if (x >= 0 && x < sideLength)
            {
                neighbours[p] = grid[x, j];
            }
            p++;
        }

        //bottom row
        for(int x=i-1; x<=i+1; x++)
        {
            if(x >=0 && x < sideLength && j+1 < sideLength)
            {
                neighbours[p] = grid[x, j + 1];
            }
            p++;
        }

        
        /*

        for(int i = -1; i<=1; i++)
        {
            for(int j = -1); j <= 1; j++){ 
            if (centerPosition - sideLength + i > 0)
            {
                neighbours[p] = grid[centerPosition - sideLength + i];
            }
            p++;
        }
    }

        for(int i=-1; i<=1; i++)
        {
            if(centerPosition+i>0 && centerPosition+i < size)
            {
                neighbours[p] = grid[centerPosition + i];
            }
            p++;
        }

        for(int i=-1; i<=1; i++)
        {
            if(centerPosition+sideLength+i < size)
            {
                neighbours[p] = grid[centerPosition + sideLength + i];
            }
            p++;
        }
        */

        return neighbours;

    }



}
