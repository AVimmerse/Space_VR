using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class InputDetector : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject ControllerSetup;
    [SerializeField] Transform ControllerSetupOrigin;

    [SerializeField] GameObject HandTrackedSetup;
    [SerializeField] Transform HandTrackedSetupOrigin;

    private void Update()
    {
        //Debug.Log(InputDevices.GetDeviceAtXRNode(XRNode.Head).manufacturer);
        //Debug.Log(InputDevices.GetDeviceAtXRNode(XRNode.Head).name);
        //Debug.Log(InputDevices.GetDeviceAtXRNode(XRNode.Head).characteristics);
        //
        //Debug.Log(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).manufacturer);
        //Debug.Log(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).name);
        //Debug.Log(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).characteristics);
    }

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

    private void AllignWithHandSetup()
    {

    }

    private void AllignWithControllerSetup()
    {

    }

}
