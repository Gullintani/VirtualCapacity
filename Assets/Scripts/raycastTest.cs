using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastTest : MonoBehaviour
{
    public Transform origin; // 射线起点
    public Vector3 direction; // 射线方向

    void Update()
    {
        // 创建射线
        Ray ray = new Ray(origin.position, direction);

        // 进行Raycast All，并获取相交物体信息
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);

        // 打印相交物体个数
        Debug.Log("碰撞物体个数: " + hits.Length);

        Debug.DrawRay(origin.position, direction * 100, Color.green);
                // Debug.DrawRay(cellPos, transform.forward, Color.green);


        RaycastHit hit;
        if (Physics.Raycast(origin.position, direction * 100, out hit))
        {   
            // Change Color if hit
            Debug.DrawRay(origin.position, direction * Vector3.Distance(origin.position, hit.point), Color.red);
        }
    }
}
