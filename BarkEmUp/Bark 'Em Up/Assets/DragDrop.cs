using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject canvas;
    public GameObject drop_zone;

    private bool is_dragging = false;
    private GameObject start_parent;
    private Vector3 start_position;
    private GameObject p_drop_zone;
    private bool is_over_drop_zone;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Main Canvas");
        drop_zone = GameObject.Find("DropArea");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        is_over_drop_zone = true;
        p_drop_zone = collision.gameObject;
        Debug.Log("Colliding");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        is_over_drop_zone = false;
        p_drop_zone = null;
        Debug.Log("UnColliding");
    }

    public void StartDrag()
    {
        is_dragging = true;
        start_parent = transform.parent.gameObject;
        start_position = transform.position;
    }

    public void EndDrag()
    {
        is_dragging = false;
        if (is_over_drop_zone)
        {
            transform.SetParent(p_drop_zone.transform,false);
        }
        else
        {
            transform.position = start_position;
            transform.SetParent(start_parent.transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(is_dragging)
        {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -18);
            transform.SetParent(canvas.transform,true);
        }
    }
}
