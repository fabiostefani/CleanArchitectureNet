using System;

namespace fabiostefani.io.CleanArch.Domain.Pedidos
{
    public class PedidoItem
    {
        public Guid ProdutoId { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public PedidoItem(Guid produtoId, string descricao, int quantidade, decimal valorUnitario)
        {
            Descricao = descricao;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ProdutoId = produtoId;
        }

        public void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }

        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }
    }
}