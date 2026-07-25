using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private HingeJoint joint;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private GameObject eyes;
    [SerializeField] private GameObject deadEyes;
    private InputManager inputManager;
    private int currentHealth;
    private void Start()
    {
        inputManager = InputManager.Instance;
        inputManager.punch += GetPunched;
        currentHealth = maxHealth;
    }
    private void GetPunched(float force)
    {
        Vector3 hingeAxis = Random.Range(0,2) == 1 ? new Vector3(1f,1f,1f): new Vector3(-1f,1f,1f);
        joint.axis = hingeAxis;
        rb.AddForce(-transform.forward * force);
        int damage = force >= inputManager.MaxPunchForce / 2 ? 2 : 1;
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
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
