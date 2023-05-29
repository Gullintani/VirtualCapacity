using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleRay : MonoBehaviour
{
    public Vector3 rayDirection;
    public float Distance;
    void Update()
    {
        // 创建射线
        Ray ray = new Ray(transform.position, rayDirection.normalized);

        // 绘制射线
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

        // 发射射线并检测相交物体
        RaycastHit[] hits = Physics.RaycastAll(ray);

        Distance = hits[0].distance;
        //
        if (hits.Length != 0){
            Debug.Log("Number of object detected: " + hits.Length);
            Debug.Log("Distance: " + Distance);
        }
        // 处理每个相交的物体
        // foreach (RaycastHit hit in hits)
        // {
        //     GameObject hitObject = hit.collider.gameObject;
        //     Debug.Log("Detected object: " + hitObject.name);
        //     // 在这里处理相交物体的逻辑
        // }
    }
}
