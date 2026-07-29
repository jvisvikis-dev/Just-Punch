using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    //[SerializeField] private Enemy defaultEnemyPrefab;
    public string currentEnemy;
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
}
