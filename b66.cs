using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class CsvReader
{
    public static float[,] ReadCsvToArray(string filePath, bool hasHeader)
    {
        List<float[]> rows = new List<float[]>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            bool firstLine = true;

            while ((line = reader.ReadLine()) != null)
            {
                if (firstLine && hasHeader)
                {
                    firstLine = false;
                    continue;
                }

                string[] values = line.Split(',');
                float[] row = new float[values.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    row[i] = float.Parse(values[i], CultureInfo.InvariantCulture);
                }
                rows.Add(row);
            }
        }

        int numRows = rows.Count;
        int numCols = rows[0].Length;
        float[,] array = new float[numRows, numCols];

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                array[i, j] = rows[i][j];
            }
        }

        return array;
    }
}

class Program
{
    static void Main()
    {
        string filePath = "path/to/your/file.csv";

        // Đọc file CSV có header
        float[,] arrayWithHeader = CsvReader.ReadCsvToArray(filePath, true);
        Console.WriteLine("Mảng từ file CSV có header:");
        PrintArray(arrayWithHeader);

        // Đọc file CSV không có header
        float[,] arrayWithoutHeader = CsvReader.ReadCsvToArray(filePath, false);
        Console.WriteLine("Mảng từ file CSV không có header:");
        PrintArray(arrayWithoutHeader);
    }

    static void PrintArray(float[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
