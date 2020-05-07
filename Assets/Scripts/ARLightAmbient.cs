using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(Light))]
public class ARLightAmbient : MonoBehaviour
{
    [SerializeField]
    private ARCameraManager m_ARCameraManager;

    private Light m_Light;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Light = GetComponent<Light>();
        m_ARCameraManager.frameReceived += OnCameraFrameReceived;
    }

    void OnCameraFrameReceived (ARCameraFrameEventArgs eventArgs)
    {
        m_Light.intensity = eventArgs.lightEstimation.averageBrightness.Value;
        m_Light.colorTemperature = eventArgs.lightEstimation.averageColorTemperature.Value;
    }

    private void OnDisable()
    {
        m_ARCameraManager.frameReceived -= OnCameraFrameReceived;
    }
}
