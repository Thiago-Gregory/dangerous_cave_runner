using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    public List<GameObject> caveParts;
    public GameObject caveStart;

    // Start is called before the first frame update
    void Start()
    {
        GameObject cavePart = Instantiate(caveParts[Random.Range(0, caveParts.Count)], transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
