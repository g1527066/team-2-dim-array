using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;




//三角
//ここで技、技の説明、選択的などの文字を制御します

public class TextManagement
{
    List<GameObject> techniqueObject = new List<GameObject>();//
    List<GameObject> enemyObjectt = new List<GameObject>();
    GameObject enemyDescription;//選択した技説明
    string chooseTechnique = "ChooseTechnique";
    string chooseEnemy = "ChooseEnemy";

    GameObject Canvas;//ここに子オブジェクトとして生成しないと表示されないので
    GameObject text;//ここに表示したい文字とかいろいろ入れて使います。
    private Text txt;
    public TextManagement()
    {
        Canvas = GameObject.Find("Canvas");
        text = (GameObject)Resources.Load("2DObject/TechniqueName");
    
 
    }

    //オブジェクトを生成します
    GameObject Generation(GameObject prefab, Vector3 position)
    {
        GameObject bullet = GameObject.Instantiate(prefab) as GameObject;
       
        bullet.transform.parent = Canvas.transform;
        bullet.transform.localPosition = position;
     
        return bullet;

    }


    //技のリスト選択項目を受け取って表示
    public void SelectedTechnique(string[] TechniqueName,string selectDescription, int select, BattleSystemScript.BattleState nowSelect)
    {

        switch(nowSelect)
        {
            case BattleSystemScript.BattleState.ChooseWord:


                techniqueObject.Add(Generation(text, new Vector3(-200, -245, 0)));
                txt = techniqueObject[0].GetComponent<Text>();
                txt.text = chooseTechnique;
                txt.fontSize = 8;

                techniqueObject.Add(Generation(text, new Vector3(80, -245, 0)));
                txt = techniqueObject[1].GetComponent<Text>();
                txt.text = chooseEnemy;
                txt.fontSize = 8;



                //MonoBehaviour.Destroy(chooseTechniqueObject[0]);
                ////chooseTechniqueObject[0].
                break;

            case BattleSystemScript.BattleState.ChooseEnemy:
                break;

            case BattleSystemScript.BattleState.InputText:
                break;

        }

    }

}
