using System;
using Newtonsoft.Json;

public class Program
{
    public static string CalculateCircleProperties(double r)
    {
        if (r <= 0)
        {
            throw new ArgumentException("Bán kính phải lớn hơn 0.");
        }

        double area = Math.PI * r * r;
        double circumference = 2 * Math.PI * r;
        double diameter = 2 * r;

        var result = new
        {
            dien_tich = area,
            chu_vi = circumference,
            duong_kinh = diameter
        };

        return JsonConvert.SerializeObject(result);
    }

    public static void Main()
    {
        double radius;
        while (true)
        {
            Console.Write("Nhập bán kính (r > 0): ");
            if (double.TryParse(Console.ReadLine(), out radius) && radius > 0)
            {
                break;
            }
            Console.WriteLine("Bán kính không hợp lệ. Vui lòng nhập lại.");
        }

        string jsonResult = CalculateCircleProperties(radius);
        Console.WriteLine(jsonResult);
    }
}