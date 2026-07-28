using System;
using UnityEngine;

public class PunchHand : MonoBehaviour
{
    public Action<GameObject> Hit;

    private void OnCollisionEnter(Collision collision)
    {
        Hit?.Invoke(collision.gameObject);
    }
}
