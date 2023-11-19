namespace DesignPatterns_HW1.Common
{
    public static class Helper
    {
        public static void DoubleParseArgumentTokens(string[] tokens, int expectedLength, out double[] result)
        {
            if (tokens.Length != expectedLength)
            {
                throw new ArgumentException(ErrorMessages.INVALID_INPUT);
            }

            result = new double[tokens.Length - 1];
            for (int i = 1; i < tokens.Length; i++)
            {
                if (!double.TryParse(tokens[i], out result[i - 1]))
                {
                    throw new ArgumentException(ErrorMessages.INVALID_INPUT);
                }
            }
        }

        public static void AssertTokensLength(string[] tokens, int expected)
        {
            if (tokens.Length != expected)
            {
                throw new ArgumentException(ErrorMessages.INVALID_INPUT);
            }
        }

        public static bool IsValidTriangleInequality(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
