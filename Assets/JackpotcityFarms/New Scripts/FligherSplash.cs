using UnityEngine;
using UnityEngine.SceneManagement;

public class FligherSplash : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(ChangeScene), 2.5f);
    }

    private void ChangeScene()
    {
        SceneManager.UnloadSceneAsync("Splash");
        SceneManager.LoadScene("Home");
    }
}