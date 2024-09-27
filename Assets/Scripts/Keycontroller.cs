using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycontroller : MonoBehaviour
{
   
    //-------Collecting Key & Distroy Game Object-------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.getKey();
            Destroy(gameObject);

        }
    }
}
