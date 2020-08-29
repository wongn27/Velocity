using System.Collections.Generic;
using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Core.Repository
{
    public class ClientRepository : CrudRepositoryBase<Client>
    {
        public ClientRepository(VelocityContext context) : base(context)
        {

        }
    }
}
