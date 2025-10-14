using UnityEngine;

public class FlashLightClamp : MonoBehaviour
{
    public Light flashlight;              // Assign your spotlight
    public float minIntensity = 0.1f;     // Closest intensity
    public float maxIntensity = 100f;     // Farthest intensity
    public float maxCheckDistance = 10f;  // Max flashlight reach
    public float curvePower = 2f;         // Curve strength (1 = linear, 2 = smooth, 3 = very slow rise)
    public float sphereRadius = 0.3f;     // Radius of the sphere cast for smoother detection

    void Update()
    {
        RaycastHit hit;

        // SphereCast forward for stable detection coverage
        if (Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit, maxCheckDistance))
        {
            float distance = hit.distance;

            // Normalize distance to 0 - 1
            float normalized = distance / maxCheckDistance;

            // Exponential curve mapping
            float curveValue = Mathf.Pow(normalized, curvePower);

            float newIntensity = Mathf.Lerp(minIntensity, maxIntensity, curveValue);

            flashlight.intensity = newIntensity;
        }
        else
        {
            // Full power when no surface in range
            flashlight.intensity = maxIntensity;
        }
    }
}
