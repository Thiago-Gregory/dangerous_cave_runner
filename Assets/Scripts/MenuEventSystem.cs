using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEventSystem : MonoBehaviour
{
    public GameObject controls;
    public GameObject title;

    public void showControls()
    {
        controls.SetActive(true);
        title.SetActive(false);
    }

    public void closeControls()
    {
        controls.SetActive(false);
        title.SetActive(true);
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
