using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour {

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //　ゲーム終了ボタンを押したら実行する
    public void GameEnd()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
		                Application.Quit();
        #endif
    }
}
