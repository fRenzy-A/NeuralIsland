using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Grass;
    public Material Dirt;

    public int howManyIslands = 1;

    public int maxLayerCount;
    public int minLayerCount;

    public List<List<Vector3>> islandLayer = new List<List<Vector3>>();


    public List<List<List<Vector3>>> islands = new List<List<List<Vector3>>>(); // unused but is for future expansions


    public List<GameObject> blocks = new List<GameObject>();
    void Start()
    {
        
        for (int i = 0; i < howManyIslands; i++)
        {
            GenerateIsland();
        }
        //fills the blocks in
        foreach (List<Vector3> layer in islandLayer)
        {
            foreach (Vector3 pos in layer)
            {
                GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                block.transform.position = pos;
                block.GetComponent<MeshRenderer>().material = Grass;
                blocks.Add(block);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {

            islandLayer.Clear();

            for (int i = 0; i < howManyIslands; i++)
            {
                GenerateIsland();
            }
            foreach (GameObject block in blocks)
            {
                Destroy(block);
            }
            
            //fills the blocks in
            foreach (List<Vector3> layer in islandLayer)
            {
                foreach (Vector3 pos in layer)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.transform.position = pos;
                    block.GetComponent<MeshRenderer>().material = Grass;
                    blocks.Add(block);
                }
            }
            
        }
    }

    void GenerateIsland()
    {
        int randomLayerCount = Random.Range(minLayerCount, maxLayerCount);


        int randomX = Random.Range(-50,50);
        int randomY = Random.Range(-50, 50);
        int randomZ = Random.Range(-50, 50);


        for (int i = 1; i < randomLayerCount; i++)
        {
            int randomMultiplier = (Random.Range(i, (i+1) * 10))/i;
            FillIslandLayer(i,randomMultiplier,randomX,randomY,randomZ);
            islands.Add(islandLayer);
        }
       

    }

    private void FillIslandLayer(int layer,int randomMultiplier, int x, int y, int z)
    {       
        int errosionRes = 100*randomMultiplier;
        int errodeMax = (30+(layer*5))*randomMultiplier;

        List<Vector3> allBlockPos = new List<Vector3>();
        List<Vector3> edgePos = new List<Vector3>();
        List<Vector3> newCreatedPos = new List<Vector3>();
       
        allBlockPos.Add(new Vector3(x,-layer + y,z));
        edgePos.Add(new Vector3(x,-layer + y,z));

        List<Vector3> noDupes;
        while (errosionRes >= 0)
        {
            //puts a block position on all directions of the specified position
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
            //dont
            edgePos.Clear();
            edgePos.AddRange(newCreatedPos);
            allBlockPos.AddRange(edgePos);
            noDupes = allBlockPos.Distinct().ToList();
            newCreatedPos.Clear();
            errosionRes -= noDupes.Count;
        }

        //gets rid of duplicate blocks
        List<Vector3> noPosDupes = allBlockPos.Distinct().ToList();
        islandLayer.Add(noPosDupes);
        
    }




}
