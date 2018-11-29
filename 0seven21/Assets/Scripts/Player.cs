using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbodyCache;
    [SerializeField]
    DungeonGenerator generator;
    [SerializeField]
    SceneController scontroller;

    int x = 0, y = 0, z = 0;

    void Start()
    {
        rigidbodyCache = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            WallFrag(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            WallFrag(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            WallFrag(0, 1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            WallFrag(0, -1, 0);
        }
    
    
     //   rigidbodyCache.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 10f);

     }

    public void WallFrag(int x2,int y2,int z2)
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;
        x = (int)tmp.x;
        y = (int)tmp.y;
        if(scontroller.map[x + x2,y + y2] != 0)
        {
            transform.Translate(x2, y2, z2);
        }
    }


}
