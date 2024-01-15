using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class CardZoom : NetworkBehaviour
{
    public GameObject canvas;
    public GameObject zoomCard;

    private GameObject zoomCardP;
    private Sprite zoomSprite;

    public void Awake()
    {
        canvas = GameObject.Find("Main Canvas");
        zoomSprite = gameObject.GetComponent<Image>().sprite;
    }

    public void OnHoverEnter()
    {
        if(!isOwned) return;

        zoomCardP = Instantiate(zoomCard, new Vector3(Input.mousePosition.x, Input.mousePosition.y+250, -2), Quaternion.identity);
        zoomCardP.GetComponent<Image>().sprite = zoomSprite;
        zoomCardP.transform.SetParent(canvas.transform,true); //true to keep its world position

        RectTransform rect = zoomCardP.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector3(240, 344,0);
    }

    public void OnHoverExit()
    {
        Destroy(zoomCardP);
    }
}
