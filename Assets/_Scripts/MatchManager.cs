using System.Collections;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    private static MatchManager instance;
    public static MatchManager Instance => instance;
    private bool playersTurn = true;
    private Enemy enemy;
    private void Awake()
    {
        if(instance)
            Destroy(instance.gameObject);
        instance = this; 
    }

    private void Start()
    {
        enemy = FindFirstObjectByType<Enemy>();
    }

    public void EndTurn()
    {
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

    public IEnumerator DelayEnemyTurn(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemy.Punch();
    }
}
