using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Virus"))
        {
            // Play any collection sound or effect here (if any)
            Destroy(gameObject); // Destroy the food object upon collision with the player
        }
    }
}
