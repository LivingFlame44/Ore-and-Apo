using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] DoorBehavior doorBehaviour;

    [SerializeField] bool isDoorOpenSwitch;
    [SerializeField] bool isDoorCloseSwitch;
    [SerializeField] bool pressurePlate;

    float switchSizeY;
    Vector3 switchUpPos;
    Vector3 switchDownPos;

    float switchSpeed = 1f;
    float switchDelay = 0.2f;
    bool isPressingSwitch = false;
    // Start is called before the first frame update
    void Awake()
    {
        switchSizeY = transform.localScale.y / 6;

        switchUpPos = transform.position;
        switchDownPos = new Vector3(transform.position.x,
            transform.position.y - switchSizeY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressingSwitch)
        {
            MoveSwitchDown();
        }
        else if (!isPressingSwitch)
        {
            MoveSwitchUp();
        }
    }

    void MoveSwitchDown()
    {
        if (transform.position != switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                switchDownPos, switchSpeed * Time.deltaTime);
        }
    }

    void MoveSwitchUp()
    {
        if (transform.position != switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                switchUpPos, switchSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPressingSwitch = !isPressingSwitch;

            if (isDoorOpenSwitch && !doorBehaviour.isDoorOpen)
            {
                doorBehaviour.isDoorOpen = !doorBehaviour.isDoorOpen;
            }
            else if (isDoorCloseSwitch && doorBehaviour.isDoorOpen)
            {
                doorBehaviour.isDoorOpen = !doorBehaviour.isDoorOpen;
            }
            else if (pressurePlate)
            {
                doorBehaviour.buttonPressed++;
                if (doorBehaviour.buttonPressed <= 1 && !doorBehaviour.isDoorOpen)
                {
                    doorBehaviour.isDoorOpen = !doorBehaviour.isDoorOpen;
                }
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SwitchUpDelay(switchDelay));
            if (pressurePlate)
            {
                doorBehaviour.buttonPressed--;
                if (doorBehaviour.isDoorOpen && doorBehaviour.buttonPressed == 0)
                {
                    doorBehaviour.isDoorOpen = !doorBehaviour.isDoorOpen;
                }
            }
        }

    }

    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isPressingSwitch = false;
    }

}
