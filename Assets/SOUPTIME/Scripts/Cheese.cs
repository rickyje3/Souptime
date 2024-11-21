using System.Collections;
using System.Collections.Generic;
//using UnityEditor.XR.Interaction.Toolkit;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    public bool isSocketed = false;
    public bool grater = false;
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public void SpawnCheese()
    {
        Debug.Log(isSocketed + " before the call");
        if (prefabToSpawn != null)
        {
            if (isSocketed == true)
            {
                Debug.Log(isSocketed + " during the call");
                isSocketed = false;
                Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
                StartCoroutine(DelayedAction());
                Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
                StartCoroutine(DelayedAction());
                Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            }
            else
                Debug.Log("The prefab is there, but nothing is socketed!");
        }
        else
        {
            Debug.LogWarning("Prefab to spawn is not assigned in the Inspector.");
        }
        Debug.Log(isSocketed + " after the call");
    }

    IEnumerator DelayedAction()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Code to execute after the delay
        Debug.Log("1 second delay is over!");
    }
}
