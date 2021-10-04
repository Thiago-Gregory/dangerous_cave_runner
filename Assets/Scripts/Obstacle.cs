using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public string obstacleType;
    public List<GameObject> obstacles;

    private float newPosX;

    // Start is called before the first frame update
    void Start()
    {
        instantiateObstacle();
        
        if (obstacleType.Equals("1"))
        {
            newPosX = Random.Range(-1.25f, 1.25f);
        }
        else if (obstacleType.Equals("2_1"))
        {
            newPosX = Random.Range(-0.23f, 0.23f);
        }
        else if (obstacleType.Equals("2_2"))
        {
            newPosX = Random.Range(0.3f, 0.3f);
        }
        else if (obstacleType.Equals("3_1") || obstacleType.Equals("3_2"))
        {
            newPosX = Random.Range(0.1f, 0.1f);
        }
        else
        {
            newPosX = 0;
        }

        transform.localPosition = new Vector3(transform.localPosition.x + newPosX, transform.localPosition.y, Random.Range(-0.5f, 0.5f));
        transform.localEulerAngles = new Vector3(0f, Random.Range(0f, 360f), 0f);
    }

    public void instantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)], transform);
    }
}
