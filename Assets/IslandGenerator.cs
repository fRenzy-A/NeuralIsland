using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public int islandSpawnMaxDistanceX;
    public int islandSpawnMaxDistanceY;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    struct blockPos
    {
        int posX;
        int posY;
        bool taken;
        float chance;
        int layer;

        public blockPos(int x, int y, bool _taken, float _chance,int _layer)
        {
            posX = x;
            posY = y;
            taken = _taken;
            chance = _chance;
            layer = _layer;
        }
    }
    List<List<blockPos>> layer = new List<List<blockPos>>();
    List<blockPos> blockPosition = new List<blockPos>();
    public void GenerateIsland()
    {

    }

    public void GenerateLayer()
    {

    }

}
