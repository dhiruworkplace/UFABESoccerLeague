using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankFarms : MonoBehaviour
{
    public bool me;
    public Image panel;
    public TextMeshProUGUI noText;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI points;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetData(bool me, int no, string name, int _points)
    {
        noText.text = no.ToString();
        playerName.text = name;
        points.text = _points.ToString();
    }

    private string NoFormat(int no)
    {
        if (no.Equals(1))
            return no + "st";
        else if (no.Equals(2))
            return no + "nd";
        else if (no.Equals(3))
            return no + "rd";
        else
            return no + "th";
    }
}