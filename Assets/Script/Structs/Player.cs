using UnityEngine;
[System.Serializable]
public class Player
{
    public string strName;
    public int nLevel;
    public int nCoins;
    public int nCoinPlace;
    public int nLevelPlace;
    public Player(string strName, int nLevel, int nCoins)
    {
        this.strName = strName;
        this.nLevel = nLevel;
        this.nCoins = nCoins;
        this.nCoinPlace = 0;
        this.nLevelPlace = 0;
    }
}
