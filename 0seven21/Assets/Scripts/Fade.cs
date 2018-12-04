using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public Text text;


    // Use this for initialization
    void Start () {

        if (Input.GetKeyDown(KeyCode.Space))
        
            text.color = new Color(132f / 255f, 68f / 255f, 205f / 255f);


        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
