using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : Interactable
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private string fightSceneName;

    public override void Use()
    {
        isClickable = false;
        SetupFight();
    }

    public void SetupFight()
    {
        GameManager.Instance.SetEnemyName(enemyPrefab.name);
        ScenesManager.Instance.SetNextScene(fightSceneName);
        ScenesManager.Instance.LoadScene();
    }
}
