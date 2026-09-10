using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GeneticAlgorithm 
{

    public int maxGenerations = 1000;
    public int populationSize = 50;
    public int cellularAutomataIterations = 5;
    public float crossoverProbability = 0.6f;
    public int elitismSize = 6;
    public int tournamentSize = 2;
    public int startingStatesAmount = 10;
    public int convergenceGenerations = 300;
    public float convergenceDifference=1;
    private SaveArray saveArray = new SaveArray();

    
    public CellularAutomata[] EvolveCellularAutomata(int nbrOfRuns)
    {
        CellularAutomata[] population = GenerateLevels();

        for (int n=0; n<nbrOfRuns; n++) { 
            int generations = 0;
            int currFittest = 0;
            int maxfitness = 898;
            population = GenerateLevels();
            int[][,] startingStateCollection = StartingStateGenerator.getStartingStateCollection(startingStatesAmount);
            int convergenceCounter = 0;
            float prevfitness=0;

            while (generations < maxGenerations && currFittest<maxfitness){
                population = GenerateCellularAutomataLevels(population, startingStateCollection);   
                population = FitnessFunction.scoreLevels(population);   
                Array.Sort(population);
                
                if (generations==0)
                {
                    for (var i = 0; i < startingStateCollection.Length; i++)
                    {
                        saveArray.printArray(startingStateCollection[0],"SS"+i);    
                    }
                }

                population = GenerateNewPop(population);
                currFittest = (int) population[0].getFitness();
                
                if ((currFittest - prevfitness) < convergenceDifference) {
                    convergenceCounter++;
                    if(convergenceCounter == convergenceGenerations)
                    {
                        break;
                    }
                }
                else {
                    convergenceCounter = 0;
                }
                prevfitness = currFittest;
                generations++;
                
            }
        } 
        saveArray.printArray(population[0].getRules(), "BestCA");
        return population;
    }
    

    private CellularAutomata[] GenerateCellularAutomataLevels(CellularAutomata[] population, int[][,] startingStateCollection) {
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
        for(int i=0; i< elitismSize; i++) {
            CellularAutomata ca = new CellularAutomata(oldPop[i]);
            newPop[i] = ca;
        }
        return newPop;
    }
    
     CellularAutomata[] GenerateLevels() {
        CellularAutomata[] pop = new CellularAutomata[populationSize];
        
        for(int i=0; i<populationSize; i++) {
            pop[i] = new CellularAutomata();
        }
        return pop;
    }
}
