using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    private float previousAngle = 0f;
    private float cumulativeAngle = 0f;
    private int rotationCount = 0;

    // Number of rotations to trigger the cheese grating action
    public int requiredRotations = 3;

    void Update()
    {
        // Get the current angle of the lever around the desired axis
        float currentAngle = transform.localEulerAngles.z;  // Assuming z-axis rotation

        // Calculate the angular difference
        float angleDifference = Mathf.DeltaAngle(previousAngle, currentAngle);

        // Accumulate the angle difference
        cumulativeAngle += angleDifference;

        // Check if cumulative angle has completed a full 360-degree rotation
        if (Mathf.Abs(cumulativeAngle) >= 360f)
        {
            rotationCount++;
            cumulativeAngle = 0f;  // Reset cumulative angle after a full rotation
            Debug.Log("Rotation Count: " + rotationCount);
        }

        // Check if the required rotations have been completed
        if (rotationCount >= requiredRotations)
        {
            Debug.Log("Cheese grated!");
            rotationCount = 0;  // Reset count if you want to allow repeated actions
        }

        // Update previous angle
        previousAngle = currentAngle;
    }
}
