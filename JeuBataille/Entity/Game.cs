using JeuBataille.Enum;

namespace JeuBataille.Entity;

public class Game
{
    private List<Carte> deck = new List<Carte>();
    Queue<Carte> player1Deck;
    private Queue<Carte> player2Deck;

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

        player1Deck = new Queue<Carte>(deck.Take(26));
        player2Deck = new Queue<Carte>(deck.Skip(26));
        
        StartGame();
    }

    public void StartGame()
    {
        int round = 0;
        while (player1Deck.Count > 0 && player2Deck.Count > 0)
        {
            Console.WriteLine($"{round} : J1 => {player1Deck.Count} : J2 => {player2Deck.Count}");
            Carte player1Carte = player1Deck.Dequeue();
            Carte player2Carte = player2Deck.Dequeue();

            Console.WriteLine($"J1 : {player1Carte} | J2 : {player2Carte}");

            if (player1Carte.GetValue() > player2Carte.GetValue())
            {
                Console.WriteLine("J1 gagne la manche.");
                player1Deck.Enqueue(player1Carte);
                player1Deck.Enqueue(player2Carte);
            }
            else if (player2Carte.GetValue() > player1Carte.GetValue())
            {
                Console.WriteLine("J2 gagne la manche.");
                player2Deck.Enqueue(player1Carte);
                player2Deck.Enqueue(player2Carte);
            }
            else
            {
                Console.WriteLine("Égalité.");
                player1Deck.Enqueue(player1Carte);
                player2Deck.Enqueue(player2Carte);
            }

            round++;
        }
    }
    
    
}