using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipper : MonoBehaviour
{
    public Material cardFront;
    public Material cardBack;

    public void Flip()
    {
        Material currentMaterial = gameObject.GetComponent<Image>().material;

        if(currentMaterial == cardFront)
        {
            gameObject.GetComponent<Image>().material = cardBack;
        }
        else
        {
            gameObject.GetComponent<Image>().material = cardFront;
        }
    }
}
