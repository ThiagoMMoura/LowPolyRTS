using UnityEngine;
using System.Collections;

public class polinisador : MonoBehaviour {

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int i = 0;
        while (i < vertices.Length)
        {
            print(vertices[i].ToString());
            //vertices[i].x += 1;
            //vertices[i].y += 1;
            //vertices[i].z += 1;
            i++;
        }
        vertices[30].y += 1;
        mesh.vertices = vertices;
    }
}
