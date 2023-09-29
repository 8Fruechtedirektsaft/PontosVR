using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class InputListener : MonoBehaviour
{
    private void Start()
    {
        var leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1)
        {
            InputDevice device = leftHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        }

        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count == 1)
        {
            InputDevice device = rightHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        }

        devices = new();
        InputDeviceCharacteristics characteristics = InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        InputDevices.GetDevices(devices);
    }

    void Update()
    {
        foreach (var device in devices)
        {
            device.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonPressed);
            device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonPressed);
            if (primaryButtonPressed && secondaryButtonPressed)
            {
                timer += Time.deltaTime;
                if (timer > 2f) 
                {
                    SceneManager.LoadScene("MainScene");
                }
            }
            else
            {
                timer = 0;
            }
        }
    }

    private float timer = 0;
    private List<InputDevice> devices;
}
