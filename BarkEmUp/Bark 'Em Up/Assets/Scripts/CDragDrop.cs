using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CDragDrop : NetworkBehaviour
{
    private bool isDragging = false;
    private bool isDraggable = true;

    private Rigidbody rb;

    public int repositoryPosition;
    public int handPosition, deckPosition, fieldPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(!isOwned) {isDraggable = false;}
        if(!isOwned) {Debug.Log("Not Owned");}
    }
    
    public void StartDrag()
    {
        if(!isOwned) {Debug.Log("not owned");}
        if(!isDraggable) return;
        isDragging = true;
        // start_parent = transform.parent.gameObject;
        // start_position = transform.position;
    }

    public void EndDrag()
    {
        if(!isDraggable) return;
        isDragging = false;
        // if (is_over_drop_zone)
        // {
        //     transform.SetParent(p_drop_zone.transform,false);
        //     isDraggable = false;
        //     NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        //     playerManager = networkIdentity.GetComponent<PlayerManager>();
        //     playerManager.PlayCard(gameObject);

        // }
        // else
        // {
        //     transform.position = start_position;
        //     transform.SetParent(start_parent.transform, false);
        // }
    }

    // // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)) {isDragging = false;}
    }

    void OnMouseDrag()
    {
        if(!isDraggable) {return;}
        isDragging = true;
        // Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,70f));

        mousePosition.y = 7;

        // Debug.Log(mousePosition);

        // transform.position = new Vector3(mousePosition.x, 5, mousePosition.y);
        transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime + 10f);
    }

    // public void CeaseDrag()
    // {
    //     isDraggable = false;
    //     Debug.Log("no dragging anymore");
    // }
}
