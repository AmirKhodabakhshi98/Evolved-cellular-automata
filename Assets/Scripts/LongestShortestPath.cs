using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongestShortestPath : MonoBehaviour
{



    //returns shortest path between start and input destination
    public static int shortestPath(int[,] level, int destX, int destY) {
        
        Node source = new Node(0, 0, 0);



        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(new Node(source.row, source.col, 0));

        bool[,] visited = new bool[level.Length, level.Length];
        visited[source.row, source.col] = true;
     
        while (queue.Count != 0)
        {
            Node n = queue.Dequeue();

            if (n.row==destX && n.col == destY)
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

    

     static bool isValid(int x, int y, int[,]level, bool[,] visited)
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






}
