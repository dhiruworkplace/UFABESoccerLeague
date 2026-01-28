using System.Collections.Generic;
using UnityEngine;

public class ShopFarms : MonoBehaviour
{
    public GameObject[] Themes;
    private List<int> prices = new List<int>() { 10000, 20000, 30000, 40000, 10000, 20000, 30000, 40000 };
    public GameObject noCoinPanel;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("p0", 1);
        //PlayerPrefs.Save();

        CheckAllTheme();
    }

    private void CheckAllTheme()
    {
        for (int i = 0; i < Themes.Length; i++)
        {
            GameObject m = Themes[i];
            if (PlayerPrefs.GetInt("p" + i, 0) == 1)
            {
                m.transform.GetChild(1).gameObject.SetActive(false);
                m.transform.GetChild(2).gameObject.SetActive(true);
                m.transform.GetChild(3).gameObject.SetActive(false);

                //if (StaticFligher.selectedTheme.Equals(i))
                //{
                //    m.transform.GetChild(3).gameObject.SetActive(true);
                //}
            }
        }
    }

    public void SelectTheme(int index)
    {
        if (PlayerPrefs.GetInt("p" + index, 0) == 1)
        {
            //if (!Container.selectedBg.Equals(index))
            {
                FarmsApp.selectedTheme = index;
                CheckAllTheme();
            }
        }
        else
        {
            int coin = PlayerPrefs.GetInt("gold");
            if (coin >= prices[index])
            {
                coin -= prices[index];
                PlayerPrefs.SetInt("gold", coin);
                PlayerPrefs.Save();
                Themes[index].transform.GetChild(1).gameObject.SetActive(false);
                Themes[index].transform.GetChild(2).gameObject.SetActive(true);
                Themes[index].transform.GetChild(3).gameObject.SetActive(false);
                PlayerPrefs.SetInt("p" + index, 1);
                PlayerPrefs.Save();

                FindAnyObjectByType<HomeFarms>().SetCoins();
            }
            else
                noCoinPanel.SetActive(true);
        }
        SoundsFarms.instance?.PlaySound(0);
    }
}