using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private HingeJoint joint;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject eyes;
    [SerializeField] private GameObject deadEyes;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private PunchHands punchHands;
    [Header("Settings")]
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private string name = "Enemy";
    private int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.minValue = 0;
        healthBar.value = currentHealth;
    }
    public void GetPunched(float force, int damage, bool fromRight = true)
    {
        Vector3 hingeAxis = fromRight ? new Vector3(1f,1f,1f): new Vector3(-1f,1f,1f);
        joint.axis = hingeAxis;
        rb.AddForce(-transform.forward * force);
        currentHealth -= damage;
        damageText.text = $"-{damage}";
        animator.SetTrigger("TakeDamage");
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
            Die();
    }

    public void Punch()
    {
        punchHands.Punch();
    }

    private void Die()
    {
        Debug.Log("Die");
        eyes.SetActive(false);
        deadEyes.SetActive(true);
        joint.breakForce = 0;
        MatchManager.Instance.MatchOver();
        GameManager.Instance.DefeatEnemy(name);
        Destroy(gameObject, 3);
    }
}
