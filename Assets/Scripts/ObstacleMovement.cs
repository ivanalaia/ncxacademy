using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update() 
    {
        transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.instance.isDead = true;
        }
    } 

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
} 