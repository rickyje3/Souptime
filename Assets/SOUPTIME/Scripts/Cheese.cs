using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.Interaction.Toolkit;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    public bool isSocketed = false;
    public bool grater = false;
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public void SpawnCheese()
    {
        if (prefabToSpawn != null)
        {
            if (isSocketed == true)
            {
                Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            }
            else
                Debug.Log("The prefab is there, but nothing is socketed!");
        }
        else
        {
            Debug.LogWarning("Prefab to spawn is not assigned in the Inspector.");
        }
    }
}
