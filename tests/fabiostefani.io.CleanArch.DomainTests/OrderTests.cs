using System;
using Xunit;
using fabiostefani.io.CleanArch.Domain;

namespace fabiostefani.io.CleanArch.DomainTests
{
    public class OrderTests
    {
        [Fact]
        public void NaoDeveCriarUmPedidoComCpfInvalido()
        {            
            var cpf = "111.111.111-11";         
            Exception ex = Assert.Throws<Exception>(() => new Order(cpf));            
            Assert.Equal("Invalid CPF", ex.Message);            
        }

        [Fact]
        public void DeveCriarUmPedidoCom3Itens()
        {
            var cpf = "778.278.412-36";
            var order = new Order(cpf);
            order.AddItem("Guitarra", 1000, 2);
            order.AddItem("Amplificador", 5000, 1);
            order.AddItem("Cabo", 30, 3);        
            Assert.Equal(7090, order.GetTotal());
        }

        [Fact]
        public void DeveCriarPedidoComCupomDesconto()
        {
            var cpf = "778.278.412-36";
            var order = new Order(cpf);
            order.AddItem("Guitarra", 1000, 2);
            order.AddItem("Amplificador", 5000, 1);
            order.AddItem("Cabo", 30, 3);
            order.AddCoupon(new Coupon("VALE-20",20));
            Assert.Equal(5672, order.GetTotal());
        }
    } 
}