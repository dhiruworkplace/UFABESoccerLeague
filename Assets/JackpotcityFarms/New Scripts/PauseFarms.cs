using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseFarms : MonoBehaviour
{
    private void OnEnable()
    {
        SoundsFarms.instance?.PlaySound(0);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        SoundsFarms.instance?.PlaySound(0);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SoundsFarms.instance?.PlaySound(0);
    }

    public void Home()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Home");
        SoundsFarms.instance?.PlaySound(0);
    }
}