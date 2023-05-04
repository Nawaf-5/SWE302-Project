// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float speed = 5.0f; // The speed of the player movement

//     // Update is called once per frame
//     void Update()
//     {
//         float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input from the player
//         float verticalInput = Input.GetAxis("Vertical"); // Get vertical input from the player

//         // Move the player based on the input
//         Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
//         transform.Translate(movement * speed * Time.deltaTime);
//     }

//     private void onKeyPress()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             Inventory.PrintItems();
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // The speed of the player movement

    private Inventory inventory;
    public float health = 100f; // The health of the player

    private void Start()
    {
        GameObject inventoryManager = GameObject.Find("Inventory Manager");
        inventory = inventoryManager.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input from the player
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical input from the player

        // Move the player based on the input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);

        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key is pressed");
            inventory.PrintItems();
        }
    }
}


