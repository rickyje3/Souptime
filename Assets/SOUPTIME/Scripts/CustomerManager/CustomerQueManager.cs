using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueueManager : MonoBehaviour
{
    public Transform[] queuePositions; // Set predefined queue positions in the Inspector
    public GameObject customerPrefab; // Assign the Customer prefab here
    public float moveSpeed = 2f; // Speed for customers moving to their position

    private Queue<Customer> customerQueue = new Queue<Customer>();

    void Start()
    {
        // Spawn initial customers to test the queue
        for (int i = 0; i < queuePositions.Length; i++)
        {
            SpawnCustomer();
        }
    }

    public void SpawnCustomer()
    {
        // Instantiate a new customer at the last queue position
        GameObject newCustomerObject = Instantiate(customerPrefab, queuePositions[queuePositions.Length - 1].position, Quaternion.identity);
        Customer newCustomer = newCustomerObject.GetComponent<Customer>();

        // Set this CustomerQueueManager instance as the manager for the customer
        newCustomer.SetQueueManager(this);

        // Add the new customer to the queue and update positions
        customerQueue.Enqueue(newCustomer);
        UpdateQueuePositions();
    }

    public void ServeCustomer()
    {
        if (customerQueue.Count > 0)
        {
            // Get the customer at the front of the queue and dequeue them
            Customer servedCustomer = customerQueue.Dequeue();

            // Start the customer's leave process
            StartCoroutine(servedCustomer.LeaveQueue());

            // Update the positions of the remaining customers
            UpdateQueuePositions();

            Debug.Log("Customer served");
        }
        else
        {
            Debug.Log("No customers left to serve.");
        }
    }

    private void UpdateQueuePositions()
    {
        int index = 0;
        foreach (Customer customer in customerQueue)
        {
            // Move each customer to the appropriate position in the queue
            customer.MoveToPosition(queuePositions[index].position, moveSpeed);
            index++;
        }
    }
}


