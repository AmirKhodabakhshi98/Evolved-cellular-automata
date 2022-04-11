using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongestShortestPath : MonoBehaviour
{



    //returns shortest path between start and input destination
    public static int shortestPath(int[,] level, int destX, int destY) {
        
        //set start point, always [0,0]
        Node source = new Node(0, 0, 0);

        //add a source node to queue
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(new Node(source.row, source.col, 0));

        //initiate 2d bool array to represent already visited nodes. source set visited
        bool[,] visited = new bool[level.Length, level.Length];
        visited[source.row, source.col] = true;
     
        //use queue to traverse array.
        while (queue.Count != 0)
        {
            Node n = queue.Dequeue();

            //if we're at destination, return distance to it
            if (n.row==destX && n.col == destY)
            {
                return n.distance;
            }

            //check if cell to the left is within grid.
            //if so, add it to queue and increase distance and mark it as visited
            if (isValid(n.row - 1, n.col, level, visited))
            {
                queue.Enqueue(new Node(n.row - 1, n.col, n.distance + 1));
                visited[n.row - 1, n.col] = true;
            }

            //traverse to right neighbour.
            if (isValid(n.row + 1, n.col, level, visited))
            {
                queue.Enqueue(new Node(n.row + 1, n.col, n.distance + 1));
                visited[n.row + 1, n.col] = true;
            }

            //below neighbour
            if (isValid(n.row, n.col - 1, level, visited))
            {
                queue.Enqueue(new Node(n.row, n.col - 1, n.distance + 1));
                visited[n.row, n.col - 1] = true;
            }

            //above neighbour
            if (isValid(n.row, n.col + 1, level, visited))
            {
                queue.Enqueue(new Node(n.row, n.col + 1, n.distance + 1));
                visited[n.row, n.col + 1] = true;
            }




        }
        return -1;
    }

    
    //check if a input point is within the bounds of the grid AND that it is NOT visited
     static bool isValid(int x, int y, int[,]level, bool[,] visited)
    {
        if(x>=0 && y>=0 && x<level.GetLength(0) && y<level.GetLength(1)
            && level[x,y]!=0 && visited[x, y] == false)
        {
            return true;
        }
        return false;

    }

    //inner node class to store information about a point in grid, and its distance to source point.
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
