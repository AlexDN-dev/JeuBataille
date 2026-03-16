using JeuBataille.Enum;

namespace JeuBataille.Entity;

public class Carte
{
    public EnumCouleur Couleur { get; }
    public EnumCarteValeurs Valeur { get; }

    public Carte(EnumCouleur couleur, EnumCarteValeurs valeur)
    {
        Couleur = couleur;
        Valeur = valeur;
    }

    public override string ToString()
    {
        return ($"{Valeur} de {Couleur}");
    }

    public int GetValue()
    {
        return (int)Valeur;
    }

    
}