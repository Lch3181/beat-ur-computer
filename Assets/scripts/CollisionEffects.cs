using UnityEngine;
using UnityEditor;
using System.Collections;

public class ExampleClass : MonoBehaviour
{

    private ParticleSystem ps;
    private ParticleSystemRenderer psr;
    public Vector3 pivot;

    void Start()
    {

        ps = GetComponent<ParticleSystem>();
        psr = GetComponent<ParticleSystemRenderer>();

        psr.material = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Diffuse.mat");  // square material so we can see the pivot more easily

        var rotation = ps.rotationOverLifetime;
        rotation.enabled = true;
        rotation.zMultiplier = 180.0f;  // spin so we can see the pivot more easily
    }

    void Update()
    {

        psr.pivot = pivot;
    }

    void OnGUI()
    {

        GUI.Label(new Rect(25, 40, 100, 30), "X");
        GUI.Label(new Rect(25, 80, 100, 30), "Y");
        GUI.Label(new Rect(25, 120, 100, 30), "Z");

        pivot.x = GUI.HorizontalSlider(new Rect(65, 25, 100, 30), pivot.x, -2.0f, 2.0f);
        pivot.y = GUI.HorizontalSlider(new Rect(65, 65, 100, 30), pivot.y, -2.0f, 2.0f);
        pivot.z = GUI.HorizontalSlider(new Rect(65, 105, 100, 30), pivot.z, -2.0f, 2.0f);
    }
}