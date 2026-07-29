using System;
using UnityEngine;

public class PunchHands : MonoBehaviour
{
    [SerializeField] private bool isPlayer = true;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider [] colliders;
    [SerializeField] private PunchHand[] hands;
    [SerializeField] private float minPunchForce;
    [SerializeField] private float maxPunchForce;
    [SerializeField] private int maxDamage;
    private float force = 0;
    private bool punched = false;
    private bool fromRight = false;
    private void Start()
    {
        foreach (PunchHand hand in hands)
            hand.Hit += OnHit;
        if (!isPlayer)
            return;
    }

    public void Punch()
    {
        SetColliders(true);
        MatchManager.Instance.EndTurn();
        force = UnityEngine.Random.Range(minPunchForce, maxPunchForce);
        fromRight = UnityEngine.Random.Range(0, 2) == 1;
        string animatorTrigger = fromRight ? "RightPunch" : "LeftPunch";
        if (isPlayer)
            animator.SetTrigger(animatorTrigger);
        else
            animator.SetTrigger("Punch");
        punched = true;
    }

    private void OnHit(GameObject hitObject)
    {
        if (!punched)
            return;
        Enemy enemy = hitObject.transform.root.GetComponent<Enemy>();
        Player player = hitObject.transform.root.GetComponent<Player>();
        if (isPlayer && enemy)
        {
            enemy.GetPunched(force, (int)(maxDamage * (force / maxPunchForce)), fromRight);
        }
        else if(!isPlayer && player)
        {
            player.TakeDamage((int)(maxDamage * (force / maxPunchForce)));
        }
        SetColliders(false);
        punched = false;
    }

    public void SetColliders(bool state)
    {
        if(!isPlayer)
            Debug.Log($"Enemy collider state {state}");

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }
    }
}
