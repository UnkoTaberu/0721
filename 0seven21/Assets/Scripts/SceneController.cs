using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    DungeonGenerator generator;
    [SerializeField]
    RandomGenerator item_generator;
    [SerializeField]
    Transform tileContainer;
    [SerializeField]
    Transform ItemtileContainer;
    [SerializeField]
    GameObject wallPrefab;
    [SerializeField]
    GameObject floorPrefab;
    [SerializeField]
    Player player;
    [SerializeField]
    Button regenerateButton;
    [SerializeField]
    GameObject item;

    void Start()
    {
        regenerateButton.onClick.AddListener(Generate);

        Generate();
    }

    void Generate()
    {
        foreach (Transform child in tileContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // ダンジョンマップを生成
        wallPrefab.gameObject.SetActive(true);
        floorPrefab.gameObject.SetActive(true);
        item.gameObject.SetActive(true);

        var map = generator.Generate();

        // アイテムマップを生成
        int[,] itemmap = new int[generator.width,generator.height];
        for(int x = 0;x != generator.width; x++)
        {
            for(int y = 0;y != generator.height; y++)
            {
                itemmap[x, y] = map[x, y];
            }
        }
        item_generator.ItemGenerate(itemmap);
        

        // マップを元にオブジェクト生成
        for (var x = 0; x < generator.width; x++)
        {
            for (var y = 0; y < generator.height; y++)
            {
                var tile = map[x, y] == 1 ? Instantiate(floorPrefab) : Instantiate(wallPrefab);
                tile.transform.SetParent(tileContainer);
                tile.transform.localPosition = new Vector2(x, y);

                // test
                if (itemmap[x, y] == 3)
                {
                    var tile2 = Instantiate(item);
                    tile2.transform.SetParent(ItemtileContainer);
                    tile2.transform.localPosition = new Vector2(x, y);
                }
            }
        }

        wallPrefab.gameObject.SetActive(false);
        floorPrefab.gameObject.SetActive(false);

        // プレイヤーをFloorタイルのどこかに配置
        var floors = GameObject.FindGameObjectsWithTag("Floor");
        player.transform.position = floors[Random.Range(0, floors.Length)].transform.position;
    }
}
