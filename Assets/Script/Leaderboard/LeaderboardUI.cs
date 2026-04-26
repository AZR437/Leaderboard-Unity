using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LeaderboardUI : MonoBehaviour
{
    public static LeaderboardUI Instance { get; private set; }

    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private VisualTreeAsset entryTemplate;

    private VisualElement root;
    private VisualElement container;
    private ScrollView levelList;
    private ScrollView coinsList;
    private Button levelTabButton;
    private Button coinsTabButton;
    private Button closeButton;
    private Button leaderboardButton;

    private Label playerCardName;
    private Label playerCardLevel;
    private Label playerCardCoins;
    private Label playerCardLevelPlace;
    private Label playerCardCoinPlace;

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
    }

    private void Start()
    {
        root = uiDocument.rootVisualElement.Q<VisualElement>("Root");
        container = root.Q<VisualElement>("Container");
        levelList = root.Q<ScrollView>("LevelList");
        coinsList = root.Q<ScrollView>("CoinsList");
        levelTabButton = root.Q<Button>("LevelTabButton");
        coinsTabButton = root.Q<Button>("CoinsTabButton");
        closeButton = root.Q<Button>("CloseButton");
        leaderboardButton = root.Q<Button>("LeaderboardOpen");

        playerCardName = root.Q<Label>("PlayerCardName");
        playerCardLevel = root.Q<Label>("PlayerCardLevel");
        playerCardCoins = root.Q<Label>("PlayerCardCoins");
        playerCardLevelPlace = root.Q<Label>("PlayerCardLevelPlace");
        playerCardCoinPlace = root.Q<Label>("PlayerCardCoinPlace");

        levelTabButton.clicked += () => SwitchTab(true);
        coinsTabButton.clicked += () => SwitchTab(false);
        closeButton.clicked += CloseLeaderboard;
        leaderboardButton.clicked += OpenLeaderboard;

        SwitchTab(true);
    }

    public void OpenLeaderboard()
    {
        PopulateList(levelList, LeaderboardManager.Instance.GetTopLevel(20), isLevel: true);
        PopulateList(coinsList, LeaderboardManager.Instance.GetTopCoins(20), isLevel: false);
        UpdatePlayerCard(true);

        leaderboardButton.SetEnabled(false);
        root.style.visibility = Visibility.Visible;
        container.style.display = DisplayStyle.Flex;
        container.RemoveFromClassList("popup-visible");
        container.AddToClassList("popup-hidden");

        container.schedule.Execute(() =>
        {
            container.RemoveFromClassList("popup-hidden");
            container.AddToClassList("popup-visible");
        }).StartingIn(10);
    }

    public void CloseLeaderboard()
    {
        container.RemoveFromClassList("popup-visible");
        container.AddToClassList("popup-hidden");

        container.schedule.Execute(() =>
        {
            container.style.display = DisplayStyle.None;
            root.style.visibility = Visibility.Hidden;
            leaderboardButton.SetEnabled(true);
        }).StartingIn(300);
    }

    private void SwitchTab(bool showLevel)
    {
        levelList.style.display = showLevel ? DisplayStyle.Flex : DisplayStyle.None;
        coinsList.style.display = showLevel ? DisplayStyle.None : DisplayStyle.Flex;

        if (showLevel)
        {
            levelTabButton.AddToClassList("tab-active");
            coinsTabButton.RemoveFromClassList("tab-active");
        }
        else
        {
            coinsTabButton.AddToClassList("tab-active");
            levelTabButton.RemoveFromClassList("tab-active");
        }
        UpdatePlayerCard(showLevel);
    }

    private void PopulateList(ScrollView list, List<Player> players, bool isLevel)
    {
        list.Clear();

        for (int i = 0; i < players.Count; i++)
        {
            Player p = players[i];
            int place = i + 1;

            VisualElement row = entryTemplate.CloneTree();

            Label placeLabel = row.Q<Label>("Place");
            Label nameLabel = row.Q<Label>("PlayerName");
            Label valueLabel = row.Q<Label>("Value");

            placeLabel.text = place.ToString();
            nameLabel.text = p.strName;
            valueLabel.text = isLevel ? "Lv " + p.nLevel : p.nCoins.ToString();

            if (place == 1) placeLabel.AddToClassList("place-1");
            else if (place == 2) placeLabel.AddToClassList("place-2");
            else if (place == 3) placeLabel.AddToClassList("place-3");

            list.Add(row);
        }
    }
    private void UpdatePlayerCard(bool isLevel)
    {
        Player myPlayer = LeaderboardManager.Instance.GetPlayer("Carlos Arquillo");
        if (myPlayer == null) return;

        playerCardName.text = myPlayer.strName;

        if (isLevel)
        {
            playerCardLevel.text = "Lv " + myPlayer.nLevel;
            playerCardLevelPlace.text = "#" + myPlayer.nLevelPlace;
            playerCardCoins.style.display = DisplayStyle.None;
            playerCardCoinPlace.style.display = DisplayStyle.None;
            playerCardLevel.style.display = DisplayStyle.Flex;
            playerCardLevelPlace.style.display = DisplayStyle.Flex;
        }
        else
        {
            playerCardCoins.text = myPlayer.nCoins.ToString() + " coins";
            playerCardCoinPlace.text = "#" + myPlayer.nCoinPlace;
            playerCardLevel.style.display = DisplayStyle.None;
            playerCardLevelPlace.style.display = DisplayStyle.None;
            playerCardCoins.style.display = DisplayStyle.Flex;
            playerCardCoinPlace.style.display = DisplayStyle.Flex;
        }
    }
}