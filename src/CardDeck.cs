using System;
using System.Collections.Generic;

public class CardDeck
{
    public CardDeck(){
        Cards = new List<Card>();
        foreach(Suit suit in Enum.GetValues(typeof(Suit))){
            foreach(Rank rank in Enum.GetValues(typeof(Rank))){
                Cards.Add(new Card(){
                    Rank = rank,
                    Suit = suit
                });
            }
        }
    }

    public int GameId { get; set; }

    public List<Card> Cards { get; private set; }
}

public class Card{
    public Suit Suit { get; set; }
    public Rank Rank { get; set; }

    public int Value{
        get {
            return (int)this.Suit * (int)this.Rank;
        } 
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}


public enum Rank{
    Ace = 1, 
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    King,
    Queen,
}

public enum Suit{
    Club = 1,
    Diamond,
    Heart,
    Spade,
}