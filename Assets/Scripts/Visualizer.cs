using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    public int width;
    public int height;
    
    int[] grid;
    int[,] grid2d;



    void Start()
    {
        grid = StartingStateGenerator.getStartingState();
        generateMap();
    }

    private void generateMap()
    {
        grid2d = new int[width, height];
        
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

    void OnDrawGizmos()
    {
        if (grid2d != null)
        {   grid2d = convertArrayTo2D(grid);
            for(int x = 0; x<width; x++)
            {
                for(int y = 0; y<height; y++)
                {
                    
                    Gizmos.color = (grid2d[x, y] == 1) ? Color.black : Color.red;
                    Vector3 position = new Vector3(-width / 2 + x + .5f, -height / 2 + y + .5f, 0);
                    Gizmos.DrawCube(position, Vector3.one);
                }
            }
        }
    }

}
