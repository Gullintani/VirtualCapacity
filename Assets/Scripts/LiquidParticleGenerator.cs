using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidParticleGenerator : MonoBehaviour
{
    public int sphereCount = 10; // Sphere Count
    public float minSize = 1f; // Min Size
    public float maxSize = 2f; // Max Size
    public float mass = 1f; // Mass
    public Vector3 gravity = new Vector3(0f, -9.8f, 0f); // Gravity
    // public Vector3 position = new Vector3(0f, 0f, 0f); // Position
    public float friction = 0.5f; // Fricition

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < sphereCount; i++)
        {
            // Random Position
            // Vector3 position = new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 5f), Random.Range(-10f, 10f));
            float size = Random.Range(minSize, maxSize);

            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = this.transform.position;
            sphere.transform.localScale = new Vector3(size, size, size);

            Rigidbody rb = sphere.AddComponent<Rigidbody>();
            rb.mass = mass;
            rb.useGravity = true;
            rb.AddForce(gravity, ForceMode.Acceleration);
            rb.drag = friction;
        }
    }
}
