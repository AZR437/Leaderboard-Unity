using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<Player> players = new List<Player>();
        for (int i = 0; i < 99; i++)
        {
            string strName = "Player" + (i + 1);
            int nLevel = Random.Range(1, 501);
            int nCoins = Random.Range(0, 1000001);
            Player player = new Player(strName, nLevel, nCoins);
            players.Add(player);
        }
        Player player1 = new Player("Carlos Arquillo",23,5000);
        players.Add(player1);
        Debug.Log("Player count: " + players.Count);
        LeaderboardManager.Instance.InitLeaderboard(players);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
