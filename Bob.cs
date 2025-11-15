using UnityEngine;

public class Bob : MonoBehaviour
{
    private float originalY;
    void Start()
    {
        originalY = transform.position.y; // Save the initial Y position
    }
    void Update()
    {
        float newY = originalY + Mathf.Sin(Time.time * 2f) * 0.5f;
        transform.position = new Vector2(transform.position.x, newY);
    }
}
