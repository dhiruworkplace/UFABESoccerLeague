using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoccerbetHome : MonoBehaviour
{
    public Text coinText;

    public GameObject agreementPanel;
    public GameObject tcTick;
    public GameObject ppTick;
    public Button acceptBtn;

    public Text questTimer;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        SetCoins();

        if (!PlayerPrefs.HasKey("agreement"))
        {
            PlayerPrefs.SetInt("agreement", 1);
            PlayerPrefs.Save();
            agreementPanel.SetActive(true);
        }
        InvokeRepeating(nameof(CheckQuest), 0f, 1f);
    }

    public void TickAgreement(bool isTc)
    {
        if (isTc)
        {
            tcTick.SetActive(!tcTick.activeSelf);
        }
        else
        {
            ppTick.SetActive(!ppTick.activeSelf);
        }
        acceptBtn.interactable = (tcTick.activeSelf && ppTick.activeSelf);
        ClickSound();
    }

    public void SetCoins()
    {
        coinText.text = SoccerbetApp.coins.ToString();
    }

    public void Play()
    {
        ClickSound();
        SceneManager.LoadScene("Game");
    }

    public void ClickSound()
    {
        SoundsSoccerbet.instance?.PlaySound(0);
    }

    private void StopTimer()
    {
        CancelInvoke(nameof(CheckQuest));
    }

    private void CheckQuest()
    {
        DateTime lastDT = new DateTime();
        if (!PlayerPrefs.HasKey("lastSpin"))
        {
            //PlayerPrefs.SetString("lastSpin", DateTime.Now.AddHours(24).ToString());
            //PlayerPrefs.Save();
            questTimer.text = "Claim Now!";
            StopTimer();
            return;
        }
        lastDT = DateTime.Parse(PlayerPrefs.GetString("lastSpin"));

        TimeSpan diff = (lastDT - DateTime.Now);
        questTimer.text = string.Format("{0:D2}:{1:D2}:{2:D2}", diff.Hours, diff.Minutes, diff.Seconds);

        if (diff.TotalSeconds <= 0)
        {
            StopTimer();
            questTimer.text = "Claim Now!";
        }
    }

    private void StartTimer()
    {
        PlayerPrefs.SetString("lastSpin", DateTime.Now.AddHours(24).ToString());
        PlayerPrefs.Save();

        InvokeRepeating(nameof(CheckQuest), 0f, 1f);
    }

    public void ClaimBtn()
    {
        if (questTimer.text.Equals("Claim Now!"))
        {
            SoccerbetApp.coins += 1000;
            Invoke(nameof(StartTimer), 0f);
            SetCoins();
        }
    }
}