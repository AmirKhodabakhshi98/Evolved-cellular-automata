using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
  
    public GameObject traversablePrefab;
    public GameObject nonTraversablePrefab;
    public GameObject startEndPrefab;
    
    int[] grid;
    int[,] grid2d;
    
    int side = 30;
    public int[,] altGrid;
    int[][,] lvls;
    int iterator;
    void Start()
    {
        iterator = 0;
        GeneticAlgorithm ga = new GeneticAlgorithm();
        CellularAutomata[] ca = ga.EvolveCellularAutomata(1);
        lvls = ca[0].getLevels();
        grid2d = lvls[iterator];
        DrawCA(grid2d);
    }


    private void Update()
    {
        if (Input.GetKeyDown("space")) {
            iterator = (iterator + 1) % lvls.Length;
            DrawCA(lvls[iterator]);
        }
    }

    private void clearGrid() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
    
 
    void DrawCA(int[,] input) {
        clearGrid();
        altGrid = new int[side, side];
        for(int i=0; i<side;  i++) {
            for(int j=0; j<side; j++) {
                if ((i == 0 && j == 0) || (i==side-1 && j==side-1)) {
                    altGrid[i, j] = input[i, j];
                    SpawnSpecial(i, j);
                }
                else {
                    altGrid[i, j] = input[i, j];
                    SpawnTile(i, j, altGrid[i, j]);
                } 
            }
        }
    }

    private void SpawnSpecial(int x, int y) {
        GameObject tile = startEndPrefab;
        Vector3 position = new Vector3(x, y, 0);
        Instantiate(tile, position, quaternion.identity, transform);
    }

    private void SpawnTile(int x, int y, int value) {
        GameObject tile;
        if (value==1) {
            tile = traversablePrefab;
        }
        else {
            tile = nonTraversablePrefab;
        }
        Vector3 position = new Vector3(x, y, 0);
        Instantiate(tile, position, quaternion.identity, transform);
    }
}
