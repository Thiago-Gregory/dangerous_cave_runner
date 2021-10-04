using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180 * Random.Range(0, 2), transform.localEulerAngles.z);
    }
}
