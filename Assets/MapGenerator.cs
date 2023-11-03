using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update


    List<GameObject> islands = new List<GameObject>();

    
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

        List<GameObject> edgeBlocks = new List<GameObject>();
        List<GameObject> blocks = new List<GameObject>();

        float spreadDecay = 1;
        //create an origin block for the rest of the blocks to spread in
        GameObject originBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //slap it on a random place // placed on center for testing purposes. TODO: remove this comment after its solved
        originBlock.transform.position = new Vector3(0, 0, 0);

        //put it in a list.
        blocks.Add(originBlock);
        edgeBlocks.Add(originBlock);

        //spawn other blocks surrounding itself. those blocks will then be added to the list. remove the block itself on the list right after
        for (int i = 0; i < 4; i++)
        {
            GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
            block.transform.position = new Vector3();
        }
        
        
        /*block.transform.position = new Vector3(0, 0, 1);
        block.transform.position = new Vector3(-1, 0, 0);
        block.transform.position = new Vector3(0, 0, -1);*/


        //the blocks that are now in the list will do the same to surround itself with blocks, checking other neighbor blocks in order not to duplicate to already taken positions.
        //those blocks will then remove itself from the list after 
        /*while (spreadDecay > 0)
        {

        }*/

        /*foreach (GameObject edgeBlock in edgeBlocks)
        {
            if (edgeBlock != blocks)
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
