using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private static ScenesManager instance;
    public static ScenesManager Instance => instance;
    private string sceneName;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetNextScene(string scene)
    {
        sceneName = scene;
    }

    public void ReloadActiveScene()
    {
        sceneName = SceneManager.GetActiveScene().name;
        LoadScene();
    }
}
