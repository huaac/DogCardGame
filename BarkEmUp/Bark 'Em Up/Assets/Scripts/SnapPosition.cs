using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPosition : MonoBehaviour
{
    public float snapDistance = 1;
    public Vector3 targetPosition;
    public Vector3 snapPositionn;
    public GameObject cardLocation;


    void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("card"))
        {
            Debug.Log("stays in");
        }
    }

    // if(other.gameObject.CompareTag("card"))
    //     {
    //         // Debug.Log(Vector3.Distance(SnapPositionn, targetPosition));

    //         CDragDrop dragDropS = other.gameObject.GetComponent<CDragDrop>();

    //         targetPosition = other.transform.position;
    //         snapPositionn = transform.position;

    //         if(Vector3.Distance(snapPositionn, targetPosition) < snapDistance)
    //         {
    //             Debug.Log("Close ENough");
    //             other.transform.position = cardLocation.transform.position;
    //             // dragDropS.CeaseDrag();
    //         }

    //         // other.GetComponent<Rigidbody>().MovePosition(transform.position);
    //     }
}
