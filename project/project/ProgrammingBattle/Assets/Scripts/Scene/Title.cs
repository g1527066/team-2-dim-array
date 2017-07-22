using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//audio.cameraスクリプトオンだとおかしいので消しています。
//フェイドインいれたいな、、

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {



        if (Input.anyKey)
        {
            Debug.Log("何か押された");
            Application.LoadLevel("MainScene");
        }
    }
}
