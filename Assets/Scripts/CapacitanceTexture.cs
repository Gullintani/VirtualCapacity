using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CapacitanceTexture : MonoBehaviour
{
    public RayMatrix rayMatrix;

    public float gamma = 1.5f;

    private Texture2D texture;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (rayMatrix != null && rayMatrix.capacitanceMatrix != null)
        {
            texture = new Texture2D(rayMatrix.capacitanceMatrix.GetLength(0), rayMatrix.capacitanceMatrix.GetLength(1));
            for (int x = 0; x < rayMatrix.capacitanceMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < rayMatrix.capacitanceMatrix.GetLength(1); y++)
                {
                    float grayValue = rayMatrix.capacitanceMatrix[x, y];
                    grayValue = Mathf.Pow(grayValue, gamma); // 应用伽马校正
                    texture.SetPixel(x, y, new Color(grayValue, grayValue, grayValue));
                }
            }
            texture.Apply();
            meshRenderer.material.mainTexture = texture;
        }
    }
}

// public class CapacitanceTexture : MonoBehaviour
// {
//     public RayMatrix rayMatrix;

//     private Texture2D texture;
//     private MeshRenderer meshRenderer;

//     void Start()
//     {
//         meshRenderer = GetComponent<MeshRenderer>();
//     }

//     void Update()
//     {
//         if (rayMatrix != null && rayMatrix.capacitanceMatrix != null)
//         {
//             texture = new Texture2D(rayMatrix.capacitanceMatrix.GetLength(0), rayMatrix.capacitanceMatrix.GetLength(1));
//             for (int x = 0; x < rayMatrix.capacitanceMatrix.GetLength(0); x++)
//             {
//                 for (int y = 0; y < rayMatrix.capacitanceMatrix.GetLength(1); y++)
//                 {
//                     float grayValue = rayMatrix.capacitanceMatrix[x, y];
//                     texture.SetPixel(x, y, new Color(grayValue, grayValue, grayValue));
//                 }
//             }
//             texture.Apply();
//             meshRenderer.material.mainTexture = texture;
//         }
//     }
// }