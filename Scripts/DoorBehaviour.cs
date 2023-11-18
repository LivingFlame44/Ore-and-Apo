using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool isDoorOpen = false;
    public int buttonPressed = 0;
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    float doorSpeed = 10f;
    public bool scaling = false;
    public GameObject doorTop;
    Vector3 temp;
    Vector3 doorScale;
    // Start is called before the first frame update
    void Awake()
    {
        doorClosedPos = transform.position;
        doorOpenPos = new Vector3(transform.position.x, 
            transform.position.y + 4f, transform.position.z);
        doorScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDoorOpen)
        {
            OpenDoor();
        }
        else if(!isDoorOpen)
        {
            CloseDoor();
        }

    }
    void OpenDoor()
    {
        if(transform.position != doorOpenPos && !scaling)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                doorOpenPos, doorSpeed * Time.deltaTime);
        }
        else if(transform.position != doorOpenPos && scaling)
        {
            while(transform.localScale.y != 0)
            {
                transform.localScale -= new Vector3(0, 1, 0);
            }
        }
    }

    void CloseDoor()
    {
        if (transform.position != doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                doorClosedPos, doorSpeed * Time.deltaTime);
        }
        else if (transform.position != doorClosedPos && scaling)
        {
            while (transform.localScale != doorScale)
            {
                transform.localScale += new Vector3(0, 1, 0);
            }
        }
    }

}
