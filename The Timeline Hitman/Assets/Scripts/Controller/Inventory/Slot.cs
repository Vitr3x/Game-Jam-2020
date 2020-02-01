using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private bool empty = true;

    public Image icon;

    public void setIcon(Sprite newIcon)
    {
        icon.sprite = newIcon;
        icon.enabled = true;
    }

    public void clearIcon()
    {
        icon.sprite = null;
        icon.enabled = false;
    }


    public bool isEmpty()
    {
        return empty;
    }

    public void setEmpty(bool empty)
    {
        this.empty = empty;
    }

}