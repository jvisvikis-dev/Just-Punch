using System.Collections;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    private static MatchManager instance;
    public static MatchManager Instance => instance;
    private bool playersTurn = true;
    private bool gameOver;
    private Enemy enemy;
    private void Awake()
    {
        if(instance)
            Destroy(instance.gameObject);
        instance = this; 
    }

    public void EndTurn()
    {
        if (gameOver)
            return;
        if (playersTurn)
        {
            MatchUIManager.Instance.SetPunchButtonActive(false);
            StartCoroutine(DelayEnemyTurn(2f));
            playersTurn = false;
        }
        else
        {
            playersTurn = true;
            MatchUIManager.Instance.SetPunchButtonActive(true);
        }

    }

    public void MatchOver()
    {
        gameOver = true;
        MatchUIManager.Instance.SetPunchButtonActive(false);
        GameManager.Instance.SwitchToExploreScene();
    }

    public void SetEnemy(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public IEnumerator DelayEnemyTurn(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemy.Punch();
    }
}
