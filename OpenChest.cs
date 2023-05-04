using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject chest;
    public float rotationSpeed = 90f;
    public GameObject[] itemsToDrop;
    public float dropRadius = 1.5f;

    private bool isInteractable = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteractable && IsPlayerCollidingWithChest())
        {
            // Disable interactivity while chest is opening
            isInteractable = false;

            // Rotate the chest 90 degrees on the Z-axis over time
            Quaternion targetRotation = Quaternion.Euler(0, 0, -90);
            StartCoroutine(RotateOverTime(targetRotation, rotationSpeed));

            // Drop items after the opening process time
            float openingTime = Mathf.Abs(-90f / rotationSpeed);
            Invoke("DropItems", openingTime);
        }
    }

    private IEnumerator RotateOverTime(Quaternion targetRotation, float rotationSpeed)
    {
        while (transform.rotation != targetRotation)
        {
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newRotation.eulerAngles.z);
            yield return null;
        }
    }

    private void DropItems()
    {
        foreach (GameObject item in itemsToDrop)
        {
            // Calculate a random position around the chest within the drop radius
            Vector2 randomOffset = Random.insideUnitCircle * dropRadius;
            Vector3 itemPosition = transform.position + new Vector3(randomOffset.x, 0f, randomOffset.y);

            // Instantiate the item at the random position
            Instantiate(item, itemPosition, Quaternion.identity);
        }
    }

    private bool IsPlayerCollidingWithChest()
    {
        Collider[] hitColliders = Physics.OverlapBox(chest.transform.position,
            new Vector3(chest.transform.localScale.x / 2, chest.transform.localScale.y / 2, chest.transform.localScale.z / 2));

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
