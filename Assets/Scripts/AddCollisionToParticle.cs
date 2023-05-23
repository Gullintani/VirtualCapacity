using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollisionToParticle : MonoBehaviour
{
    public GameObject collisionPrefab; // 碰撞体预制体，用于生成粒子的碰撞体
    new private ParticleSystem particleSystem; // 粒子系统
    private ParticleSystem.Particle[] particles; // 粒子数组
    private GameObject[] collisionObjects; // 碰撞体对象数组

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        collisionObjects = new GameObject[particleSystem.main.maxParticles];

        for (int i = 0; i < particleSystem.main.maxParticles; i++)
        {
            collisionObjects[i] = Instantiate(collisionPrefab, transform);
            collisionObjects[i].SetActive(false);
        }
    }

    void Update()
    {
        int particleCount = particleSystem.GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            collisionObjects[i].transform.localPosition = particles[i].position;
            collisionObjects[i].transform.localScale = particles[i].GetCurrentSize3D(particleSystem);
            collisionObjects[i].SetActive(true);
        }

        for (int i = particleCount; i < particleSystem.main.maxParticles; i++)
        {
            collisionObjects[i].SetActive(false);
        }
    }
}