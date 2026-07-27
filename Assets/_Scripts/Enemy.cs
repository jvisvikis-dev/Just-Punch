using UnityEditor.Experimental.GraphView;
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
    [Header("Settings")]
    [SerializeField] private int maxHealth = 10;
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
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
            Die();
    }

    public void Punch()
    {
        if (animator)
            animator.SetTrigger("Punch");
        MatchManager.Instance.EndTurn();
    }

    private void Die()
    {
        Debug.Log("Die");
        eyes.SetActive(false);
        deadEyes.SetActive(true);
        joint.breakForce = 0;
        Destroy(gameObject, 3);
    }
}
