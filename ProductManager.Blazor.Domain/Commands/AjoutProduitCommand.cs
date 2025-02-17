using CommandQuerySeparation.Commands;

namespace ProductManager.Blazor.Domain.Commands
{
    public class AjoutProduitCommand : ICommandDefinition
    {
        public string Nom { get; }
        public double Prix { get; }

        public AjoutProduitCommand(string nom, double prix)
        {
            Nom = nom;
            Prix = prix;
        }
    }
}
