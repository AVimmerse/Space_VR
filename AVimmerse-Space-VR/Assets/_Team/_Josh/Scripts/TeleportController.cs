using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

/// <summary>
/// Player teleportation extender. Reticles display and hide dynamically
/// </summary>
public class TeleportController : MonoBehaviour
{
    private XRInteractorLineVisual leftRay;
    private GameObject leftReticle;

    private XRInteractorLineVisual rightRay;
    private GameObject rightReticle;

    [SerializeField] private ActionBasedController leftController;
    [SerializeField] private InputActionReference leftControllerAction;

    [SerializeField] private ActionBasedController rightController;
    [SerializeField] private InputActionReference rightControllerAction;

    void Awake()
    {
        leftRay = leftController.GetComponent<XRInteractorLineVisual>();
        leftReticle = leftRay.reticle;

        rightRay = rightController.GetComponent<XRInteractorLineVisual>();
        rightReticle = rightRay.reticle;

        leftControllerAction.action.performed += OnLeftControllerAction_Changed;
        leftControllerAction.action.canceled += OnLeftControllerAction_Changed;

        rightControllerAction.action.performed += OnRightControllerAction_Changed;
        rightControllerAction.action.canceled += OnRightControllerAction_Changed;
    }

    private void OnDestroy()
    {
        leftControllerAction.action.performed -= OnLeftControllerAction_Changed;
        leftControllerAction.action.canceled -= OnLeftControllerAction_Changed;

        rightControllerAction.action.performed -= OnRightControllerAction_Changed;
        rightControllerAction.action.canceled -= OnRightControllerAction_Changed;
    }

    private void OnRightControllerAction_Changed(InputAction.CallbackContext obj)
    {
        rightRay.enabled = obj.performed;
        rightReticle.SetActive(obj.performed);
    }

    private void OnLeftControllerAction_Changed(InputAction.CallbackContext obj)
    {
        leftRay.enabled = obj.performed;
        leftReticle.SetActive(obj.performed);
    }

}