using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Image image;
    public AudioSource quakeLoop;
    public GameObject fallingRocks;
    public GameObject textScore;
    public GameObject textCollectables;
    public GameObject gameOverTexts;
    public GameObject gameOverButtons;
    public GameObject textFinalScore;
    public GameObject eventSystem;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.GetComponent<Image>().color = new Color(0, 0, 0, image.color.a + 0.004f);

        if (image.GetComponent<Image>().color.a >= 1)
        {
            fallingRocks.SetActive(false);

            eventSystem.GetComponent<GameEventSystem>().quakeVolume -= 0.01f;

            string score = eventSystem.GetComponent<GameEventSystem>().playerScore.ToString();
            string collectables = eventSystem.GetComponent<GameEventSystem>().playerCollectables.ToString();

            textFinalScore.GetComponent<TMPro.TextMeshProUGUI>().text = "Final Score: " + score + "\n" + collectables + " Gems Collected";

            timer += Time.deltaTime;

            if (timer >= 1)
            {
                gameOverTexts.SetActive(true);
            }
            if (timer >= 5)
            {
                gameOverButtons.SetActive(true);
            }
        }
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
