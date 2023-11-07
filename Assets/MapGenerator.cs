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
        GenerateIsland();
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
        FillIslandLayer();

        
    }
    public List<Vector3> islandLayerBlockPos = new List<Vector3>();

    void FillIslandLayer()
    {
        //int[,] islandLayerBlockPos = new int[Random.Range(4,50),Random.Range(4,50)];

        
        float spreadDecay = 0;
        List<Vector3> blocks = new List<Vector3>();

        islandLayerBlockPos.Add(new Vector3(0,0,0));

        while (spreadDecay >= 0)
        {
            List<Vector3> edgeBlocks = new List<Vector3>();
            //for each block in the island, if the block isnt sr
            foreach (Vector3 block in islandLayerBlockPos)
            {
                if (!islandLayerBlockPos.Contains(new Vector3(block.x + 1, block.y, block.z))
                   || !islandLayerBlockPos.Contains(new Vector3(block.x - 1, block.y, block.z))
                   || !islandLayerBlockPos.Contains(new Vector3(block.x, block.y, block.z + 1))
                   || !islandLayerBlockPos.Contains(new Vector3(block.x, block.y, block.z - 1)))
                {
                    edgeBlocks.Add(block);
                }
                else
                {
                    continue;
                }
            }
            foreach (Vector3 blockee in edgeBlocks)
            {
                /*blocks.Add(new Vector3(block.x + 1, block.y, block.z));
                blocks.Add(new Vector3(block.x - 1, block.y, block.z));
                blocks.Add(new Vector3(block.x, block.y, block.z + 1));
                blocks.Add(new Vector3(block.x, block.y, block.z - 1));*/
                if (!islandLayerBlockPos.Contains(new Vector3(blockee.x + 1, blockee.y, blockee.z)))
                {
                    blocks.Add(new Vector3(blockee.x + 1, blockee.y, blockee.z));
                }
                if (!islandLayerBlockPos.Contains(new Vector3(blockee.x - 1, blockee.y, blockee.z)))
                {
                    blocks.Add(new Vector3(blockee.x - 1, blockee.y, blockee.z));
                }
                if (!islandLayerBlockPos.Contains(new Vector3(blockee.x, blockee.y, blockee.z + 1)))
                {
                    blocks.Add(new Vector3(blockee.x, blockee.y, blockee.z + 1));
                }
                if (!islandLayerBlockPos.Contains(new Vector3(blockee.x, blockee.y, blockee.z - 1)))
                {
                    blocks.Add(new Vector3(blockee.x, blockee.y, blockee.z - 1));
                }
                /* if (block.x != islandLayerBlockPos[i].x + 1 && block.z == islandLayerBlockPos[i].z)
                 {
                     blocks.Add(new Vector3(block.x + 1, block.y, block.z));
                 }
                 if (block.x != islandLayerBlockPos[i].x - 1 && block.z == islandLayerBlockPos[i].z)
                 {
                     blocks.Add(new Vector3(block.x - 1, block.y, block.z));
                 }
                 if (block.z != islandLayerBlockPos[i].z + 1 && block.x == islandLayerBlockPos[i].x)
                 {
                     blocks.Add(new Vector3(block.x, block.y, block.z + 1));
                 }
                 if (block.z != islandLayerBlockPos[i].z - 1 && block.x == islandLayerBlockPos[i].x)
                 {
                     blocks.Add(new Vector3(block.x, block.y, block.z - 1));
                 }*/
            }

            edgeBlocks.AddRange(blocks);
            islandLayerBlockPos.AddRange(edgeBlocks);
            blocks.Clear();
            edgeBlocks.Clear(); 
            spreadDecay--;
        }


        foreach (Vector3 blockees in islandLayerBlockPos)
        {
            GameObject blockObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            blockObject.transform.position = blockees;
        }



        //determines the position of every block on the islands face/surface


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
