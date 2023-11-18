using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    // Slled before the first frame update
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("GAME OVER");
    }
}