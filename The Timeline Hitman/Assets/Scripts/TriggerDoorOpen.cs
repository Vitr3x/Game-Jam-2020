using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorOpen : MonoBehaviour
{
    [SerializeField]
    private GameObject Door1 = null, Door2 = null;
    [SerializeField]
    private int OpenDoorAngle1, OpenDoorAngle2, CloseDoorAngle1, CloseDoorAngle2;

    private Transform originDoor1, originDoor2;

    private bool TriggerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        originDoor1 = Door1.transform;
        originDoor2 = Door2.transform;
    }

    private void Update()
    {
        if (TriggerOn)
        {
            Door1.transform.rotation = Quaternion.Slerp(Door1.transform.rotation, Quaternion.Euler(0, OpenDoorAngle1, 0), 4 * Time.deltaTime);
            Door2.transform.rotation = Quaternion.Slerp(Door2.transform.rotation, Quaternion.Euler(0, OpenDoorAngle2, 0), 4 * Time.deltaTime);
        }
        if (!TriggerOn)
        {
            Door1.transform.rotation = Quaternion.Slerp(Door1.transform.rotation, Quaternion.Euler(0, CloseDoorAngle1, 0), 4 * Time.deltaTime);
            Door2.transform.rotation = Quaternion.Slerp(Door2.transform.rotation, Quaternion.Euler(0, CloseDoorAngle2, 0), 4 * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            TriggerOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TriggerOn = false;
        }
    }
}
