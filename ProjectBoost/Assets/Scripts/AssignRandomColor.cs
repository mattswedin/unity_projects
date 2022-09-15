using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRandomColor : MonoBehaviour
{
    [SerializeField] Color[] colors;
    int childCount;

    void Start()
    {
        childCount = transform.childCount;

        if (childCount > 0)
        {
            ColorChildren();
        }
        else
        {
            ColorObject();
        }
    }

    void ColorChildren()
    {
        for (int i = 0; i < childCount; i++)
        {
            Mesh mesh = transform.GetChild(i).GetComponent<MeshFilter>().mesh;
            var uv = mesh.uv;
            Color[] meshColors = new Color[uv.Length];
            for (int j = 0; j < uv.Length; j++)
            {
                meshColors[j] = Color.Lerp(colors[0], colors[1], uv[j].y);
            }
            mesh.colors = meshColors;
        }
    }

    void ColorObject()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        var uv = mesh.uv;
        Color[] meshColors = new Color[uv.Length];
        for (int j = 0; j < uv.Length; j++)
        {
            meshColors[j] = Color.Lerp(colors[0], colors[1], uv[j].y);
        }
        mesh.colors = meshColors;
    }
}


