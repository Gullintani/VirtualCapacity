using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleRay : MonoBehaviour
{
    public Vector3 rayDirection;
    void Update()
    {
        // 创建射线
        Ray ray = new Ray(transform.position, rayDirection.normalized);

        // 绘制射线
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

        // 发射射线并检测相交物体
        RaycastHit[] hits = Physics.RaycastAll(ray);

        Debug.Log("Number of object detected: " + hits.Length);
        // 处理每个相交的物体
        foreach (RaycastHit hit in hits)
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Detected object: " + hitObject.name);
            // 在这里处理相交物体的逻辑
        }
    }
}
