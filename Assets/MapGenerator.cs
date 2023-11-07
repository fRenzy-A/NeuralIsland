using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
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
    public List<Vector3> edgeBlocks = new List<Vector3>();
    
    void FillIslandLayer()
    {
        //int[,] islandLayerBlockPos = new int[Random.Range(4,50),Random.Range(4,50)];
        List<Vector3> islandLayerBlockPos = new List<Vector3>();
        
        float spreadDecay = 2;
        List<Vector3> blocks = new List<Vector3>();
        while (spreadDecay >= 0)
        {
            if (edgeBlocks.Count == 0)
            {
                blocks.Add(Vector3.zero);
            }
            else
            {
                foreach (Vector3 block in edgeBlocks)
                {
                    /*blocks.Add(new Vector3(block.x + 1, block.y, block.z));
                    blocks.Add(new Vector3(block.x - 1, block.y, block.z));
                    blocks.Add(new Vector3(block.x, block.y, block.z + 1));
                    blocks.Add(new Vector3(block.x, block.y, block.z - 1));*/
                    
                    for (int j = 0; j <= 3; j++)
                    {
                        for (int i = 0; i < edgeBlocks.Count; i++)
                        {
                            if (j == 0)
                            {
                                if (block.x + 1 != edgeBlocks[i].x)
                                {
                                    blocks.Add(new Vector3(block.x + 1, block.y, block.z));
                                }
                            }
                            else if (j == 1)
                            {
                                if (block.z + 1 != edgeBlocks[i].z)
                                {
                                    blocks.Add(new Vector3(block.x, block.y, block.z + 1));
                                }
                            }
                            else if (j == 2)
                            {
                                if (block.x - 1 != -edgeBlocks[i].x)
                                {
                                    blocks.Add(new Vector3(block.x - 1, block.y, block.z));
                                }
                            }
                            else if (j == 3)
                            {
                                if (block.z - 1 != -edgeBlocks[i].z)
                                {
                                    blocks.Add(new Vector3(block.x, block.y, block.z - 1));
                                }
                            }
                            else
                            {
                                return;
                            }

                            /*else if (block == edgeBlocks[i] && edgeBlocks.Count == 1)
                            {
                                blocks.Add(new Vector3(block.x + 1, block.y, block.z));
                                blocks.Add(new Vector3(block.x - 1, block.y, block.z));
                                blocks.Add(new Vector3(block.x, block.y, block.z + 1));
                                blocks.Add(new Vector3(block.x, block.y, block.z - 1));
                            }*/

                        }
                        
                    }

                }
            }

            edgeBlocks.AddRange(blocks);
            blocks.Clear();
            spreadDecay--;
           
        }


        foreach (Vector3 block in edgeBlocks)
        {
            GameObject blockObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            blockObject.transform.position = block;
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
