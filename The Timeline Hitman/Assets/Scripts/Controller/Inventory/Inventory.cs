using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private const int numSlots = 3;

    // An array of game objects that contain the item properties script

    public GameObject[] Slots = new GameObject[numSlots];
    public GameObject[] Items = new GameObject[numSlots];

    // Add an item to inventory
    public void AddItem(GameObject newItem)
    {
        Debug.Log(newItem);
        // Find an empty slot
        for(int i = 0; i < numSlots; i++)
        {
            if (Slots[i].GetComponent<Slot>().isEmpty())
            {
                Debug.Log(newItem);
                // A slot is found do stuff
                Items[i] = newItem;
                Debug.Log(Items[i]);
                // update the slot icon
                Slots[i].GetComponent<Slot>().setIcon(newItem.GetComponent<ItemProperties>().getItemIcon());
                Slots[i].GetComponent<Slot>().setEmpty(false);
                break;
            }
        }        
    }

    // Remove Item

    public void removeItem(GameObject item)
    {
        for(int i = 0; i < numSlots; i++)
        {
            // if the items match
            if(Items[i] == item)
            {
                Items[i] = null;
            }
        }
    }




}
