using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{

    public GameObject hand;
    private int HeldItemIndex = -1;

    // place an item

    public void EquipItem(GameObject crtItem)
    {
        crtItem.GetComponent<Rigidbody>().detectCollisions = false;
        crtItem.GetComponent<Rigidbody>().useGravity = false;
        crtItem.transform.position = hand.transform.position;
        crtItem.transform.SetParent(hand.transform);
        crtItem.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            HeldItemIndex = 0;
            GameObject currentItem = this.GetComponent<Inventory>().Items[HeldItemIndex];
            if(currentItem != null)
            {
                EquipItem(currentItem);
            }
        }
        if (Input.GetKeyDown("2"))
        {
            HeldItemIndex = 1;
            GameObject currentItem = this.GetComponent<Inventory>().Items[HeldItemIndex];
            if (currentItem != null)
            {
                EquipItem(currentItem);
            }
        }
        if (Input.GetKeyDown("3"))
        {
            HeldItemIndex = 2;
            GameObject currentItem = this.GetComponent<Inventory>().Items[HeldItemIndex];
            if (currentItem != null)
            {
                EquipItem(currentItem);
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if(HeldItemIndex > -1)
            {
                // drop the selected item
                DropItem(this.GetComponent<Inventory>().Items[HeldItemIndex]);
                // Remove the item from the gm items list
                this.GetComponent<Inventory>().removeItem(this.GetComponent<Inventory>().Items[HeldItemIndex]);
                // Clear the slot
                this.GetComponent<Inventory>().Slots[HeldItemIndex].GetComponent<Slot>().clearIcon();
                // Empty the hand
                this.GetComponent<Inventory>().Slots[HeldItemIndex].GetComponent<Slot>().setEmpty(true);
            }
        }


    }

    public void DropItem(GameObject crtItem)
    {
        crtItem.GetComponent<Rigidbody>().detectCollisions = true;
        crtItem.GetComponent<Rigidbody>().useGravity = true;
        crtItem.SetActive(true);

        crtItem.transform.position = hand.transform.position;
        crtItem.transform.parent = null;
        crtItem.SetActive(true);
    }


}
