using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JsonWriter
{
    public static void WriteDictionaryToJsonFile(Dictionary<string, object> dictionary, string filePath)
    {
        string jsonString = JsonSerializer.Serialize(dictionary, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);
    }
}

class Program
{
    static void Main()
    {
        var dictionary = new Dictionary<string, object>
        {
            { "Name", "John Doe" },
            { "Age", 30 },
            { "Country", "USA" }
        };

        string filePath = "output_system_text.json";
        JsonWriter.WriteDictionaryToJsonFile(dictionary, filePath);

        Console.WriteLine($"Dictionary đã được ghi ra file {filePath}");
    }
}
