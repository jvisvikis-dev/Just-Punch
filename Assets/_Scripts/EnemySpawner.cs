using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(GameManager.Instance.CurrentEnemy,transform.position,transform.rotation);
        enemy.transform.parent = null;
        MatchManager.Instance.SetEnemy(enemy);
    }
}
