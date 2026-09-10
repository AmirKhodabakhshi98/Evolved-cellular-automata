using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

//Optional helper class to save/load level states or cellular automata rules.
public class SaveArray
{

    public int[] LoadArray(string filename)
    {
        string path = Path.Combine(Application.dataPath, "Scripts", filename);

        string[] lines = File.ReadAllLines(path);

        int[] array = new int[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            array[i] = int.Parse(lines[i]);
        }

        return array;
    }
    
    public int[,] LoadArray2D(string filename)
    {
        string path = Path.Combine(Application.dataPath, "Scripts", filename);

        string[] lines = File.ReadAllLines(path);

        int rows = lines.Length;
        int cols = lines[0].Split('\t').Length;

        int[,] array = new int[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            string[] values = lines[r].Split('\t');

            for (int c = 0; c < cols; c++)
            {
                array[r, c] = int.Parse(values[c]);
            }
        }

        return array;
    }
    
    public void printArray(int[] array, string filename)
    {
        string path = Path.Combine(Application.dataPath, "Scripts", filename);

        using (var writer = new StreamWriter(path))
        {
            for (int i = 0; i < array.Length; i++)
                writer.WriteLine(array[i]);
        }

        AssetDatabase.Refresh();
    }
    public void printArray(int[,] array, string filename)
    {
        string path = Path.Combine(Application.dataPath, "Scripts", filename);

        using (var writer = new StreamWriter(path))
        {
            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    if (c > 0) writer.Write("\t");
                    writer.Write(array[r, c]);
                }
                writer.WriteLine();
            }
        }
        AssetDatabase.Refresh();
    }
}
