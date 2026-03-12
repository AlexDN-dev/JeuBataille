using JeuBataille.Enum;

namespace JeuBataille.Entity;

public class Carte
{
    private EnumCouleur Couleur { get; set; }
    private EnumCarteValeurs Valeur { get; set; }

    public Carte(EnumCouleur couleur, EnumCarteValeurs valeur)
    {
        Couleur = couleur;
        Valeur = valeur;
    }

    public void DisplayInfo()
    {
        Console.Write($"{Valeur} de {Couleur}");
    }
}