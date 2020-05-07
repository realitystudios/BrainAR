using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Prefab;

    private ARSessionOrigin m_SessionOrigin;
    private ARRaycastManager m_RaycastManager;
    private List<ARRaycastHit> m_Hits;
    private GameObject m_BrainObject;
    // Start is called before the first frame update
    void Start()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_Hits = new List<ARRaycastHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began){
                if (m_RaycastManager.Raycast(touch.position, m_Hits, TrackableType.PlaneWithinPolygon)){
                    Pose pose = m_Hits[0].pose;
                    if (m_BrainObject == null)
                    {
                        m_BrainObject = Instantiate(m_Prefab, pose.position, Quaternion.identity);
                    } 
                    else
                    {
                        m_BrainObject.transform.position = pose.position;
                    }
                }
            }
        }
    }
}
