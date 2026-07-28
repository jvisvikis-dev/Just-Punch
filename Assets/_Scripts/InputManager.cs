using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;    
    private Controls _controls;
    private bool canPunch = true;
    public Action punch;
    

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
        if (!canPunch)
            return;
        canPunch = false;
        punch?.Invoke();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    public void SetCanPunch(bool state)
    {
        canPunch = state;
    }
}
