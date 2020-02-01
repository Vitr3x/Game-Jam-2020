using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemProperties : MonoBehaviour
{

    // --- Possible Additions
    // Item Name
    // Item Description

    // Item Picture
    public Sprite ItemIcon;

    public Sprite getItemIcon()
    {
        return ItemIcon;
    }

    public void setItemIcon(Sprite newIcon)
    {
        ItemIcon = newIcon;
    }
}
