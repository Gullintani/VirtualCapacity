using UnityEngine;

public class Plot : MonoBehaviour
{
    public float updateInterval = 0.1f; // 更新曲线的时间间隔
    public int maxPoints = 100; // 曲线上最大的点数
    public SingleRay Raycast;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] indices;
    private float[] dataPoints;
    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        // 初始化顶点数组和索引数组
        vertices = new Vector3[maxPoints];
        indices = new int[maxPoints];
        for (int i = 0; i < maxPoints; i++)
        {
            vertices[i] = new Vector3(i, 0, 0);
            indices[i] = i;
        }

        // 初始化数据点数组
        dataPoints = new float[maxPoints];
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 每隔一定时间更新曲线
        if (timer >= updateInterval)
        {
            timer = 0f;

            // 获取要绘制的数值
            float value = GetNewValue();

            // 将数值添加到数据点数组中
            dataPoints[currentIndex] = value;

            // 更新数据点的索引
            currentIndex = (currentIndex + 1) % maxPoints;

            // 更新顶点数组
            for (int i = 0; i < maxPoints; i++)
            {
                vertices[i].y = dataPoints[(currentIndex + i) % maxPoints];
            }

            // 更新Mesh
            mesh.vertices = vertices;
            mesh.SetIndices(indices, MeshTopology.LineStrip, 0);
        }
    }

    float GetNewValue()
    {
        // 返回要绘制的新数值，可以根据你的需求来自定义
        return Raycast.Distance;
    }
}
