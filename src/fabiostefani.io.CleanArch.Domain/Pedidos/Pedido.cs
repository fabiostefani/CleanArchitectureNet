using System.Linq;
using System.Collections.Generic;
using System;

namespace fabiostefani.io.CleanArch.Domain.Pedidos
{
    public class Pedido
    {
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; private set; }
        public Guid? VoucherId { get; private set; }
        public Voucher? Voucher { get; private set; }
        public bool VoucherUtilizado { get; private set; }  
        public decimal Desconto { get; private set; }
        private readonly List<PedidoItem> _pedidoItens;
        public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens;

        public Pedido()
        {
            _pedidoItens = new List<PedidoItem>();
        }

        public void Inicializar(Guid clienteId, string cpf)
        {
            var cpfCustommer = new Cpf(cpf);
            if (!cpfCustommer.IsValid()) throw new Exception("CPF Inválido.");
            ClienteId = clienteId;
        }

        private void CalcularValorPedido()
        {
            ValorTotal = PedidoItens.Sum(x => x.CalcularValor());            
            CalcularValorTotalDesconto();
        }

        public bool PedidoItemExistente(PedidoItem pedidoItem)
        {
            return _pedidoItens.Any(x => x.ProdutoId == pedidoItem.ProdutoId);
        }

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            if (PedidoItemExistente(pedidoItem))
            {
                var itemExistente = _pedidoItens.FirstOrDefault(x => x.ProdutoId == pedidoItem.ProdutoId);
                if (itemExistente == null)
                {
                    throw new Exception("Item do Pedido não localizado.");
                }
                itemExistente.AdicionarUnidades(pedidoItem.Quantidade);
                pedidoItem = itemExistente;

                _pedidoItens.Remove(itemExistente);
            }
            _pedidoItens.Add(pedidoItem);
            CalcularValorPedido();
        }

        private void ValidarPedidoItemInexistente(PedidoItem pedidoItem)
        {
            if (!PedidoItemExistente(pedidoItem)) 
                throw new Exception($"O item não existe no pedido.");   
        }

        public void AtualizarItem(PedidoItem pedidoItem)
        {
            ValidarPedidoItemInexistente(pedidoItem);            

            var itemExistente = PedidoItens.FirstOrDefault(x => x.ProdutoId == pedidoItem.ProdutoId);
            if (itemExistente == null)
            {
                throw new Exception("Item do Pedido não localizado.");
            }
            _pedidoItens.Remove(itemExistente);
            _pedidoItens.Add(pedidoItem);

            CalcularValorPedido();
        }

        public void AplicarVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherId = voucher.Id;
            VoucherUtilizado = true;
            CalcularValorTotalDesconto();
        }

        private void CalcularValorTotalDesconto()
        {
            if (!VoucherUtilizado) return;
            decimal desconto = 0;
            var valor = ValorTotal;
            if (Voucher == null)
            {
                throw new Exception("Voucher não aplicado.");
            }
            desconto = (ValorTotal * Voucher.PercentualDesconto) / 100;                                                    
            valor -= desconto;            
            Desconto = desconto;
        }
    }
}