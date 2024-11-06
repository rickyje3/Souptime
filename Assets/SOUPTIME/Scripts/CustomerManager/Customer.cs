using System.Collections;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private CustomerQueueManager queueManager;

    // Method to assign the CustomerQueueManager when spawned
    public void SetQueueManager(CustomerQueueManager manager)
    {
        queueManager = manager;
    }

    // Method to smoothly move the customer to a target position
    public void MoveToPosition(Vector3 targetPosition, float speed)
    {
        StartCoroutine(MoveTo(targetPosition, speed));
    }

    private IEnumerator MoveTo(Vector3 targetPosition, float speed)
    {
        // Move towards the target position until close enough
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }

    // Method to handle customer leaving the queue
    public IEnumerator LeaveQueue()
    {
        // Define the exit position (you can adjust the direction as needed)
        Vector3 exitPosition = transform.position + new Vector3(0, 0, 5);

        // Move customer to the exit position
        yield return MoveTo(exitPosition, 3f);

        // Destroy the customer GameObject after exiting
        Destroy(gameObject);
    }

    // Method to call from other scripts to serve this customer
    public void Serve()
    {
        queueManager.ServeCustomer();
    }
}


