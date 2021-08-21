using System;

namespace fabiostefani.io.CleanArch.Domain.entities
{
     public class OrderCode
     {
        public string Value { get; private set; }        
        public OrderCode(DateTime issueDate, int sequence)
        {
            Value = $"{issueDate.Year}{sequence.ToString().PadLeft(8,'0')}";            
        }
     }
}