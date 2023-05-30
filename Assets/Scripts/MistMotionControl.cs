using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MistMotionControl : MonoBehaviour
{
    public MistInterference InterferenceObject;
    public SingleRay SingleRay1;
    public float MovingSpeed = 2f;
    public Vector3 TargetPosition = new Vector3(0f, 0f, -8f);
    public Vector3 InitialPosition = new Vector3(0f, 0f, 150f);
    public float SamplingInterval = 0.1f;
    private string SavePath = "./SensorData/";
    private float SamplingTimer = 0f;

    private List<string[]> SensorData = new List<string[]>
    {
        new string[] { "TimeStamp", "Distance" },
    };

    void Start()
    {
        InterferenceObject.transform.position = InitialPosition;
        SavePath += "MovingSpeed-"+ MovingSpeed + ".csv";
    }

    // Update is called once per frame
    void Update()
    {   
        SamplingTimer += Time.deltaTime;
        if (SamplingTimer >= SamplingInterval)
        {
            // 在这里采样数据并添加到列表中
            float CurrentTime = Time.time;
            SensorData.Add(new string[]{CurrentTime.ToString(), SingleRay1.Distance.ToString()});
            SamplingTimer = 0f;
        }
        Moving();
    }

    void Moving(){
        if(InterferenceObject.transform.position != TargetPosition){
            InterferenceObject.transform.Translate((TargetPosition - InterferenceObject.transform.position).normalized * MovingSpeed * Time.deltaTime);
        }else{
            ExportData();
            UnityEditor.EditorApplication.isPaused = true;
        }
    }

    void ExportData(){
        string filePath = Path.Combine(Application.dataPath, SavePath);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string[] rowData in SensorData)
            {
                writer.WriteLine(string.Join(",", rowData));
            }
        }

        Debug.Log("Data exported to: " + filePath);
    }
}
