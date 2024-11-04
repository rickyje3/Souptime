using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveKnob : MonoBehaviour
{
    public Renderer burnerRenderer; // Reference to the burner's Renderer component
    public float minAngle = 0f;
    public float maxAngle = 100f;
    public Material burnerMaterial; // Material to change the glow on the burner
    private float heatLevel = 0f; // 0 = off, 1 = low, 2 = medium, 3 = high

    void Update()
    {
        // Clamp rotation between minAngle and maxAngle
        float angle = Mathf.Clamp(transform.localEulerAngles.z, minAngle, maxAngle);
        transform.localEulerAngles = new Vector3(0, 0, angle);

        // Calculate heat level based on angle
        heatLevel = Mathf.InverseLerp(minAngle, maxAngle, angle) * 3;

        // Update burner glow based on heat level
        UpdateBurnerGlow(heatLevel);
    }

    void UpdateBurnerGlow(float level)
    {
        // Set the emission color based on the heat level
        burnerMaterial.SetColor("_EmissionColor", Color.red * level); // Adjust brightness as needed
        burnerRenderer.material = burnerMaterial; // Apply the material to the burner renderer
    }
}
