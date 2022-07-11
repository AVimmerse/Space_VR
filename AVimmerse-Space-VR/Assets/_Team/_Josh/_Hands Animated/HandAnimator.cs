using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private InputActionReference inputGripAction;
    [SerializeField] private InputActionReference inputTriggerAction;

    private void Start()
    {
        if (animator == null)
            Debug.LogWarning($"{name} animator == null");
        if (inputGripAction == null)
            Debug.LogWarning($"{name} inputGripAction == null");
        if (inputTriggerAction == null)
            Debug.LogWarning($"{name} inputTriggerAction == null");
    }
    private void Update()
    {
        if (animator == null)
            return;

        // NOTE: I'd prefer this as a event - but now is not the time
        animator.SetFloat("Trigger", inputTriggerAction.action.ReadValue<float>());
        animator.SetFloat("Grip", inputGripAction.action.ReadValue<float>());
    }

}
