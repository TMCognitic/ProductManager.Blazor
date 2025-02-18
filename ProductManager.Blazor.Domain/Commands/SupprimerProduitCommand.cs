using CommandQuerySeparation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Blazor.Domain.Commands
{
    public class SupprimerProduitCommand : ICommandDefinition
    {
        public int Id { get; }

        public SupprimerProduitCommand(int id)
        {
            Id = id;
        }
    }
}
