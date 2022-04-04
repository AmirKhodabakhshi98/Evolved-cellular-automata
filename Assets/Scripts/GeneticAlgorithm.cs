using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{

    public int maxGenerations = 100;
    public int populationSize = 11;
    public int caIterations;
    public float mutationProbability;
    public float crossoverProbability = 0.6f;
    public int elitismSize = 5;
    public int tournamentSize = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void test()
    {
        int generations = 0;

        CellularAutomata[] population = GenerateLevels();
        int[][] startingStateCollection = GenerateStartingStates();


        while (generations < maxGenerations)
        {
        
            FitnessFunction.scoreLevels(population);
            Array.Sort(population);
            population = GenerateNewPop(population);   
            generations++;
        }
        //generate levels
        //fitness
        //selection
            //tournament
            //crossover
            //mutation
        
    }

    int[][] GenerateStartingStates()
    {

        return null;
    }

    CellularAutomata[] GenerateNewPop(CellularAutomata[] oldPop)
    {
        //instantiate new empty pop
        CellularAutomata[] newPop = new CellularAutomata[oldPop.Length];
        
        //elitist selection from oldpop to newpop
        newPop = Elitism(oldPop, newPop);

        //fill remaining places
        for(int i=elitismSize; i<populationSize; i += 2)
        {
            //select 2 new candidates based on 2 tournament selection runs
            CellularAutomata candidate1 = TournamentSelection.PerformTournamentSelection(oldPop,tournamentSize);
            CellularAutomata candidate2 = TournamentSelection.PerformTournamentSelection(oldPop, tournamentSize);
            
            //get their rules and run crossover method on them
            int[] rules1 = candidate1.getRules();
            int[] rules2 = candidate2.getRules();
            (rules1, rules2) = Crossover.SinglePointCrossover(rules1,rules2,crossoverProbability);
            
            //set the rules resulting from the crossover method to the candidates
            candidate1.setRules(rules1);
            candidate2.setRules(rules2);
            
            //perform mutation on them
            candidate1 = Mutation.Mutate(candidate1);
            candidate2 = Mutation.Mutate(candidate2);
            
            //add to new pop
            newPop[i] = candidate1;
            newPop[i+1] = candidate2;

        }

        return newPop;
    }


    //copies over best candidates from old generation to new generation. assumes oldPop is sorted.
    CellularAutomata[] Elitism(CellularAutomata[] oldPop, CellularAutomata[] newPop)
    {
        for(int i=0; i< elitismSize; i++)
        {
            newPop[i] = oldPop[i];
        }

        return newPop;

    }


     CellularAutomata[] GenerateLevels()
    {
        CellularAutomata[] pop = new CellularAutomata[populationSize];

        for(int i=0; i<populationSize; i++)
        {
            pop[i] = new CellularAutomata();
        }

        return pop;

    }




}
