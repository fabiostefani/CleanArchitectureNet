using System;

namespace fabiostefani.io.CleanArch.Domain.Pedidos
{
    public class Voucher
    {
        public Guid Id { get; set; }
        public string Codigo { get; private set; }
        public decimal PercentualDesconto { get; private set; }        

        public Voucher(string codigo, decimal percentualDesconto)
        {
            Codigo = codigo;            
            PercentualDesconto = percentualDesconto;            
        }
    }
}