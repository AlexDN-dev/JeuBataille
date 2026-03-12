using JeuBataille.Enum;

namespace JeuBataille.Entity;

public class Game
{
    private List<Carte> deck = new List<Carte>();

    public Game()
    {
        Initialize();
    }

    public void Initialize()
    {
        foreach (EnumCouleur couleur in EnumCouleur.GetValues<EnumCouleur>())
        {
            foreach (EnumCarteValeurs valeur in EnumCarteValeurs.GetValues<EnumCarteValeurs>())
            {
                deck.Add(new Carte(couleur, valeur));
            }
        }

        deck = deck.OrderBy(x => Guid.NewGuid()).ToList();
    }
}