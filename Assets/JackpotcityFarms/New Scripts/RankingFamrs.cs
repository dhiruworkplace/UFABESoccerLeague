using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankingFamrs : MonoBehaviour
{
    public Transform parent;
    public RankFarms playerDetail;

    public List<string> names = new List<string>()
    {
        "Arjun Patel",
        "Neha Sharma",
        "Rohan Verma",
        "Ananya Gupta",
        "Karan Mehta",
        "Priya Singh",
        "Amit Malhotra",
        "Pooja Kapoor",
        "Rahul Khanna",
        "Sneha Iyer",
        "John Carter",
        "Emily Johnson",
        "Michael Brown",
        "Sophia Williams",
        "David Miller",
        "Olivia Anderson",
        "James Thompson",
        "Emma Wilson",
        "Daniel Martinez",
        "Isabella Garcia",
        "Liam O'Connor",
        "Chloe Dubois",
        "Lucas Moreau",
        "Sofia Rossi",
        "Marco Bianchi",
        "Elena Petrova",
        "Ivan Kuznetsov",
        "Anna Kowalski",
        "Hiroshi Tanaka",
        "Yuki Nakamura",
        "Ahmed Hassan",
        "Fatima Al-Sayed",
        "Omar Khalid",
        "Aisha Rahman",
        "Yusuf Farouk",
        "Zara Mahmood",
        "Carlos Mendoza",
        "Maria Gonzalez",
        "Juan Rodriguez",
        "Camila Torres",
        "Diego Ramirez",
        "Valentina Cruz",
        "Noah Smith",
        "Ava Taylor",
        "Ethan Walker",
        "Mia Collins",
        "Benjamin Harris",
        "Lily Scott"
    };

    // Start is called before the first frame update
    void OnEnable()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        List<string> nameList = names.OrderBy(x => Random.value).ToList();

        List<PlayerData> players = new List<PlayerData>();
        PlayerData me = new PlayerData();
        me.me = true;
        me.name = "You";
        me.points = PlayerPrefs.GetInt("gold");
        players.Add(me);

        for (int i = 0; i < parent.childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
        int min = 1000;
        int max = 2000;
        if (me.points > 1000)
        {
            min = (me.points - 5);
            max = (me.points + 5);
        }

        for (int i = 0; i < 9; i++)
        {
            PlayerData player = new PlayerData();
            player.me = false;
            player.name = nameList[i];
            player.points = Random.Range(min, max);
            players.Add(player);
        }
        players = players.OrderByDescending(x => x.points).ToList();

        for (int i = 0; i < 10; i++)
        {
            RankFarms pd = Instantiate(playerDetail, parent);
            pd.SetData(players[i].me, (i + 1), players[i].name, players[i].points);
        }
    }
}

public class PlayerData
{
    public bool me;
    public string name;
    public int points;
}