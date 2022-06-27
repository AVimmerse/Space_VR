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
    [SerializeField] GameObject ControllerSetup;
    [SerializeField] Transform ControllerSetupOrigin;

    [SerializeField] GameObject HandTrackedSetup;
    [SerializeField] Transform HandTrackedSetupOrigin;

    private void Awake()
    {
        InputDevices.deviceConnected += InputDevice_Changed;
        InputDevices.deviceDisconnected += InputDevice_Changed;
    }

    private void InputDevice_Changed(InputDevice obj)
    {
        print($"<color=#00FF00>InputDevice_Changed</color>");

        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).name == null) // Hand Tracking
        {
            // Sync orign
            HandTrackedSetupOrigin.position = ControllerSetupOrigin.position;

            HandTrackedSetup.SetActive(true);
            ControllerSetup.SetActive(false);
        }
        else // Controllers
        {
            // Sync orign
            ControllerSetupOrigin.position = HandTrackedSetupOrigin.position;

            ControllerSetup.SetActive(true);
            HandTrackedSetup.SetActive(false);
        }

    }

}
