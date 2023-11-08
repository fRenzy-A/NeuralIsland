using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update


    List<GameObject> islands = new List<GameObject>();
    int[] islandLayer;
    
    void Start()
    {
        //FillIslandLayer();

        Debug.Log("asdasda" + 2 + 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateIsland()
    {

        //create an origin block for the rest of the blocks to spread in
        //GameObject originBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //slap it on a random place // placed on center for testing purposes. TODO: remove this comment after its solved
        //originBlock.transform.position = new Vector3(0, 0, 0);
        

        
    }
    public List<GameObject> islandLayerBlocks = new List<GameObject>();

    public int islandLayerWidth = 15;
    public int islandLayerHeight = 15;

    void FillIslandLayer()
    {
        List<Vector3> layerPos = new List<Vector3>();

        for (int x = 0; x <= islandLayerWidth; x++)
        {
            for (int y = 0; y <= islandLayerHeight; y++)
            {
                layerPos.Add(new Vector3(x,0,y));
            }
        }
        GameObject originPoint = GameObject.CreatePrimitive(PrimitiveType.Cube);//Vector3(islandLayerWidth/2,0,islandLayerHeight/2);
        originPoint.transform.position = new Vector3(islandLayerWidth / 2, 0, islandLayerHeight / 2);
        islandLayerBlocks[1] = originPoint;

        
        
        float spreadDecay = 0;
        List<Vector3> blocks = new List<Vector3>();

        while (spreadDecay >= 0)
        {
            int currentIslandBlockCount = islandLayerBlocks.Count;
            //for each block in the island, if the block isnt sr
            foreach (Vector3 pos in layerPos)
            {
                for (int i = 0; i < currentIslandBlockCount; i++)
                {
                    if (islandLayerBlocks[i].transform.position != pos)
                    {

                    }
                }
            }
               
        }


    }


    struct BlockCoord
    {
        public float blockX;
        public float blockY;

        public BlockCoord(float x, float y)
        {
            blockX = x;
            blockY = y;
        }
    }

}
