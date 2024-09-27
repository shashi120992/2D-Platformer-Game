using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycontroller : MonoBehaviour
{
    // Start is called before the first frame update
    // Get key
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
