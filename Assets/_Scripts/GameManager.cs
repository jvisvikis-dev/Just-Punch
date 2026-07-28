using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    [SerializeField] private Enemy defaultEnemyPrefab;
    private Enemy currentEnemy;
    public Enemy CurrentEnemy => currentEnemy;

    private void Awake()
    {
        if(instance)
            Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
        currentEnemy = defaultEnemyPrefab;
    }

    public void SetEnemyPrefab(Enemy enemy)
    {
        currentEnemy = enemy;
    }

    public void SwitchToExploreScene()
    {
        ScenesManager.Instance.SetNextScene("ExploreScene");
        ScenesManager.Instance.LoadScene();
    }
}
