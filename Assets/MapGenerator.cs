using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update


    public int howManyIslands = 1;
    
    void Start()
    {
        List<List<Vector3>> islands = new List<List<Vector3>>();
        for (int i = 0; i < howManyIslands; i++)
        {
            GenerateIsland();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateIsland()
    {
        int randomLayerCount = Random.Range(3, 10);
        for (int i = 1; i < randomLayerCount; i++)
        {
            int randomMultiplier = (Random.Range(i + 5, (i+1) * 10))/i;
            FillIslandLayer(i,randomMultiplier);
        }
           
    }

    public int count;
    public int nodupecount;
    private void FillIslandLayer(int layer,int randomMultiplier)
    {       
        int errosionRes = (100*randomMultiplier);
        int errodeMax = (40*randomMultiplier);

        List<Vector3> allBlockPos = new List<Vector3>();
        List<Vector3> edgePos = new List<Vector3>();
        List<Vector3> newCreatedPos = new List<Vector3>();
       

        edgePos.Add(new Vector3(0,-layer,0));

        List<Vector3> noDupes;
        while (errosionRes >= 0)
        {
            //IEnumerable<Vector3> noEdgeDupes = edgePos.Distinct().ToList();
            foreach (Vector3 pos in edgePos)
            {
                if (Random.Range(0, errosionRes) > errodeMax)
                {
                    newCreatedPos.Add(new Vector3(pos.x + 1, pos.y, pos.z));
                }
                if (Random.Range(0, errosionRes) > errodeMax)
                {
                    newCreatedPos.Add(new Vector3(pos.x - 1, pos.y, pos.z));
                }
                if (Random.Range(0, errosionRes) > errodeMax)
                {
                    newCreatedPos.Add(new Vector3(pos.x, pos.y, pos.z + 1));
                }
                if (Random.Range(0, errosionRes) > errodeMax)
                {
                    newCreatedPos.Add(new Vector3(pos.x, pos.y, pos.z - 1));
                }
            }

            edgePos.Clear();
            edgePos.AddRange(newCreatedPos);
            allBlockPos.AddRange(edgePos);
            noDupes = allBlockPos.Distinct().ToList();
            count = noDupes.Count;
            newCreatedPos.Clear();
            errosionRes -= (noDupes.Count);
        }

        List<Vector3> noPosDupes = allBlockPos.Distinct().ToList(); 
        nodupecount = noPosDupes.Count();

        foreach (Vector3 pos in noPosDupes)
        {
            GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
            block.transform.position = pos;
        }
    }




}
