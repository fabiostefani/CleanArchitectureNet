using System;
using System.Linq;
using fabiostefani.io.CleanArch.Domain.Pedidos;
using Xunit;

namespace fabiostefani.io.CleanArch.DomainTests.Pedidos
{
    public class PedidoTests
    {
        private readonly Pedido _pedido;
        private readonly Guid _produtoId;
        private readonly Guid _clienteId;
        public PedidoTests()
        {
            _pedido = new Pedido();
            _produtoId = Guid.NewGuid();
            _clienteId = Guid.NewGuid();;
        }

        [Fact(DisplayName = "Inicializar Novo Pedido")]        
        public void Inicializar_NovoPedido_DeveGerarExceptionQuandoCpfInvalido()
        {
            //ARRANGE
            string cpf = "00000000000";
            //ACT
            //ASSERT
            Assert.Throws<Exception>(() => _pedido.Inicializar(_clienteId, cpf));
        }

        [Fact(DisplayName = "Inicializar Novo Pedido")]        
        public void Inicializar_NovoPedido_DeveAtualizarClienteId()
        {
            //ARRANGE
            string cpf = "86446422784";
            //ACT
            _pedido.Inicializar(_clienteId, cpf);
            //ASSERT
            Assert.Equal(_clienteId, _pedido.ClienteId);
        }

        [Fact(DisplayName = "Adicionar Item Novo Pedido")]        
        public void AdicionarItemPedido_NovoPedido_DeveAtualizarValor()
        {
            //ARRANGE            
            var pedidoItem = new PedidoItem(_produtoId, "Produto Teste", 2, 100);
            
            //ACT
            _pedido.AdicionarItem(pedidoItem);

            //ASSERT
            Assert.Equal(200, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Adicionar Item Pedido Existente")]
        public void AdicionarItemPedido_itemExistente_DeveIncrementarUnidadesSomarValores()
        {
            //ARRANGE            
            
            var pedidoItem = new PedidoItem(_produtoId, "Produto Teste", 2, 100);
            _pedido.AdicionarItem(pedidoItem);

            var pedidoItem2 = new PedidoItem(_produtoId, "Produto Teste", 1, 100);
            //ACT

            _pedido.AdicionarItem(pedidoItem2);

            //ASSERT
            Assert.Equal(300, _pedido.ValorTotal);
            Assert.Equal(1, _pedido.PedidoItens.Count);
            Assert.Equal(3, _pedido.PedidoItens.FirstOrDefault(x => x.ProdutoId == _produtoId).Quantidade);
        }

        [Fact(DisplayName = "Atualizar Item Pedido Validar Total")]        
        public void AtualizarItemPedido_PedidoComProdutosDiferentes_DeveAtualizarValorTotal()
        {
            //ARRANGE                        
            var pedidoItemExistente1 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 2, 100);
            var pedidoItemExistente2 = new PedidoItem(_produtoId, "Produto Teste", 3, 15);
            _pedido.AdicionarItem(pedidoItemExistente1);
            _pedido.AdicionarItem(pedidoItemExistente2);
            
            var pedidoItemAtualizado = new PedidoItem(_produtoId, "Produto Teste", 5, 15);
            var totalPedido = pedidoItemExistente1.Quantidade * pedidoItemExistente1.ValorUnitario +
                              pedidoItemAtualizado.Quantidade * pedidoItemExistente2.ValorUnitario;

            //ACT 
            _pedido.AtualizarItem(pedidoItemAtualizado);

            //ASSERT
            Assert.Equal(totalPedido, _pedido.ValorTotal);

        }

        [Fact(DisplayName = "Aplicar voucher tipo percentual desconto")]
        public void AplicarVoucher_VoucherTipoPercentualDesconto_DeveDescontarDoValorTotal()
        {
            // Arrange            
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto Xpto", 2, 100);
            var pedidoItem2 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 3, 15);
            _pedido.AdicionarItem(pedidoItem1);
            _pedido.AdicionarItem(pedidoItem2);

            var voucher = new Voucher("PROMO-15-OFF", 15);

            var valorDesconto = (_pedido.ValorTotal * voucher.PercentualDesconto) / 100;
            var valorTotalComDesconto = _pedido.ValorTotal - valorDesconto;

            // Act
            _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.Equal(valorTotalComDesconto, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Aplicar voucher recalcular desconto na modificação do pedido")]        
        public void AplicarVoucher_ModificarItensPedido_DeveCalcularDescontoValorTotal()
        {
            // Arrange            
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto Xpto", 2, 100);
            _pedido.AdicionarItem(pedidoItem1);

            var voucher = new Voucher("PROMO-15-OFF", 15);
            _pedido.AplicarVoucher(voucher);

            var pedidoItem2 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 4, 25);

            // Act
            _pedido.AdicionarItem(pedidoItem2);

            // Assert
            var valorDesconto = (_pedido.PedidoItens.Sum(i => i.Quantidade * i.ValorUnitario) * voucher.PercentualDesconto) / 100;
            var totalEsperado = _pedido.PedidoItens.Sum(i => i.Quantidade * i.ValorUnitario) - valorDesconto;
            Assert.Equal(totalEsperado, _pedido.ValorTotal);
        }
    }
}