using UnityEngine;

public class CircularBoundary : MonoBehaviour
{
    public Vector3 center = Vector3.zero;
    public float radius = 10f;

    // Function to check if a point is within the circular boundary
    private bool IsWithinBoundary(Vector3 point)
    {
        float distance = Vector3.Distance(point, center);
        return distance <= radius;
    }

    // Example enemy positions
    private Vector3[] enemies = { new Vector3(2f, 3f, 1f), new Vector3(-5f, 7f, 2f), new Vector3(12f, -2f, 3f), new Vector3(-3f, -4f, 4f) };

    private void Start()
    {
        // Update enemy positions and check if they are within the boundary
        foreach (Vector3 enemy in enemies)
        {
            if (IsWithinBoundary(enemy))
            {
                Debug.Log($"Enemy at {enemy} is within the boundary.");
            }
            else
            {
                Debug.Log($"Enemy at {enemy} has crossed the boundary.");
            }
        }
    }
}