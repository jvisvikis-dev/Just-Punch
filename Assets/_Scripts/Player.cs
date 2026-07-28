using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
        UIManager.Instance.SetPlayerHealthBar(1f);
        UIManager.Instance.SetPlayerHealthText(currentHealth.ToString());
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UIManager.Instance.SetPlayerHealthBar((float)currentHealth / maxHealth);
        UIManager.Instance.SetPlayerHealthText(currentHealth.ToString());
        if (currentHealth < 0)
            Die();
    }

    public void Die()
    {
        Debug.Log("Oh ooo, you don't have anymore health");
    }
}
