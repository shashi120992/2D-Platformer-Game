using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverController : MonoBehaviour
{
    public Button buttonrestart;

    private void Awake()
    {
        buttonClick();
    }

    private void buttonClick()
    {
        buttonrestart.onClick.AddListener(reloadLevel);
    }

    public void playerdied()
    {
        gameObject.SetActive(true);
    }

    private void reloadLevel()
    {
        //SceneManager.LoadScene(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
