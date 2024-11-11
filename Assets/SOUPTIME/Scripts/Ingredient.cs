using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string tag;

    public void OnSelected()
    {
        // Access OrderManager's Instance and call AddIngredient
        OrderManager.Instance.AddIngredient(tag);
    }
}
