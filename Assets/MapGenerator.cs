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

        FillIslandLayer();

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
    //public List<GameObject> islandLayerBlocks = new List<GameObject>();

    
    public GameObject[,] layer;
    public int asdasd;
    private void FillIslandLayer()
    {
        int islandLayerWidth = 15;
        int islandLayerHeight = 15;
    //GameObject blocks = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        layer = new GameObject[islandLayerWidth, islandLayerHeight];
        for (int i = 0; i < islandLayerWidth; i++)
        {
            for (int j = 0; j < islandLayerHeight; j++)
            {
                layer[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                layer[i, j].transform.position = new Vector3(i, 0, j);
            }
        }
        GameObject centerBlock = layer[layer.GetLength(0) / 2, layer.GetLength(1) / 2];
        int erosionLevel = 100 * layer.Length/2;
        int currentErosionLevel = erosionLevel;

        for (int i = 0; i < layer.GetLength(0); i++)
        {
            for (int j = 0; j < layer.GetLength(1); j++)
            {                
                if (Random.Range(0, currentErosionLevel+currentErosionLevel) <= Random.Range(0, currentErosionLevel))
                {
                    GameObject.Destroy(layer[i, j]);
                }
                else if (erosionLevel == 1)
                {
                    GameObject.Destroy(layer[i, j]);
                }
                //else return;
                currentErosionLevel = (int)(erosionLevel / (centerBlock.transform.position.sqrMagnitude / layer[i,j].transform.position.sqrMagnitude));
                if (erosionLevel <= 2)
                {
                    erosionLevel = 2;
                }
                asdasd = currentErosionLevel;
            }
        }



        /*List<GameObject> layerPos = new List<GameObject>();

        for (int x = 0; x <= islandLayerWidth; x++)
        {
            for (int y = 0; y <= islandLayerHeight; y++)
            {
                layerPos.Add(new GameObject());
            }
        }
        GameObject originPoint = GameObject.CreatePrimitive(PrimitiveType.Cube);//Vector3(islandLayerWidth/2,0,islandLayerHeight/2);
        originPoint.transform.position = new Vector3(islandLayerWidth / 2, 0, islandLayerHeight / 2);
       // islandLayerBlocks.Add(originPoint);
        layerPos[layerPos.Count/2] = originPoint;

        
        
        float spreadDecay = 1;
        List<GameObject> blocks = new List<GameObject>();

        while (spreadDecay >= 0)
        {
            int currentIslandBlockCount = islandLayerBlocks.Count;
            
            foreach (GameObject block in layerPos)
            {
                for (int i = 0; i < currentIslandBlockCount; i++)
                {
                    islandLayerBlocks[i]= block;

                    if()
                    {

                    }
                    //layerPos.Distinct().ToList();
                }
            }
            spreadDecay--;
        }*/


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
