using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3[] nodeOrigin;
    GameObject[] primOrigin = new GameObject[10];
    void Start()
    {
        SetIslandOrigin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetIslandOrigin()
    {
        for (int i = 0; i < primOrigin.Length; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
            primOrigin[i] = go;
        }
    }

    void SpreadOutIslandFloor()
    {
        
    }
}
