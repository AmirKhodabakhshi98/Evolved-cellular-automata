using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    public int width;
    public int height;

    int[,] map;
    
    public CellularAutomata cellularAutomata;
    int[] grid;

   
    private void Start()
    {
        grid = StartingStateGenerator.getStartingStateGenerator();
        generateMap();
    }

    private void generateMap()
    {
        map = new int[width, height];
    }

    public int[,] convertArrayTo2D(int []array)
    {
       
        int size = array.Length;
        int sideLength = (int)Mathf.Sqrt(size);
        int[,] Array2d = new int[sideLength,sideLength];
        int count = 0;
        for (int i = 0; i < sideLength; i++)
        {
            for(int j = 0; j < sideLength; j++)
            {
                Array2d[i, j] = array[count];
                count++;
            }
        } return Array2d;
    }

    void drawCells()
    {
        if (grid != null)
        {
            for(int x = 0; x<width; x++)
            {
                for(int y = 0; y<height; y++)
                {
                    int grid2d = 
                    Gizmos.color = (grid[])
                }
            }
        }
    }

}
