using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Event_OnInputActionPerformed : MonoBehaviour
{
    [SerializeField] private InputActionReference inputAction;
    [SerializeField] private UnityEvent onInputActionPerformed;
    
    private void Awake()
    {
        inputAction.action.performed += Action_performed;
    }

    private void OnDestroy()
    {
        inputAction.action.performed -= Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        onInputActionPerformed.Invoke();
    }
}
