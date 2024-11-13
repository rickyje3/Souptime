using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NewCustomersOrders : MonoBehaviour
{
    public GameObject[] Orders;
    public List<GameObject> customers = new List<GameObject>(); // Track customers dynamically
    public Vector3 relativeOffset; // Offset position relative to the customer

    private List<GameObject> availableOrders; // List of orders available for assignment

    void Awake()
    {
        // Initially find orders in the scene
        Orders = GameObject.FindGameObjectsWithTag("Orders");
        availableOrders = new List<GameObject>(Orders); // Initialize the available orders list
    }

    void Start()
    {
        // In case customers aren't in the scene yet, wait until they're available
        StartCoroutine(CheckForCustomers());
    }

    // Coroutine that checks for customers periodically
    IEnumerator CheckForCustomers()
    {
        // Wait for customers to be spawned (you can adjust the delay based on your game's needs)
        yield return new WaitForSeconds(1f);

        customers.AddRange(GameObject.FindGameObjectsWithTag("Customer"));

        if (customers.Count > 0)
        {
            AssignOrdersToCustomers();
        }
        else
        {
            UnityEngine.Debug.Log("No customers found.");
        }
    }

    // Shuffle the available orders using Fisher-Yates algorithm
    void ShuffleOrders()
    {
        for (int i = availableOrders.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            GameObject temp = availableOrders[i];
            availableOrders[i] = availableOrders[j];
            availableOrders[j] = temp;
        }
    }

    // Assign orders to customers
    void AssignOrdersToCustomers()
    {
        if (availableOrders.Count == 0)
        {
            UnityEngine.Debug.Log("No available orders left.");
            return;
        }

        ShuffleOrders(); // Shuffle orders before assignment

        // Assign orders to customers
        for (int i = 0; i < customers.Count; i++)
        {
            if (i < availableOrders.Count) // Ensure there's an order available
            {
                GameObject customer = customers[i];
                GameObject order = availableOrders[i]; // Get the next order

                // Make the order a child of the customer
                order.transform.SetParent(customer.transform);

                // Move the order to a position relative to the customer
                order.transform.localPosition = relativeOffset;

                UnityEngine.Debug.Log(customer.name + " received order: " + order.name);
            }
            else
            {
                UnityEngine.Debug.LogWarning("Not enough orders for customer: " + customers[i].name);
            }
        }
    }
}
