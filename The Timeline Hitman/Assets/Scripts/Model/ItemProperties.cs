using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    // --- Possible Additions
    // Item Name
    // Item Description

    // Item Picture
    private Sprite ItemIcon;

    public Sprite getItemIcon()
    {
        return ItemIcon;
    }

    public void setItemIcon(Sprite newIcon)
    {
        ItemIcon = newIcon;
    }
}
