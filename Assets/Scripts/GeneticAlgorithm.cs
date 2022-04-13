using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GeneticAlgorithm 
{

    public int maxGenerations = 10;
    public int populationSize = 50;
    public int cellularAutomataIterations = 5;
    public float mutationProbability;
    public float crossoverProbability = 0.6f;
    public int elitismSize = 6;
    public int tournamentSize = 2;
    public int startingStatesAmount = 1;
    public int convergenceGenerations = 1000;
    public float convergenceDifference=1;


    // Start is called before the first frame update
    void Start()
    {
       // test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GeneticAlgorithm()
    {
       // test();
    }

    public CellularAutomata[] test(int nbrOfRuns)
    {

        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        StringBuilder sb3 = new StringBuilder();
        CellularAutomata[] population = GenerateLevels();
        ;

        for (int n=0; n<nbrOfRuns; n++) { 
            int generations = 0;
            int currFittest = 0;
            int maxfitness = 898;

            population = GenerateLevels();
            int[][,] startingStateCollection = StartingStateGenerator.getStartingStateCollection(startingStatesAmount);

            int convergenceCounter = 0;
            float prevfitness=0;

            while (generations < maxGenerations && currFittest<maxfitness)
            {
                population = GenerateCellularAutomataLevels(population, startingStateCollection);   
                population = FitnessFunction.scoreLevels(population);   
                Array.Sort(population);
                population = GenerateNewPop(population);


                currFittest = (int) population[0].getFitness();
                if ((currFittest - prevfitness) < convergenceDifference)
                {
                    convergenceCounter++;
                    if(convergenceCounter == convergenceGenerations)
                    {
                        break;
                    }
                }
                else
                {
                    convergenceCounter = 0;
                }
                prevfitness = currFittest;

                generations++;
                float avg = 0;
             //   for(int i=0; i<population.Length; i++)
            //    {
             //       avg += (int)population[i].getFitness();
             //   }
            //    avg = avg / populationSize;
            //    sb2.Append((int)Math.Round(avg) + "\n");
           //     sb3.Append(population[0].getFitness() + "\n");
            //    sb3.Append("gen: " + generations + "\n" + "rules: ");
            }
            sb1.Append("mostFit: " + population[0].getFitness() + " gen: " + generations + " converg: " + convergenceCounter + "\n");

        }
   
        
        

        //   new Visualizer(topLevel[0]);

    //    int[] rules = population[0].getRules();
     //   for(int i=0; i < 512; i++)
    //    {
     //       sb3.Append (rules[i] + ", ");
            
    //    }
    //    sb3.Append("tourney size: " + tournamentSize);
    //    sb3.Append("elite size: " + elitismSize);
    //    sb3.Append("pop size: " + populationSize);
    //    sb3.Append("CA iterations " + cellularAutomataIterations);
    //    sb3.Append("starting state amounts " + startingStatesAmount);

    

      //  string path1 = @"E:\backup ssd\downloads\MAU HT 20\PCG kandidat\output\detailsAllRuns-"+ DateTime.Now.ToString("MMddHHmmss") + ".txt";
     //   string path2 = @"E:\backup ssd\downloads\MAU HT 20\PCG kandidat\output\avg-"+ DateTime.Now.ToString("MMddHHmmss") + ".txt";
     //   string path3 = @"E:\backup ssd\downloads\MAU HT 20\PCG kandidat\output\highest-"+ DateTime.Now.ToString("MMddHHmmss") + ".txt";
     //   string path = @"C:\github\Evolved CA\Evolved-CA\Evolved CA\Evolved-CA\Assets\output\output-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt";
        string path2 = @"C:\Users\Adel\Documents\GitHub\Evolved-cellular-automata\Assets\output\Adlers outputs-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt";
        File.WriteAllText(path2, sb1.ToString());
     //   File.WriteAllText(path2, sb2.ToString());
    //    File.WriteAllText(path3, sb3.ToString());

        return population;

    }

    private CellularAutomata[] GenerateCellularAutomataLevels(CellularAutomata[] population, int[][,] startingStateCollection)
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

        
        for(int i=0; i<populationSize; i++)
        {
            pop[i] = new CellularAutomata();
            
        }

        return pop;

    }




}
