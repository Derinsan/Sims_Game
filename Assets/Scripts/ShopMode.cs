using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMode : MonoBehaviour
{
    private Canvas canvasBake;
    private void FixedUpdate()
    {
        Shop.ActionCanvasActive += CanvasFind;

        if (canvasBake != null)
        {
            if (Shop._isShopOpen == false)
            {
                canvasBake.enabled = false;
            }
            else if (Shop._isShopOpen == true)
            {
                canvasBake.enabled = true;
            }
        }
    }

    private void CanvasFind()
    {
        canvasBake = GameObject.Find("печь(Clone)").GetComponentInChildren<Canvas>();
    }

}
