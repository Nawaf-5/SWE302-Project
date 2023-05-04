using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public float openAngle = 90.0f;
    public float openSpeed = 2.0f;
    public float closeSpeed = 4.0f;

    private bool doorOpen = false;
    private Quaternion doorStartRotation;
    private Quaternion doorEndRotation;
    private float doorOpenTime = 0.0f;
    private bool doorIsAnimating = false;

    void Start()
    {
        doorStartRotation = door.transform.rotation;
        doorEndRotation = door.transform.rotation * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !doorIsAnimating && IsPlayerCollidingWithDoor())
        {
            if (!doorOpen)
            {
                doorEndRotation = door.transform.rotation * Quaternion.Euler(0, openAngle, 0);
                doorOpenTime = 0.0f;
                doorIsAnimating = true;
                doorOpen = true;
            }
            else
            {
                doorEndRotation = doorStartRotation;
                doorOpenTime = 1.0f;
                doorIsAnimating = true;
                doorOpen = false;
            }
        }

        if (doorIsAnimating)
        {
            if (doorOpen)
            {
                doorOpenTime += Time.deltaTime * openSpeed;
            }
            else
            {
                doorOpenTime -= Time.deltaTime * closeSpeed;
            }

            doorOpenTime = Mathf.Clamp01(doorOpenTime);

            door.transform.rotation = Quaternion.Lerp(doorStartRotation, doorEndRotation, doorOpenTime);

            if ((doorOpen && doorOpenTime >= 1.0f) || (!doorOpen && doorOpenTime <= 0.0f))
            {
                doorIsAnimating = false;
            }
        }
    }

    bool IsPlayerCollidingWithDoor()
    {
        Collider[] hitColliders = Physics.OverlapBox(door.transform.position,
            new Vector3(door.transform.localScale.x / 2, door.transform.localScale.y / 2, door.transform.localScale.z / 2));

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
}
