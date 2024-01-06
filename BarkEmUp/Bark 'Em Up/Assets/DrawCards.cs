using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject player_area;

    public void OnClick()
    {
        for (int i=0; i<5; i++)
        {
            GameObject card = Instantiate(card1,new Vector3(0,0,-18), Quaternion.identity);
            card.transform.SetParent(player_area.transform,false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
