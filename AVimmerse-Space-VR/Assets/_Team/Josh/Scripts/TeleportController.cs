using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class TeleportController : MonoBehaviour
{
    #region original
    //public XRController leftController;
    //public XRController rightController;
    //public InputHelpers.Button teleportRayButton;
    //public float activationThreshold = 0.1f;

    private XRInteractorLineVisual leftRay;
    private GameObject leftReticle;

    private XRInteractorLineVisual rightRay;
    private GameObject rightReticle;
    #endregion

    #region XRControllerActionBased
    [SerializeField] private ActionBasedController leftController;
    [SerializeField] private InputActionReference leftControllerAction;

    [SerializeField] private ActionBasedController rightController;
    [SerializeField] private InputActionReference rightControllerAction;
    #endregion

    void Start()
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

    //private void Update()
    //{
    //    bool leftIsPressed = CheckButtonDown(leftController);
    //    leftRay.enabled = leftIsPressed;
    //    leftReticle.SetActive(leftIsPressed);
    //    
    //    bool rightIsPressed = CheckButtonDown(rightController);
    //    rightRay.enabled = rightIsPressed;
    //    rightReticle.SetActive(rightIsPressed);
    //}

    //public bool CheckButtonDown(XRController controller)
    //{
    //    InputHelpers.IsPressed(controller.inputDevice, teleportRayButton, out bool isPressed, activationThreshold);
    //    return isPressed;
    //}

}