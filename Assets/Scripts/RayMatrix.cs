using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayMatrix : MonoBehaviour
{
    public int rows = 2;
    public int columns = 2;
    public float cellSize = 0.5f;
    public float maximumDistance = 10f;
    private float[,] capacitanceMatrix;

    void Start()
    {
        capacitanceMatrix = new float[rows, columns];
    }
    void Update() {        
        // Populate capacitance matrix
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 cellPos = new Vector3(row * cellSize, 0f, col * cellSize);
                // Debug.DrawRay(cellPos, transform.right, Color.green);
                Debug.DrawRay(cellPos, transform.up * maximumDistance, Color.green);
                // Debug.DrawRay(cellPos, transform.forward, Color.green);

                RaycastHit hit;
                if (Physics.Raycast(cellPos, transform.up * maximumDistance, out hit))
                {   
                    // Change Color if hit
                    Debug.DrawRay(cellPos, transform.up * Vector3.Distance(cellPos, hit.point), Color.red);
                    capacitanceMatrix[row, col] = Vector3.Distance(cellPos, hit.point);
                    Debug.Log(capacitanceMatrix);
                }
            }
        }
    }
}
