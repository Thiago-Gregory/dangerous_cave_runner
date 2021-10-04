using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public bool moving;
	public GameObject player;
    public GameObject fallingRocks;
	public Transform cameraTransform;

	private float playerOffset;
	public float shakeRange;

	Vector3 originalPos;

	private void OnEnable()
	{
		shakeRange = 0.04f;
		originalPos = cameraTransform.localPosition;
	}

    private void Start()
    {
        playerOffset = transform.position.z - player.transform.position.z;
    }

    void Update()
	{
        if (moving)
        {
            shakeRange = (0.07f - (player.transform.localPosition.z - fallingRocks.transform.localPosition.z) / 100 / 3) * Time.timeScale;

            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + playerOffset);

            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeRange;
        }
	}
}
