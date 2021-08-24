using System;
using Xunit;

namespace fabiostefani.io.CleanArch.ApplicationTests.Config
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture>
    {
        
    }
    public class ClienteTestsFixture : IDisposable
    {
        public void Dispose()
        {
        }
    }
}