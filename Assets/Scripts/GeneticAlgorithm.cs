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
        CellularAutomata[] newPop = new CellularAutomata[oldPop.Length];
        newPop = Elitism(oldPop, newPop);


        for(int i=elitismSize; i<populationSize; i += 2)
        {
            CellularAutomata candidate1 = TournamentSelection.PerformTournamentSelection(oldPop,tournamentSize);
            CellularAutomata candidate2 = TournamentSelection.PerformTournamentSelection(oldPop, tournamentSize);
           // (candidate1, candidate2) = Crossover.SinglePointCrossover(candidate1,candidate2,crossoverProbability);
            candidate1 = Mutation.Mutate(candidate1);
            candidate2 = Mutation.Mutate(candidate2);
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
