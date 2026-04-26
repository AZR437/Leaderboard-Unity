using System.Collections.Generic;
using UnityEngine;


public class LevelCompare : IComparer<Player>
{
    public static readonly LevelCompare Instance = new LevelCompare();

    public int Compare(Player a, Player b)
    {
        int cmp = b.nLevel.CompareTo(a.nLevel);
        if (cmp != 0) 
            return cmp;
        else
            return b.nCoins.CompareTo(a.nCoins);
    }
}
