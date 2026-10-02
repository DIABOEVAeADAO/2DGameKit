using UnityEngine;

public enum NodeStatus 
{
    None,
    Open,
    Closed,
    Obstaculs
}

public class Node
{
    public NodeStatus Status;
    public int PosX; 
    public int PosY;
    public Vector3 WorldPosition;

    public int gCost;
    public int hCost;
    public Node parent;

    public int FCost => gCost + hCost;

    public Node(int posX, int posY, NodeStatus status, Vector3 worldPosition)
    {
        Status = status;
        PosX = posX;
        PosY = posY;
        WorldPosition = worldPosition;
    }
}