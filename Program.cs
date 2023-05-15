using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the capacity of the water tank: ");
        float V_max = float.Parse(Console.ReadLine());

        Console.Write("Enter the average volume of water participants drank during each break: ");
        float V_drink = float.Parse(Console.ReadLine());

        Console.Write("Enter the interval between rest periods: ");
        int t_drink = int.Parse(Console.ReadLine());

        Console.Write("Enter the interval between filling cycles: ");
        int t_fill = int.Parse(Console.ReadLine());

        Console.Write("Enter the total duration of the activity (in hours): ");
        int t_day = int.Parse(Console.ReadLine());

        string result = CalculateWaterStatus(V_max, V_drink, t_drink, t_fill, t_day);
        Console.WriteLine(result);
    }

    static string CalculateWaterStatus(float V_max, float V_drink, int t_drink, int t_fill, int t_day)
    {
        float remaining_water = V_max;
        int total_intervals = t_day / (t_drink + t_fill);
        int intervals_without_drinking = t_fill / t_drink;

        for (int interval = 0; interval < total_intervals; interval++)
        {
            if (interval % intervals_without_drinking == 0)
            {
                // Participants drink water
                remaining_water -= V_drink;
            }

            if (remaining_water <= 0)
            {
                return "Not Enough Water";
            }

            if ((interval + 1) % intervals_without_drinking == 0)
            {
                // Water refill cycle
                remaining_water = Math.Min(remaining_water + V_drink, V_max);
                if (remaining_water == V_max)
                {
                    return "Overflow Water";
                }
            }
        }

        return $"Enough Water, {remaining_water} left";
    }
}