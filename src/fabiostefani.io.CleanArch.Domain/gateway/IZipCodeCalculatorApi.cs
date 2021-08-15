namespace fabiostefani.io.CleanArch.Domain
{
    public interface IZipCodeCalculatorApi
    {
        int Calculate(string zipCodeA, string zipCodeB);
    }
}