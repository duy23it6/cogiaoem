﻿using System;
using System.IO;

public class CsvWriter
{
    public static void WriteArrayToCsv(float[,] array, string filePath)
    {
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
        // Tạo một mảng 2 chiều các số thực 4 byte
        float[,] array = {
            { 1.1f, 2.2f, 3.3f },
            { 4.4f, 5.5f, 6.6f },
            { 7.7f, 8.8f, 9.9f }
        };

        // Đặt tên file output
        string filePath = "output.csv";

        // Gọi hàm WriteArrayToCsv để ghi mảng ra file CSV
        CsvWriter.WriteArrayToCsv(array, filePath);

        // Thông báo hoàn tất
        Console.WriteLine($"Mảng 2 chiều đã được ghi ra file {filePath}");
    }
}
