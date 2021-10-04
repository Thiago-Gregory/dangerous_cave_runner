using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerModel;
    public GameObject textScore;
    public GameObject textCollectables;
    public GameObject gameOver;
    public GameObject eventSystem;
    public AudioSource audioCollectable;

    [SerializeField]
    private float speed;

    private float topSpeed;
    private int speedMultiplier;
    private Animator animatorPlayer;

    private int score;
    private int collectables;
    // Start is called before the first frame update
    void Start()
    {
        animatorPlayer = GetComponentInChildren<Animator>();

        topSpeed = speed;
        speedMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        playerModel.GetComponent<Animator>().SetInteger("Speed", (int)speed);

        if (speed < 10)
        {
            topSpeed += 0.0001f;
        }
        else
        {
            speed = 10;
        }

        speed = topSpeed * speedMultiplier;

        score = (int)((transform.position.z + 14f) * 50) + collectables * 500;

        textScore.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
        textCollectables.GetComponent<TMPro.TextMeshProUGUI>().text = collectables.ToString();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f * speed);
        playerModel.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FallingRock"))
        {
            other.GetComponent<FallingRocks>().setSpeed(1.25f);
            gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Obstacle"))
        {
            speedMultiplier = 0;
        }
        if (other.CompareTag("Collectable"))
        {
            collectables++;
            eventSystem.GetComponent<GameEventSystem>().playerCollectables++;
            audioCollectable.Play();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Cave"))
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 48f);
            other.GetComponent<Cave>().caveStart.gameObject.SetActive(false);

            Component[] generators = other.GetComponentsInChildren<GenerateObstacles>();

            foreach (GenerateObstacles generator in generators)
            {
                generator.instantiateObstacle();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            speedMultiplier = 1;
        }
    }

    public int getCollectables()
    {
        return collectables;
    }
}
