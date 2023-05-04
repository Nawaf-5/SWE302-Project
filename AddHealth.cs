using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    public float healthToAdd = 25f; // amount of health to add to player

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 3f) // check if player is within range
        {
            PlayerMovement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); // get reference to Movement component attached to player object
            if (movement != null) // make sure we found the Movement component
            {
                movement.health += healthToAdd; // add health to player
                Debug.Log("Added " + healthToAdd + " health to player.");
                Debug.Log("Player health is now " + movement.health + ".");
                //gameObject.SetActive(false); // deactivate the health item in the scene
                Destroy(gameObject);
            }
        }
    }
}
