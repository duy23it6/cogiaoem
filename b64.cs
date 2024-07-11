using System;
using System.IO;
using System.Text;

public class CsvWriter
{
    public static void WriteArrayToCsv(float[,] array, string filePath)
    {Console.OutputEncoding = Encoding.UTF8;
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    writer.Write(array[i, j]);
                    if (j < columns - 1)
                    {
                        writer.Write(",");
                    }
                }
                writer.WriteLine();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        float[,] array = {
            { 1.1f, 2.2f, 3.3f },
            { 4.4f, 5.5f, 6.6f },
            { 7.7f, 8.8f, 9.9f }
        };

        string filePath = "output.csv";
        CsvWriter.WriteArrayToCsv(array, filePath);

        Console.WriteLine($"Mảng 2 chiều đã được ghi ra file {filePath}");
    }
}

