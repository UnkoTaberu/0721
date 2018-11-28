using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour {

    [SerializeField]
    DungeonGenerator generator;

    public int[,] ItemGenerate(int[,] itemmap)
    {
        int x = 0, y = 0, i = 0;
        

        while (i != 15)
        {
            System.Random rx = new System.Random();
            System.Random ry = new System.Random(rx.Next());
            if (itemmap[x = rx.Next(generator.width), y = ry.Next(generator.height)] == 1)
            {
                itemmap[x, y] = 3;
                i++;
            }

        }
        
        return itemmap;
    }

}
