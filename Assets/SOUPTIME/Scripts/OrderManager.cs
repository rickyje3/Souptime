using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance { get; private set; } // Singleton instance

    [System.Serializable]
    public class Order
    {
        public string theme; // e.g., "spicy," "sweet"
        public List<string> requiredTags; // Tags that represent the theme, e.g., ["spicy", "hot"]
    }

    public Order[] possibleOrders; // List of orders to choose from
    public Image orderImageUI; // UI element for optional theme icon
    public TextMeshProUGUI orderText; // Text to display the vague order (e.g., "something spicy")
    public TextMeshProUGUI feedbackText; // Feedback text to display completion messages

    private Order currentOrder;
    private HashSet<string> playerSelectedTags; // Stores tags of ingredients the player chooses

    void Awake()
    {
        // Ensure there's only one instance of OrderManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Optional, keeps this manager across scenes
    }

    void Start()
    {
        playerSelectedTags = new HashSet<string>();
        GenerateNewOrder();
    }

    public void GenerateNewOrder()
    {
        // Choose a random order from the list
        int randomIndex = Random.Range(0, possibleOrders.Length);
        currentOrder = possibleOrders[randomIndex];

        // Display the vague order theme on the screen
        orderText.text = "Customer wants something " + currentOrder.theme;
        feedbackText.text = ""; // Clear previous feedback

        // Reset player-selected ingredients
        playerSelectedTags.Clear();
    }

    public void AddIngredient(string ingredientTag)
    {
        // Add ingredient tags chosen by the player to the set
        playerSelectedTags.Add(ingredientTag);
    }

    public void CompleteOrder()
    {
        // Check if player's selected tags match the required tags for the order
        bool orderCompleted = true;
        foreach (var tag in currentOrder.requiredTags)
        {
            if (!playerSelectedTags.Contains(tag))
            {
                orderCompleted = false;
                break;
            }
        }

        if (orderCompleted)
        {
            feedbackText.text = "Order Completed!"; // Display success message
            Invoke("GenerateNewOrder", 2.0f); // Generate a new order after a delay
        }
        else
        {
            feedbackText.text = "Order Incomplete. Try Again!";
        }
    }
}