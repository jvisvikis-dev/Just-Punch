using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] private float minPunchForce;
    [SerializeField] private float maxPunchForce;
    public float MinPunchForce => minPunchForce;
    public float MaxPunchForce => maxPunchForce;    
    private Controls _controls;
    public Action<float> punch;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        _controls = new Controls();
        _controls.Player.Punch.performed += Punch;
    }

    private void Punch(InputAction.CallbackContext context)
    {
        float punchForce = UnityEngine.Random.Range(minPunchForce, maxPunchForce);
        punch?.Invoke(punchForce);
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}
