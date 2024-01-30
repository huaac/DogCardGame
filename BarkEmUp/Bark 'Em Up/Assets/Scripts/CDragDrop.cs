using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CDragDrop : NetworkBehaviour
{
    private bool isDragging = false;
    private bool isDraggable = true;
    public MousePositionTracker table;

    private Rigidbody rb;

    public int repositoryPosition;
    public int handPosition, deckPosition, fieldPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        table = GameObject.Find("Green Table").GetComponent<MousePositionTracker>();
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

        Debug.Log("started");
    }

    public void EndDrag()
    {
        if(!isDraggable) return;
        isDragging = false;

        // rb.velocity = Vector3.zero;
        // // rb.gravityScale = 5f;
        // rb.velocity = new Vector3(0,-50,0);
        // rb.AddForce(Vector3.down*rb.mass,ForceMode.Force);
        
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
        Debug.Log(isDragging);
    }

    void OnMouseDrag()
    {
        if(!isDraggable) {return;}
        isDragging = true;
        // Vector3 mousePosition = Input.mousePosition;
        rb.velocity = Vector3.zero;

        Vector3 newWorldPosition = new Vector3(table.currentMousePosition.x,10f, table.currentMousePosition.z);

        Vector3 direction = (Vector3)(newWorldPosition - transform.position);

        var difference = newWorldPosition - transform.position;
        var speed = 50*difference;
        rb.velocity = speed;
        // rb.AddForce(direction.normalized*5f,ForceMode.Impulse);

    }

    // void OnMouseDrag()
    // {
    //     if(!isDraggable) {return;}
    //     isDragging = true;
    //     // Vector3 mousePosition = Input.mousePosition;
    //     Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,70f));

    //     mousePosition.y = 7;

    //     // Debug.Log(mousePosition);

    //     // transform.position = new Vector3(mousePosition.x, 5, mousePosition.y);
    //     transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime + 10f);
    // }

    // public void CeaseDrag()
    // {
    //     isDraggable = false;
    //     Debug.Log("no dragging anymore");
    // }
}
