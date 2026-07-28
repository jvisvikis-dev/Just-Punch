using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;    
    

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);


    }
}
