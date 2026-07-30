using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    private string defeatedEnemy;
    public string DefeatedEnemy => defeatedEnemy;
    private string currentEnemy;
    public string CurrentEnemy => currentEnemy;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetEnemyName(string enemy)
    {
        currentEnemy = enemy;
    }

    public void SwitchToExploreScene()
    {
        ScenesManager.Instance.SetNextScene("ExploreScene");
        ScenesManager.Instance.LoadScene();
    }

    public void DefeatEnemy(string name)
    {
        defeatedEnemy = name;
        SwitchToExploreScene();
    }
}
