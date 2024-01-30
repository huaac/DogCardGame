using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionTracker : MonoBehaviour
{
    [HideInInspector] public Vector3 currentMousePosition;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
 
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Table")) continue;
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
 
            currentMousePosition = hit.point;
            
            break;
        }
    }
}
