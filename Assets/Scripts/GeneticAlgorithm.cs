using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GeneticAlgorithm 
{

    public int maxGenerations = 100;
    public int populationSize = 30;
    public int cellularAutomataIterations = 5;
    public float mutationProbability;
    public float crossoverProbability = 0.6f;
    public int elitismSize = 10;
    public int tournamentSize = 5;
    public int startingStatesAmount = 10;


    // Start is called before the first frame update
    void Start()
    {
        test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GeneticAlgorithm()
    {
       // test();
    }

    public CellularAutomata[] test()
    {
        int generations = 0;

        CellularAutomata[] population = GenerateLevels();
        int[][] startingStateCollection = StartingStateGenerator.getStartingStateCollection(startingStatesAmount);

        StringBuilder sb = new StringBuilder();
        while (generations < maxGenerations)
        {
            population = GenerateCellularAutomataLevels(population, startingStateCollection);   
            population = FitnessFunction.scoreLevels(population);   
            Array.Sort(population);
            population = GenerateNewPop(population);   
            
           
            generations++;
         
            sb.Append(population[0].getFitness() + "\n");
        }

        int[][] topLevel = population[0].getLevels();

     //   new Visualizer(topLevel[0]);

        for(int i=0; i < 400; i++)
        {
            sb.Append (topLevel[0][i] + ", ");
            
        }

        //string path = @"E:\backup ssd\downloads\MAU HT 20\PCG kandidat\output\output.txt";
        string path = @"C:\github\Evolved CA\Evolved-CA\Evolved CA\Evolved-CA\Assets\output\output-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt";
        File.WriteAllText(path, sb.ToString());

        return population;

    }

    private CellularAutomata[] GenerateCellularAutomataLevels(CellularAutomata[] population, int[][] startingStateCollection)
    {
        for(int i=0; i<population.Length; i++)
        {
            population[i].setLevels(startingStateCollection, cellularAutomataIterations);
        }

        return population;
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
            CellularAutomata candidate1 = new CellularAutomata(TournamentSelection.PerformTournamentSelection(oldPop,tournamentSize));
            CellularAutomata candidate2 = new CellularAutomata(TournamentSelection.PerformTournamentSelection(oldPop, tournamentSize));
           // string allContents = string.Join(", ", candidate1.getRules());
         //   string allContents2 = string.Join(", ", candidate2.getRules());
       //     Debug.Log(allContents);
     //       Debug.Log(allContents2);

            //get their rules and run crossover method on them
            int[] rules1 = candidate1.getRules();
            int[] rules2 = candidate2.getRules();
            (rules1, rules2) = Crossover.SinglePointCrossover(rules1,rules2,crossoverProbability);
            
            //set the rules resulting from the crossover method to the candidates
            candidate1.setRules(rules1);
            candidate2.setRules(rules2);
          //  allContents = string.Join(", ", candidate1.getRules());
          //  allContents2 = string.Join(", ", candidate2.getRules());
          //  Debug.Log(allContents);
         //   Debug.Log(allContents2);


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
            CellularAutomata ca = new CellularAutomata(oldPop[i]);
            newPop[i] = ca;
        }

        return newPop;

    }


     CellularAutomata[] GenerateLevels()
    {
        CellularAutomata[] pop = new CellularAutomata[populationSize];

        int id = 0;
        for(int i=0; i<populationSize; i++)
        {
            pop[i] = new CellularAutomata(id);
            id++;
        }

        return pop;

    }




}
