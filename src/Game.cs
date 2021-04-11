using System;
using System.Collections.Generic;
using System.Linq;

public class Game
{
    public Game(int GameId)
    {
        this.GameId = GameId;
        this.Deck = new CardDeck();
        this.DrawnCards = new List<Card>();
        this.Players = new List<Player>();

        this.DrawCard();
    }
    public int GameId { get; set; }
    public List<Player> Players { get; set; }

    private CardDeck Deck { get; set; }

    private List<Card> DrawnCards { get; set; }

    public Card CurrentCard
    {
        get
        {
            return DrawnCards.Last();
        }
    }


    public bool IsFinished { 
        get {
            return this.Moves == this.Deck.Cards.Count;
        }
    }
    
    public int Moves
    {
        get
        {
            return DrawnCards.Count;
        }
    }

    public Card DrawCard()
    {
        if (IsFinished){
            return CurrentCard;
        }

        List<Card> AvailableCards = this.Deck.Cards
            .Where(available => !DrawnCards
                .Any(
                    drawn => 
                    drawn.Rank == available.Rank && 
                    drawn.Suit == available.Suit))
            .ToList();

        Card newCurrentCard = AvailableCards[new Random().Next(0, AvailableCards.Count - 1)];
        DrawnCards.Add(newCurrentCard);

        return newCurrentCard;
    }

    public List<Player> Guess(int PlayerId, bool NextHiguerGuess)
    {
        if (IsFinished){
            return Players.OrderByDescending(p => p.Points).ToList();
        }

        Card currentCard = CurrentCard;
        Card nextCard = DrawCard();

        bool nextWasHigher = nextCard.Value > currentCard.Value;

        Player player = Players.FirstOrDefault(s => s.Id == PlayerId);

        if (player == null)
        {
            player = new Player() { Id = PlayerId };
            Players.Add(player);
        }

        if (nextWasHigher == NextHiguerGuess)
        {
            player.Points++;
        }

        player.Attempts++;

        return Players.OrderByDescending(p => p.Points).ToList();
    }
}