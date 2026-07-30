using System;
using UnityEngine;

public class PunchHands : MonoBehaviour
{
    [SerializeField] private bool isPlayer = true;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider [] colliders;
    [SerializeField] private PunchHand[] hands;
    [SerializeField] private AudioClip[] punchSounds;
    [SerializeField] private float minPunchForce;
    [SerializeField] private int maxDamage;
    private int damage = 1;
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
        damage = UnityEngine.Random.Range(1, maxDamage+1);
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
        int idx = UnityEngine.Random.Range(0, punchSounds.Length);
        AudioManager.Instance.Play3DSound(hitObject.transform.position, punchSounds[idx]);
        Enemy enemy = hitObject.transform.root.GetComponent<Enemy>();
        Player player = hitObject.transform.root.GetComponent<Player>();
        if (isPlayer && enemy)
        {
            enemy.GetPunched(damage*minPunchForce, damage, fromRight);
        }
        else if(!isPlayer && player)
        {
            player.TakeDamage(damage);
            StartCoroutine(MatchUIManager.Instance.FlashRed(.3f));
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
