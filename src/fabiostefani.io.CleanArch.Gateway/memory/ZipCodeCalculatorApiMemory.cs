using fabiostefani.io.CleanArch.Domain;

namespace fabiostefani.io.CleanArch.Gateway.memory
{
    public class ZipCodeCalculatorApiMemory : IZipCodeCalculatorApi
    {
        public int Calculate(string zipCodeA, string zipCodeB)
        {
            return 1000;
        }
    }
}