using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    public List<GameObject> rocks;
    public List<GameObject> newRocks;
    public Renderer rockFallPlane;

    [SerializeField]
    private float speed;

    private void Start()
    {
        StartCoroutine(generateRocks());
    }

    void Update()
    {
        if (speed < 10)
        {
            speed += 0.0001f;
        }
        else
        {
            speed = 10;
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f * speed);
    }

    public IEnumerator generateRocks()
    {
        while (true)
        {
            for (float i = 0; i < 6; i++)
            {
                GameObject newRock = Instantiate(rocks[Random.Range(0, rocks.Count)], transform);
                newRock.transform.localPosition = new Vector3(Random.Range(-4.5f, 4.5f), 0f, 0f);
                newRock.SetActive(true);
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
