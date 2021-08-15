using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace fabiostefani.io.CleanArch.Domain
{
    public class Cpf
    {
        const int FACTOR_DIGIT_1 = 10;
        const int FACTOR_DIGIT_2 = 11;
        const int MAX_DIGITS_1 = 9;
        const int MAX_DIGITS_2 = 10; 
        public string Inscricao { get; set; }
        
        public Cpf(string inscricao)
        {
            Inscricao = inscricao;
        }

        private void ExtractDigits(string cpf)
        {
            Inscricao = Regex.Replace(cpf, @"[^\d]", string.Empty);
        }

        private bool InvalidLenght()
        {
            return Inscricao.Length != 11;
        }

        private bool IsBLocked()
        {
            var inscricaoArray = Inscricao.ToArray();
            return inscricaoArray.All(x => x == inscricaoArray[0]);
        }

        private int CalculateDigit(int factor, int max)
        {
            int total = 0;            
            foreach (var item in Inscricao.ToList().GetRange(0, max))
            {
                total += Convert.ToInt32(char.GetNumericValue(item)) * factor--;
            }
            int digit = (total % 11 < 2) ? 0 : (11 - total % 11);
            return digit;
        }

        private string ExtractCheckerDigit()
        {
	        return Inscricao.Substring(9,2);  
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Inscricao)) return false;
            ExtractDigits(Inscricao);
            if (InvalidLenght()) return false;            
            if (IsBLocked()) return false;
            int digit1 = CalculateDigit(FACTOR_DIGIT_1, MAX_DIGITS_1);
            int digit2 = CalculateDigit(FACTOR_DIGIT_2, MAX_DIGITS_2);
            string checkerDigit = ExtractCheckerDigit();  
	        string calculatedDigit = $"{digit1}{digit2}";  
	        return checkerDigit == calculatedDigit;
        }
    }
}