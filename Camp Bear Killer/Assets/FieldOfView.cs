using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 2;
        float angle = 0f;
        float angleIncreade = fov / rayCount;
        float viewDistance = 50f;

        Vector3[] vertices = new Vector3[rayCount + 1+ 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] tringles = new int[rayCount * 3];

        vertices[0] = origin;

        for (int i = 0; i <= rayCount; i++)
        {
         //   Vector3 vertex = origin + UtilsClass.Ge
        }
        vertices[1] = new Vector3(50, 0);
        vertices[2] = new Vector3(0, -50);

        tringles[0] = 0;
        tringles[1] = 1;
        tringles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = tringles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
