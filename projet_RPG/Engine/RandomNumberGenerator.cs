using System;
namespace projet_RPG.Engine
{
    public static class RandomNumberGenerator
    {
        private static Random generator = new Random();

        public static int GenerateNumber(int minimumValue, int maximumValue)
        {
            return generator.Next(minimumValue, maximumValue + 1);
        }
    }
}
