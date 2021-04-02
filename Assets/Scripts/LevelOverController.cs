using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
   
{
    public Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Level is Over
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            transform.position = startPosition;
            Debug.Log("game finish");
        }
    }
}
