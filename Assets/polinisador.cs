using UnityEngine;
using System.Collections;

public class polinisador : MonoBehaviour {
    public Terrain terra;
    public int escalaAjustada;
    void Start()
    {
        // Mesh mesh = GetComponentInChildren<MeshFilter>().mesh;
        // Vector3[] vertices = mesh.vertices;
        // Vector3[] normals = mesh.normals;
        // int[] triangles = new int[vertices.Length];
        // int i = 0;
        // string resumo = "", resumo2 = "";
        // while (i < vertices.Length)
        // {
        //     vertices[i].Set(vertices[i].x + escalaAjustada, vertices[i].y + escalaAjustada, 0);
        //     vertices[i].Set(vertices[i].x, vertices[i].y, terra.terrainData.GetHeight((int)(vertices[i].y/2+1), (int)(vertices[i].x/2+3.5)) + vertices[i].z);
        //     //normals[i].Set(vertices[i].x, vertices[i].y, vertices[i].z);
        //     //print(vertices[i].y);
        //     //resumo += "{" + (int)vertices[i].y + "," + (int)vertices[i].x + "}";
        //     //resumo2 += "{" + (int)vertices[i].y/2 + "," + (int)vertices[i].x/2 + "}";
        //     //triangles[i] = i;
        //     resumo += "["+mesh.GetTriangles(0)[i]+"]";
        //     i++;
        // }

        // print(resumo);
        // //print(resumo2);
        // mesh.vertices = vertices;
        //// mesh.triangles = triangles;
        // //mesh.normals = normals;
        // mesh.RecalculateNormals();
        // mesh.RecalculateBounds();
        // mesh.Optimize();

        //mesh.RecalculateNormals();
        CriarPlano();
    }

    public void CriarPlano()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }

        Vector3[] v = new Vector3[] {
            new Vector3(0,0,0),
            new Vector3(0,0,3),
            new Vector3(3,0,3),
            new Vector3(3,0,0),
            new Vector3(6,0,3),
            new Vector3(6,0,0)
        };

        Mesh mesh = meshFilter.sharedMesh;
        mesh.Clear();

        mesh.vertices = new Vector3[]{
            v[0],v[1],v[2],
            v[0],v[2],v[3],
            v[3],v[2],v[4],
            v[3],v[4],v[5]
        };
        mesh.triangles = new int[]{
            0,1,2,
            3,4,5,
            6,7,8
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();
    }

    
}
