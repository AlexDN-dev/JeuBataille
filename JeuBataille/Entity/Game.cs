using JeuBataille.Enum;

namespace JeuBataille.Entity;

public class Game
{
    List<Carte> deck = new List<Carte>();
    Queue<Carte> player1Deck;
    Queue<Carte> player2Deck;

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
            Stack<Carte> pile = new Stack<Carte>();

            Console.WriteLine($"{round} : J1 => {player1Deck.Count} : J2 => {player2Deck.Count}");

            Carte player1Carte = player1Deck.Dequeue();
            Carte player2Carte = player2Deck.Dequeue();

            pile.Push(player1Carte);
            pile.Push(player2Carte);

            Console.WriteLine($"J1 : {player1Carte} | J2 : {player2Carte}");

            while (player1Carte.GetValue() == player2Carte.GetValue())
            {
                Console.WriteLine("BATAILLE !");

                if (player1Deck.Count < 2 || player2Deck.Count < 2) //défaite automatique si l'un des deux n'a plus assez de carte pour la bataille
                {
                    if (player1Deck.Count < player2Deck.Count)
                        Console.WriteLine("J1 ne peut pas continuer. J2 gagne !");
                    else
                        Console.WriteLine("J2 ne peut pas continuer. J1 gagne !");
        
                    return;
                }
                
                pile.Push(player1Deck.Dequeue());
                pile.Push(player2Deck.Dequeue());
                
                player1Carte = player1Deck.Dequeue();
                player2Carte = player2Deck.Dequeue();

                pile.Push(player1Carte);
                pile.Push(player2Carte);

                Console.WriteLine($"Bataille -> J1 : {player1Carte} | J2 : {player2Carte}");
            }

            if (player1Carte.GetValue() > player2Carte.GetValue())
            {
                Console.WriteLine("J1 gagne la manche.");

                foreach (var c in pile.Reverse())
                    player1Deck.Enqueue(c);
            }
            else
            {
                Console.WriteLine("J2 gagne la manche.");

                foreach (var c in pile.Reverse())
                    player2Deck.Enqueue(c);
            }

            round++;
        }
    }
    
    
}