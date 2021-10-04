using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float initialScale = Random.Range(0.5f, 2f);
        float initialPositonY = Random.Range(-1.5f, 0f);
        float initialPositonZ = Random.Range(-1f, 1f);

        transform.localScale = new Vector3(initialScale, initialScale, initialScale);
        transform.localPosition = new Vector3(transform.localPosition.x, initialPositonY, initialPositonZ);

        GetComponent<Rigidbody>().velocity = new Vector3(0, Random.Range(-1f, -2.5f), 0);

        Destroy(gameObject, 1.33f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dust"))
        {
            other.gameObject.SetActive(true);
        }
    }
}
