using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private InputActionReference inputGripAction;
    [SerializeField] private InputActionReference inputTriggerAction;

    private void Update()
    {
        // NOTE: I'd prefer this as a event - but now is not the time
        animator.SetFloat("Trigger", inputTriggerAction.action.ReadValue<float>());
        animator.SetFloat("Grip", inputGripAction.action.ReadValue<float>());
    }

}
