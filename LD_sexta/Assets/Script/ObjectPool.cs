using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> pool = new Queue<GameObject>();
    public static ObjectPool Instance { get; set; }

    private void Awake()
    {
        if(Instance == null) { Instance = this; }
    }
    public void SetPool(GameObject g)
    {
        pool.Enqueue(g);
    }

    public GameObject GetPool() 
    {
        return pool.Dequeue(); 
    }
}
