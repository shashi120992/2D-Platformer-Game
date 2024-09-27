using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverController : MonoBehaviour
{
public int buildIndex;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Completed");
            SceneManager.LoadScene(buildIndex);
        }

    }
}
