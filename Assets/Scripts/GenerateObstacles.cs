using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
    public List<GameObject> obstacles;
    // Start is called before the first frame update
    void Start()
    {
        instantiateObstacle();
    }

    public void instantiateObstacle()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Instantiate(obstacles[Random.Range(0, obstacles.Count)], transform);
    }
}
