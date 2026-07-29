using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyPrefabs;
    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        bool found = false;
        int idx = 0;
        Enemy prefab = enemyPrefabs[0];
        Debug.Log(GameManager.Instance.CurrentEnemy);
        while(!found && idx < enemyPrefabs.Count)
        {
            if (enemyPrefabs[idx].name.Contains(GameManager.Instance.CurrentEnemy))
            {
                found = true;
                prefab = enemyPrefabs[idx];
            }
            idx++;
        }
        Enemy enemy = Instantiate(prefab,transform.position,transform.rotation);
        enemy.transform.parent = null;
        MatchManager.Instance.SetEnemy(enemy);
    }
}
