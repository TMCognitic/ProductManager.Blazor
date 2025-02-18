using Tools.CommandQuerySeparation.Commands;

namespace ProductManager.Blazor.Domain.Commands
{
    public class ModifierProduitCommand : ICommandDefinition
    {
        public int Id { get; }
        public string Nom { get; }
        public double Prix { get; }

        public ModifierProduitCommand(int id, string nom, double prix)
        {
            Id = id;
            Nom = nom;
            Prix = prix;
        }
    }
}
