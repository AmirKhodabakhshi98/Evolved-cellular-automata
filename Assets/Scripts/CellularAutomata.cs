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
    private int[][] levels;
   


    // Start is called before the first frame update
    void Start()
    {
     //   GetRandomRules();

    }
    public CellularAutomata(CellularAutomata ca)
    {
        this.fitnessScore = ca.getFitness();
        this.rules = new int[ruleSize];
        this.levels = new int[ca.getLevels().Length][];
        Array.Copy(ca.getRules(), this.rules, ca.getRules().Length);
        Array.Copy(ca.getLevels(), this.levels, ca.getLevels().Length);
        

    }

    int id = -1;
    public CellularAutomata(int id){
        this.rules = GetRandomRules();
        this.id = id;
    }

    public int getRuleSize()
    {
        return this.ruleSize;
    }

    public int[][] getLevels()
    {
        return levels;
    }



    //takes in starting states and runs this instances CA rules on them
    public void setLevels(int[][] startingStates, int iterations)
    {
        int[][] levels = new int[startingStates.Length][];
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
    int[] applyRulesForIterations(int[] grid, int[] rules, int iterations)
    {
        int[] temp = new int[grid.Length];
        temp[0] = grid[0];
        temp[grid.Length - 1] = grid[grid.Length-1];
         for(int itr=0; itr<iterations; itr++) { 
            for(int i=1; i<grid.Length-1; i++)
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
     bool shouldCellBeOn(int[] grid, int centerPosition, int[] rules)
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
    private int[] getNeighbours(int[] grid, int centerPosition)
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
