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
        // Find an empty slot
        for(int i = 0; i < numSlots; i++)
        {
            if (Slots[i].GetComponent<Slot>().isEmpty())
            {
                // A slot is found do stuff
                Items[i] = newItem;

            }
        }
    }

    // Swap an item

    // Update the slots
    public void DisplayItems(){
        
    }


}
