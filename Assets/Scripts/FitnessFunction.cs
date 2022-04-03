using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Random.Range(0f, 1f));
        Debug.Log(Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void scoreLevels(CellularAutomata[] population)
    {
        for(int i=0; i<population.Length; i++)
        {
            float score = PercentageOn(population[i].getRules());
            population[i].setFitness(score);//ändra
        }
    }



    static float PercentageOn(int[] level)
    {
        int on = 0;
        for(int i=0; i < level.Length; i++)
        {
            if(level[i]== 1)
            {
                on++;
            }
        }

        float percentage = ((float)on) / ((float)level.Length);

        return percentage;


   

    }
}
