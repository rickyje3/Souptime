using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Reference to the prefab to spawn
    public GameObject objectToSpawn;

    // The position where the object will spawn
    public Transform spawnPoint;

    // Time delay before spawning (default is 5 seconds)
    public float spawnDelay = 5f;

    // Public method to be called by the button
    public void StartSpawnProcess()
    {
        // Start the spawn process with a delay
        Invoke(nameof(SpawnObject), spawnDelay);
    }

    private void SpawnObject()
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            // Spawn the object at the spawnPoint's position and rotation
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("ObjectToSpawn or SpawnPoint is not set!");
        }
    }
}
