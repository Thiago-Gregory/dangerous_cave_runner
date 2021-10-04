using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEventSystem : MonoBehaviour
{
    public GameObject pauseScreen;
    public AudioSource quakeStart;
    public AudioSource quakeLoop;
    public AudioSource audioCollectable;
    public GameObject player;
    public Slider sliderVolume;

    public int playerScore;
    public int playerCollectables;
    public float quakeVolume;

    private bool playing;

    // Start is called before the first frame update
    void Start()
    {
        quakeVolume = 1;
        playing = true;

        if (!quakeStart.isPlaying)
        {
            quakeStart.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            playerScore = (int)((player.transform.position.z + 14) * 50) + player.GetComponent<Player>().getCollectables() * 500;

            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && player.transform.localPosition.x < 1)
            {
                player.transform.localPosition = new Vector3(player.transform.localPosition.x + 0.06f, player.transform.localPosition.y, player.transform.localPosition.z);
                player.transform.localEulerAngles = new Vector3(0f, 45f, 0f);
            }
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && player.transform.localPosition.x > -1)
            {
                player.transform.localPosition = new Vector3(player.transform.localPosition.x - 0.06f, player.transform.localPosition.y, player.transform.localPosition.z);
                player.transform.localEulerAngles = new Vector3(0f, -45f, 0f);
            }
            else
            {
                player.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 1)
                {
                    openPauseScreen();

                    Time.timeScale = 0;
                }
                else
                {
                    closePauseScreen();

                    Time.timeScale = 1;
                }
            }

            quakeStart.volume = 1 * sliderVolume.value * Time.timeScale;
            quakeLoop.volume = 1 * quakeVolume * sliderVolume.value * Time.timeScale;
            audioCollectable.volume = 0.3f * sliderVolume.value * Time.timeScale;

            if (!quakeStart.isPlaying && !quakeLoop.isPlaying)
            {
                quakeLoop.Play();
            }
        }
    }

    public void loadScene(string scene)
    {
        playing = false;

        SceneManager.LoadScene(scene);

        Time.timeScale = 1;
    }

    public void openPauseScreen()
    {
        pauseScreen.SetActive(true);
    }

    public void closePauseScreen()
    {
        pauseScreen.SetActive(false);

        Time.timeScale = 1;
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
