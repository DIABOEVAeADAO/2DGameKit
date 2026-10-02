using Unity.Mathematics;
using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class GridManager : MonoBehaviour
{
    [SerializeField] private Vector2 GridworldSize;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private GameObject go;
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private bool generateGrid = false;

    private float Diametro;
    private int GridX;
    private int GridY;
    private Node[,] Nodes;

    private void Update()
    {
        if (generateGrid)
        {
            generateGrid = false;
            Diametro = radius * 2;
            GridX = Mathf.RoundToInt(GridworldSize.x / Diametro);
            GridY = Mathf.RoundToInt(GridworldSize.y / Diametro);
            CreateGrid();
        }
    }

    private void CreateGrid()
    {
        Nodes = new Node[GridX, GridY];

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        Vector3 PointBottonLeft = transform.position
            - Vector3.right * (GridworldSize.x / 2)
            - Vector3.forward * (GridworldSize.y / 2);

        for (int i = 0; i < GridX; i++)
        {
            for (int j = 0; j < GridY; j++)
            {
                Vector3 worldPoint = PointBottonLeft 
                    + Vector3.right * (i * Diametro + radius)
                    + Vector3.forward * (j * Diametro + radius);
                
                bool isObstacle = Physics.CheckSphere(worldPoint, radius, obstacleMask);
                NodeStatus status = isObstacle ? NodeStatus.Obstaculs : NodeStatus.Open;

                Nodes[i, j] = new Node(i, j, status, worldPoint);

                if (go != null)
                {
                    GameObject gameObject = Instantiate(go, worldPoint, quaternion.identity);
                    gameObject.transform.parent = this.transform;
                }
            }
        }
    }

    public List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        for (int i = -1; i <= 1; i++) 
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                int CheckX = node.PosX + i;
                int CheckY = node.PosY + j;
                if (CheckX >= 0 && CheckX < GridX && CheckY >= 0 && CheckY < GridY) 
                {
                    neighbors.Add(Nodes[CheckX, CheckY]);
                }
            }
        }
        return neighbors;
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x - transform.position.x + GridworldSize.x / 2) / GridworldSize.x;
        float percentY = (worldPosition.z - transform.position.z + GridworldSize.y / 2) / GridworldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((GridX - 1) * percentX);
        int y = Mathf.RoundToInt((GridY - 1) * percentY);

        return Nodes[x, y];
    }
}