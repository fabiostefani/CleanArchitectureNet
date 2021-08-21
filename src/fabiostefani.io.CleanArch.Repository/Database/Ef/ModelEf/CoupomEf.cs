using System;

namespace fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf
{
    public class CoupomEf
    {
        public string? Code { get; set; }
        public int Percentage { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}