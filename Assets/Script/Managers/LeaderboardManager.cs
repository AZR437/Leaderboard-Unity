using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance { get; private set; }
    private SortedSet<Player> coinLeaderboard = new SortedSet<Player>(CoinCompare.Instance);
    private SortedSet<Player> levelLeaderboard = new SortedSet<Player>(LevelCompare.Instance);

    [SerializeField] private List<Player> coinLeaderboardDisplay = new List<Player>();
    [SerializeField] private List<Player> levelLeaderboardDisplay = new List<Player>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitLeaderboard(List<Player> players)
    {
        foreach (Player p in players)
        {
            coinLeaderboard.Add(p);
            levelLeaderboard.Add(p);
        }
        this.AssignPlaces();
        this.UpdateDisplayLists();
    }
    public void UpdateLeaderboard(Player player)
    {
        coinLeaderboard.Remove(player);
        levelLeaderboard.Remove(player);
        coinLeaderboard.Add(player);
        levelLeaderboard.Add(player);
        this.AssignPlaces();
        this.UpdateDisplayLists();
    }
    public void AddPlayer(Player player)
    {
        coinLeaderboard.Add(player);
        levelLeaderboard.Add(player);
        this.AssignPlaces();
        this.UpdateDisplayLists();
    }
    private void AssignPlaces()
    {
        int nPlace = 1;
        foreach (Player p in coinLeaderboard)
        {
            p.nCoinPlace = nPlace;
            nPlace++;
        }
        nPlace = 1;
        foreach (Player p in levelLeaderboard)
        {
            p.nLevelPlace = nPlace;
            nPlace++;
        }
    }
    private void UpdateDisplayLists()
    {
        coinLeaderboardDisplay = coinLeaderboard.ToList();
        levelLeaderboardDisplay = levelLeaderboard.ToList();
    }
    public List<Player> GetTopLevel(int count)
    {
        return levelLeaderboard.Take(count).ToList();
    }

    public List<Player> GetTopCoins(int count)
    {
        return coinLeaderboard.Take(count).ToList();
    }
    public Player GetPlayer(string name)
    {
        foreach (Player p in levelLeaderboard)
        {
            if (p.strName == name)
                return p;
        }
        return null;
    }
}
