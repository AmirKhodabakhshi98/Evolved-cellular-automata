using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnds : MonoBehaviour
{   
    int shortestPath(int[,] level)
    {
        LongestShortestPath.Node source = new LongestShortestPath.Node(0, 0, 0);

        Queue<LongestShortestPath.Node> queue = new Queue<LongestShortestPath.Node>();
        queue.Enqueue(new LongestShortestPath.Node(source.row, source.col, 0));

        bool[,] visited = new bool[level.Length, level.Length];
        visited[source.row, source.col] = true;

        while(queue.Count != 0)
        {

        }

    }
