using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCollectables : MonoBehaviour
{
    public List<GameObject> collectables;
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

        int random = Random.Range(0, 100) + 1;

        if (random <= 20)
        {
            GameObject newCollectable = Instantiate(collectables[Random.Range(0, collectables.Count)], transform);

            newCollectable.transform.localPosition = new Vector3(Random.Range(-1f, 1f), -0.4f, Random.Range(-0.5f, 0.5f));
        }
    }
}
