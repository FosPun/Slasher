using UnityEngine;

public class CoinsChangeEvent : GameEvent
{
    public int Coins;
    public CoinsChangeEvent(int coins) : base("CoinsChange")
    {
        Coins = coins;
    }
}
