using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRandomColor : MonoBehaviour
{
    [SerializeField] Color[] colors;

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        var uv = mesh.uv;

        Color[] meshColors = new Color[uv.Length];

        for (int i = 0; i < uv.Length; i++)
        {
            meshColors[i] = Color.Lerp(colors[0], colors[1], uv[i].y);
        }

        mesh.colors = meshColors;
        
    }

}
