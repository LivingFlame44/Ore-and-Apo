using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform targetPos;
    public bool isRange;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isRange)
        {
            GameManager.instance.player.transform.position = targetPos.position;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // check if yung nag collide na game object is Player
        {
            isRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // check if yung nag collide na game object is Player
        {
            isRange = false; ;
        }
    }

}
