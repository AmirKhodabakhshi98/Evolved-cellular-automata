using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{

    public int maxGenerations = 100;
    public int populationSize = 10;
    public int caIterations;
    public float mutationChance;
    public float crossoverChance;
    public int elitismSize = 5;


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

        CellularAutomata[] population = generateLevels();

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


    CellularAutomata[] GenerateNewPop(CellularAutomata[] oldPop)
    {
        CellularAutomata[] newPop = new CellularAutomata[oldPop.Length];
        newPop = Elitism(oldPop, newPop);





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


     CellularAutomata[] generateLevels()
    {
        CellularAutomata[] pop = new CellularAutomata[populationSize];

        for(int i=0; i<populationSize; i++)
        {
            pop[i] = new CellularAutomata();
        }

        return pop;

    }




}
