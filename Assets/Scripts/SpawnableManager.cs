using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class SpawnableManager : MonoBehaviour
{
    [SerializeField] ARRaycastManager m_RaycastManager; 
    List<ARRaycastHit> m_Hits = new();
    [SerializeField] GameObject spawnablePrefab;
    [SerializeField] SpawnObjectsController _controller;
    Camera arCam;
    GameObject spawnedObject;

    void Start()
    {
        spawnedObject = null; 
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchCount == 0) return;

        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits)) 
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null) 
            { 
                if (Physics.Raycast(ray, out RaycastHit hit)) 
                { 
                    if (hit.collider.gameObject.CompareTag("Spawnable")) 
                    { 
                        spawnedObject = hit.collider.gameObject; 
                    } 
                    else 
                    {
                        spawnedObject = _controller.Spawn(m_Hits[0].pose.position); 
                    } 
                } 
            } 
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null) 
            {
                spawnedObject.transform.position = m_Hits[0].pose.position; 
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended) 
            {
                spawnedObject = null; 
            }
        }
    }
    
}