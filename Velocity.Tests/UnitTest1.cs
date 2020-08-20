using NUnit.Framework;
using Velocity.Data;

namespace Velocity.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var context = new VelocityContext();
            var clients = context.GetDbSetFor<Client>(typeof(Client));
            clients.Add(new Client() { CompanyName = "abc" });

            
         }
    }
}