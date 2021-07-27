using fabiostefani.io.CleanArch.Domain;
using Xunit;

namespace fabiostefani.io.CleanArch.DomainTests
{
    public class CpfTests
    {
        [Theory]
        [InlineData("03749377960", true)]
        [InlineData("00000000000", false)]
        [InlineData("86446422799", false)]
        [InlineData("86446422784", true)]
        [InlineData("864.464.227-84", true)]
        [InlineData("91720489726", true)]
        [InlineData("a1720489726", false)]
        [InlineData("", false)]
        public void Cpf_IsValid_DeveRetornarTrueOrFalse(string inscricao, bool expected)
        {
            //Given
            var cpf = new Cpf(inscricao);

            //When
            var result = cpf.IsValid();

            //Then
            Assert.Equal(expected, result);
        }
    }
}