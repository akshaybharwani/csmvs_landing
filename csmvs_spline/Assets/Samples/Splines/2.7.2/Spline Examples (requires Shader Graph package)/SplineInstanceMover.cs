using UnityEngine;
using UnityEngine.Splines;
using System.Linq;

public class SplineInstanceMover : MonoBehaviour
{
    private SplineContainer splineContainer;  // The correct spline assigned at runtime
    public float speed = 0.2f;  // Speed of movement
    private float progress = 0f;  // Movement along the spline

    void Start()
    {
        // Find the closest SplineContainer at the moment of instantiation
        splineContainer = FindClosestSpline();

        if (splineContainer == null)
        {
            Debug.LogError("No SplineContainer found for " + gameObject.name);
            return;
        }

        // Start each instance at a random position on its respective spline
        progress = Random.Range(0f, 1f);
    }

    void Update()
    {
        if (splineContainer == null) return;

        // Move forward along the assigned spline
        progress += speed * Time.deltaTime;
        if (progress > 1f) progress = 0f; // Looping

        Spline spline = splineContainer.Spline;
        transform.position = spline.EvaluatePosition(progress);
        transform.rotation = Quaternion.LookRotation(spline.EvaluateTangent(progress));
    }

    // Find the closest SplineContainer to this instance
    private SplineContainer FindClosestSpline()
    {
        SplineContainer[] splines = FindObjectsOfType<SplineContainer>();
        return splines.OrderBy(s => Vector3.Distance(transform.position, s.transform.position)).FirstOrDefault();
    }
}
