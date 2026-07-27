using System;
using UnityEngine;

public class PunchHand : MonoBehaviour
{
    [SerializeField] private bool isPlayer = true;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider collider;
    private InputManager inputManager;
    private float force = 0;
    private void Start()
    {
        if (!isPlayer)
            return;
        inputManager = InputManager.Instance;
        inputManager.punch += Punch;
    }

    private void Punch(float force)
    {
        if (!isPlayer)
            return;
        SetCollider(true);
        MatchManager.Instance.EndTurn();
        this.force = force;
        animator.SetTrigger("Punch");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Enemy enemy = collision.gameObject.transform.root.GetComponent<Enemy>();
        if(enemy)
            enemy.GetPunched(force,1);
        else
        {
            Player player = collision.gameObject.transform.root.GetComponent<Player>();
            if (player)
                player.TakeDamage(1);
        }
        if (!isPlayer)
            return;
        SetCollider(false);
    }

    public void SetCollider(bool state)
    {
        collider.enabled = state;
    }
}
