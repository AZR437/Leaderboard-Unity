using System.Collections.Generic;
using UnityEngine;

public class CoinCompare : IComparer<Player>
{
    public static readonly CoinCompare Instance = new CoinCompare();

    public int Compare(Player a, Player b)
    {
        int cmp = b.nCoins.CompareTo(a.nCoins);
        if (cmp != 0) 
            return cmp;
        else
            return b.nLevel.CompareTo(a.nLevel);
    }
}
