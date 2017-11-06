using System;

static public class DDRand
{
    static private Random rand = new Random();
    static public double Double(double min, double max)
    {
        var diff = max - min;
        return min + diff * rand.NextDouble();
    }

    static public int Int(int min, int max)
    {
        return rand.Next(min, max);
    }
}