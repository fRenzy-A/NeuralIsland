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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateIsland()
    {

        List<GameObject> edgeBlocks = new List<GameObject>();

        float spreadDecay = 1;
        //create an origin block for the rest of the blocks to spread in
        GameObject originBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //slap it on a random place // placed on center for testing purposes. TODO: remove this comment after its solved
        originBlock.transform.position = new Vector3(0, 0, 0);

        //put it in a list. spawn other blocks surrounding itself. those blocks will then be added to the list. remove the block itself on the list right after
        //the blocks that are now in the list will do the same to surround itself with blocks, checking other neighbor blocks in order not to duplicate itself.
        //those blocks will then remove itself from the list after 
        while (spreadDecay > 0)
        {

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
