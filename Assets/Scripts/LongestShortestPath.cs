using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongestShortestPath : MonoBehaviour
{



    int shortestPath(int[,] level) {
        
        Node source = new Node(0, 0, 0);



        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(new Node(source.row, source.col, 0));

        bool[,] visited = new bool[level.Length, level.Length];
        visited[source.row, source.col] = true;
     
        while (queue.Count != 0)
        {
            Node n = queue.Dequeue();

            if (level[n.row,n.col] == 3)
            {
                return n.distance;
            }

            if (isValid(n.row - 1, n.col, level, visited))
            {
                queue.Enqueue(new Node(n.row - 1, n.col, n.distance + 1));
                visited[n.row - 1, n.col] = true;
            }

            if (isValid(n.row + 1, n.col, level, visited))
            {
                queue.Enqueue(new Node(n.row + 1, n.col, n.distance + 1));
                visited[n.row + 1, n.col] = true;
            }

            if (isValid(n.row, n.col - 1, level, visited))
            {
                queue.Enqueue(new Node(n.row, n.col - 1, n.distance + 1));
                visited[n.row, n.col - 1] = true;
            }

            if (isValid(n.row, n.col + 1, level, visited))
            {
                queue.Enqueue(new Node(n.row, n.col + 1, n.distance + 1));
                visited[n.row, n.col + 1] = true;
            }




        }
        return -1;
    }

    

     bool isValid(int x, int y, int[,]level, bool[,] visited)
    {
        if(x>=0 && y>=0 && x<level.GetLength(0) && y<level.GetLength(1)
            && level[x,y]!=0 && visited[x, y] == false)
        {
            return true;
        }
        return false;

    }

     class Node
    {
        public int row;
        public int col;
        public int distance;

        public Node(int row, int col, int distance)
        {
            this.row = row;
            this.col = col;
            this.distance = distance;
        }

    }


    public int[,] convertArrayTo2D(int[] array)
    {
            
        int size = array.Length;
        int sideLength = (int)Mathf.Sqrt(size);
        int[,] Array2d = new int[sideLength, sideLength];
        int count = 0;
        for (int i = 0; i < sideLength; i++)
        {
            for (int j = 0; j < sideLength; j++)
            {
                Array2d[i, j] = array[count];
                count++;
            }
        }
        return Array2d;
    }





}
