using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] LayerMask CamperViewLayer;
    [SerializeField] float viewDistance = 50f;
    [SerializeField] float fov = 90f;
    [SerializeField] int rayCount = 50;
    // Start is called before the first frame update
    private Mesh mesh;
    private CamperStateManager camperState;
    private PolygonCollider2D polygoneCollider;
    private Vector3 origin;
    private float startAngle;

    public void SetCamper(CamperStateManager camperStateManager)
    {
        camperState = camperStateManager;
    }
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        polygoneCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            camperState.FoundPlayer(other.gameObject);
        }
    }

    void CreateFieldOfView()
    {

        float angle = startAngle;

        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, CamperViewLayer);
            if (raycastHit2D.collider != null)
            {
                vertex = raycastHit2D.point;
            }
            else
            {
                //No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        List<Vector2> points = new List<Vector2>();
        for(int i = 0; i < vertices.Length; i++)
        {
            points.Add(new Vector2(vertices[i].x, vertices[i].y));
        }
        polygoneCollider.points = points.ToArray();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startAngle = GetAngleFromVectorFloat(aimDirection) - fov/2f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CreateFieldOfView();
    }
}
