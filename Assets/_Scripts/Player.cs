using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        currentHealth = maxHealth;
        MatchUIManager.Instance.SetPlayerHealthBar(1f);
        MatchUIManager.Instance.SetPlayerHealthText(currentHealth.ToString());
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        MatchUIManager.Instance.SetPlayerHealthBar((float)currentHealth / maxHealth);
        MatchUIManager.Instance.SetPlayerHealthText(currentHealth.ToString());
        if (currentHealth < 0)
            Die();
    }

    public void Die()
    {
        Debug.Log("Oh ooo, you don't have anymore health");
    }
}
