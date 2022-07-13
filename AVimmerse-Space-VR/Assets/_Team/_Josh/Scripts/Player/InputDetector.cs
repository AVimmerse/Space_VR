using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

/// <summary>
/// 27.6.22 - Handles updates upon the input devices changing. 
/// Used for switching between controller modes and syncing their origins.
/// </summary>
public class InputDetector : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject ControllerSetup;
    [SerializeField] private Transform ControllerSetupOrigin;
    private Vector3 controllerSetupPos;

    [SerializeField] private GameObject HandTrackedSetup;
    [SerializeField] private Transform HandTrackedSetupOrigin;
    private Vector3 handTrackedSetupPos;

    private void Awake()
    {
        InputDevices.deviceConnected += InputDevice_Changed;
        InputDevices.deviceDisconnected += InputDevice_Changed;
    }

    private void OnDestroy()
    {
        InputDevices.deviceConnected -= InputDevice_Changed;
        InputDevices.deviceDisconnected -= InputDevice_Changed;
    }

    private void Update()
    {
        // NOTE: to surpress error:
        // MissingReferenceException: The object of type 'Transform' has been destroyed but you are still trying to access it.
        if (ControllerSetup != null)
            controllerSetupPos = ControllerSetupOrigin.position;
        else if (HandTrackedSetup != null)
            handTrackedSetupPos = HandTrackedSetupOrigin.position;
    }

    private void InputDevice_Changed(InputDevice obj)
    {
        print($"<color=#00FF00>InputDevice_Changed</color>");

        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).name == null) // Hand Tracking
        {
            // Sync orign
            HandTrackedSetupOrigin.position = controllerSetupPos;

            HandTrackedSetup.SetActive(true);
            ControllerSetup.SetActive(false);
        }
        else // Controllers
        {
            // Sync orign
            ControllerSetupOrigin.position = handTrackedSetupPos;

            ControllerSetup.SetActive(true);
            HandTrackedSetup.SetActive(false);
        }

    }

}
