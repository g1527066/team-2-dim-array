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
    List<GameObject> techniqueObject = new List<GameObject>();//[0]はchooseの文字
    List<GameObject> enemyObjectt = new List<GameObject>();
    GameObject enemyDescription;//選択した技説明
    GameObject inputTechnique;//選択した技説明
    GameObject inputAnswer;//選択した技説明
    
    string chooseTechnique = "ChooseTechnique";
    string chooseEnemy = "ChooseEnemy";

    GameObject Canvas;//ここに子オブジェクトとして生成しないと表示されないので
    GameObject text;//ここに表示したい文字とかいろいろ入れて使います。
    private Text txt;
    BattleSystemScript.BattleState oldState;



    public TextManagement()
    {
        Canvas = GameObject.Find("Canvas");
        text = (GameObject)Resources.Load("2DObject/TechniqueName");

        oldState = BattleSystemScript.BattleState.Interval;

        //技や敵のように数が変わるもの以外の生成
        //chooseTechniqueの文字生成
        techniqueObject.Add(Generation(text, new Vector3(-200, -245, 0),8,chooseTechnique,Color.black));
        //選択中の技の説明
        enemyDescription=Generation(text, new Vector3(80, -275, 0), 8, "技説明", Color.black);
        //chooseEnemyの文字生成
        enemyObjectt.Add(Generation(text, new Vector3(80, -245, 0), 8, chooseEnemy, Color.clear));
        //入力文字、答生成
        inputTechnique = Generation(text, new Vector3(180, -175, 0), 12, "input", Color.black);
        inputAnswer = Generation(text, new Vector3(180, -175, 0), 12, "in", Color.red);

    }

    //オブジェクトを生成します
    GameObject Generation(GameObject prefab, Vector3 position,int fontSize,string drawString,Color color)
    {
        GameObject ob = GameObject.Instantiate(prefab) as GameObject;
       
        ob.transform.parent = Canvas.transform;
        ob.transform.localPosition = position;
        txt = ob.GetComponent<Text>();
        txt.text = drawString;
        txt.fontSize = fontSize;
        txt.color = color;
        return ob;

    }


    //技のリスト選択項目を受け取って表示
    public void SelectedTechnique(string[] TechniqueName,string selectDescription, int select, BattleSystemScript.BattleState nowState)
    {

        switch(nowState)
        {
            case BattleSystemScript.BattleState.ChooseWord:
                if (oldState != nowState)
                {
                 //   oldState = nowState;
                 //前回の技文字を消す
                 for(int i=0;i<techniqueObject.Count-1;i++)
                    {
                     //   if(techniqueObject[i]!=null)

                    }

                }
                //MonoBehaviour.Destroy(chooseTechniqueObject[0]);
                ////chooseTechniqueObject[0].
                //    break;

                //case BattleSystemScript.BattleState.ChooseEnemy:
                //if (oldState != nowState)
                //{
                //    oldState = nowState;
                //}

                //    break;

                //case BattleSystemScript.BattleState.InputText:
                //if (oldState != nowState)
                //{
                //    oldState = nowState;
                //}

                break;

        }

    }

}
