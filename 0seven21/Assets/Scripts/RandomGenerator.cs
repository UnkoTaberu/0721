using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour {

    [SerializeField]
    DungeonGenerator generator;
    [SerializeField]
    GameObject item;
    [SerializeField]
    Transform ItemtileContainer;

    public int[,] itemmap;
    [Range(0, 20)]
    public int item_capacity = 3;

    [SerializeField]
    GameObject steps;
    [SerializeField]
    Transform StepstileContainer;

    public int[,] stepsmap;
    

    public void ItemGenerate(int[,] map)
    {
        int x = 0, y = 0, i = 0;
        item.gameObject.SetActive(true);

        itemmap = new int[generator.width, generator.height];

        for (x = 0; x != generator.width; x++)
        {
            for (y = 0; y != generator.height; y++)
            {
                itemmap[x, y] = map[x, y];
            }
        }

        while (i != item_capacity)
        {
            System.Random rx = new System.Random();
            System.Random ry = new System.Random(rx.Next());
            if (itemmap[x = rx.Next(generator.width), y = ry.Next(generator.height)] == 1)
            {
                itemmap[x, y] = 3;
                var tile = Instantiate(item);
                tile.transform.SetParent(ItemtileContainer);
                tile.transform.localPosition = new Vector2(x, y);

                i++;
            }

        }

    }

    public void StepsGenerate(int[,] map)
    {
        int x = 0, y = 0, i = 0;
        steps.gameObject.SetActive(true);

        stepsmap = new int[generator.width, generator.height];

        for (x = 0; x != generator.width; x++)
        {
            for (y = 0; y != generator.height; y++)
            {
                stepsmap[x, y] = map[x, y];
            }
        }

        while (i != 1)
        {
            System.Random rx = new System.Random();
            System.Random ry = new System.Random();
            if (itemmap[x = rx.Next(generator.width), y = ry.Next(generator.height)] == 1)
            {
                stepsmap[x, y] = 2;
                var tile = Instantiate(steps);
                tile.transform.SetParent(StepstileContainer);
                tile.transform.localPosition = new Vector2(x, y);

                i++;
            }

        }
    }

}
