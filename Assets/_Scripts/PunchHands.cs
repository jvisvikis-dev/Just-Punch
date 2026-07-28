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
    private InputManager inputManager;
    private float force = 0;
    private bool punched = false;
    private bool fromRight = false;
    private void Start()
    {
        foreach (PunchHand hand in hands)
            hand.Hit += OnHit;
        if (!isPlayer)
            return;
        inputManager = InputManager.Instance;
        inputManager.punch += Punch;
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    if (!punched)
    //        return;
        
    //    Enemy enemy = collision.gameObject.transform.root.GetComponent<Enemy>();
    //    if(enemy)
    //        enemy.GetPunched(force,(int)(maxDamage*(force/maxPunchForce)));
    //    else
    //    {
    //        Player player = collision.gameObject.transform.root.GetComponent<Player>();
    //        if (player)
    //            player.TakeDamage((int)(maxDamage * (force / maxPunchForce)));
    //    }

    //    SetColliders(false);
    //    punched = false;
    //}

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
        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }
    }
}
