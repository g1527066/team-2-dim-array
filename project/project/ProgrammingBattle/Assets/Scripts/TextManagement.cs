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
    List<GameObject> enemyObject = new List<GameObject>();
    GameObject techniqueDescription;//選択した技説明
    GameObject inputTechnique;//
    GameObject inputAnswer;//

    string chooseTechnique = "ChooseTechnique";
    string chooseEnemy = "ChooseEnemy";

    GameObject Canvas;//ここに子オブジェクトとして生成しないと表示されないので
    GameObject text;//ここに表示したい文字とかいろいろ入れて使います。
    private Text txt;
    BattleSystemScript.BattleState oldState;



    //親子関係でのテキストのずれの解決がわからなかったので、キャンバスのサイズを足したり引いたりしてます。
    public TextManagement()
    {
        Canvas = GameObject.Find("Canvas");
        text = (GameObject)Resources.Load("2DObject/TechniqueName");

        oldState = BattleSystemScript.BattleState.Interval;

        //全て生成、カラーで制御する
        //chooseTechniqueの文字生成
        techniqueObject.Add(Generation(text, new Vector3(170 - Canvas.transform.position.x, -600 + Canvas.transform.position.y, 0), 24, chooseTechnique, Color.clear));
        //選択中の技の説明
        techniqueDescription = Generation(text, new Vector3(450 - Canvas.transform.position.x, -630 + Canvas.transform.position.y, 0), 22, "技説明", Color.clear);
        //chooseEnemyの文字生成
        enemyObject.Add(Generation(text, new Vector3(450 - Canvas.transform.position.x, -600 + Canvas.transform.position.y, 0), 22, chooseEnemy, Color.clear));
        //入力文字、答生成
        inputTechnique = Generation(text, new Vector3(520 - Canvas.transform.position.x, -525 + Canvas.transform.position.y, 0), 27, "input", Color.clear);
        inputAnswer = Generation(text, new Vector3(520 - Canvas.transform.position.x, -525 + Canvas.transform.position.y, 0), 27, "", Color.red);
        //技も基本３つなので生成しとく、二つ以下になったらcolorで見えなくする
        int interval = -40;
        techniqueObject.Add(Generation(text, new Vector3(150 - Canvas.transform.position.x, -630 + Canvas.transform.position.y, 0), 22, "技の名前1", Color.clear));
        techniqueObject.Add(Generation(text, new Vector3(techniqueObject[1].transform.localPosition.x, techniqueObject[1].transform.localPosition.y + interval * 1, 0), 22, chooseTechnique, Color.clear));
        techniqueObject.Add(Generation(text, new Vector3(techniqueObject[1].transform.localPosition.x, techniqueObject[1].transform.localPosition.y + interval * 2, 0), 22, chooseTechnique, Color.clear));
        //敵名生成最大５体こちらもcolorで制御する
        interval = -30;
        enemyObject.Add(Generation(text, new Vector3(450 - Canvas.transform.position.x, -630 + Canvas.transform.position.y, 0), 22, "敵の名前1", Color.clear));
        enemyObject.Add(Generation(text, new Vector3(enemyObject[1].transform.localPosition.x, enemyObject[1].transform.localPosition.y + interval * 1, 0), 22, chooseEnemy, Color.clear));
        enemyObject.Add(Generation(text, new Vector3(enemyObject[1].transform.localPosition.x, enemyObject[1].transform.localPosition.y + interval * 2, 0), 22, chooseEnemy, Color.clear));
        enemyObject.Add(Generation(text, new Vector3(enemyObject[1].transform.localPosition.x, enemyObject[1].transform.localPosition.y + interval * 3, 0), 22, chooseEnemy, Color.clear));
        enemyObject.Add(Generation(text, new Vector3(enemyObject[1].transform.localPosition.x, enemyObject[1].transform.localPosition.y + interval * 4, 0), 22, chooseEnemy, Color.clear));
    }

    //オブジェクトを生成します
    GameObject Generation(GameObject prefab, Vector3 position, int fontSize, string drawString, Color color)
    {
        GameObject ob = GameObject.Instantiate(prefab) as GameObject;
        ob.transform.SetParent(Canvas.transform, true);
        RectTransform rt = ob.GetComponent<RectTransform>();
        rt.localPosition = position;
        txt = ob.GetComponent<Text>();
        txt.text = drawString;
        txt.fontSize = fontSize;
        txt.color = color;
        return ob;

    }


    //技のリスト選択項目を受け取って表示
    public void SelectedTechnique(string[] TechniqueName, string[] enemyName, string selectDescription, int techniqueSelect,int enemySelect, BattleSystemScript.BattleState nowState,string answerString)
    {
        switch (nowState)
        {
            case BattleSystemScript.BattleState.ChooseWord:
                if (oldState != nowState)
                {
                    oldState = nowState;

                    //最初の文字は黒く
                    txt = techniqueObject[0].GetComponent<Text>();
                    txt.color = Color.black;

                    //説明黒く
                    txt = techniqueDescription.GetComponent<Text>();
                    txt.color = Color.black;
                    //敵関係を消す
                    for (int i = 0; i < enemyObject.Count; i++)
                    {
                        txt = enemyObject[i].GetComponent<Text>();
                        txt.color = Color.clear;
                    }
                    //答え入力消す
                    txt = inputAnswer.GetComponent<Text>();
                    txt.color = Color.clear;
                    txt = inputTechnique.GetComponent<Text>();
                    txt.color = Color.clear;
                }


                //技文字テキストの色編集,内容変更
                for (int i = 1; i < techniqueObject.Count; i++)
                {
                    txt = techniqueObject[i].GetComponent<Text>();
                    //文字の代入はあるところまで
                    if(TechniqueName.Length>i-1)
                    txt.text = TechniqueName[i - 1];
                    if (TechniqueName.Length >= i)
                    {
                        if (techniqueSelect == i - 1)//選択中は赤
                            txt.color = Color.red;
                        else
                            txt.color = Color.black;
                    }
                    else
                    {
                        txt.color = Color.clear;
                    }
                }
                //技の説明を変える
                txt = techniqueDescription.GetComponent<Text>();
                txt.text = selectDescription;

                break;

            case BattleSystemScript.BattleState.ChooseEnemy://-----------------------------------------------------------------------------------
                if (oldState != nowState)
                {
                    oldState = nowState;
                    //技、技選ぶ、アルファ値を下げる
                    for (int i = 0; i < techniqueObject.Count; i++)
                    {
                        txt = techniqueObject[i].GetComponent<Text>();
                        txt.color -= new Color(0, 0, 0, 0.5f);
                    }
                    //技の説明は見えなくする
                    txt = techniqueDescription.GetComponent<Text>();
                    txt.color = Color.clear;
                    //入力する文字を表示する
                    txt = inputTechnique.GetComponent<Text>();
                    txt.color = Color.black;
                    txt.text = answerString;
                    //敵選択文字色
                    txt = enemyObject[0].GetComponent<Text>();
                    txt.color = Color.black;

                }
                //毎回
                //敵文字の色、内容変更
                for (int i = 1; i < enemyObject.Count; i++)
                {
                    txt = enemyObject[i].GetComponent<Text>();//いったんわざを入れていく、後で直すその２
                    if (enemyName.Length >= i)//敵存在番号まで表示文字代入
                        txt.text = enemyName[i - 1];
                    if (enemyName.Length >= i)
                    {
                        if (enemySelect == i - 1)//選択中は赤
                            txt.color = Color.red;
                        else
                            txt.color = Color.black;
                    }
                    else
                    {
                        txt.color = Color.clear;//毎回変えるの無駄
                    }
                }
                break;

            case BattleSystemScript.BattleState.InputText://-----------------------------------------------------------------------------------
                if (oldState != nowState)
                {
                    //入力時の背景の文字は変わらないので表示、色
                    txt = inputTechnique.GetComponent<Text>();
                    txt.text = TechniqueName[techniqueSelect];
                    txt = inputAnswer.GetComponent<Text>();
                    txt.color = Color.red;
                    txt.text = "";
                   oldState = nowState;
                }
                txt = inputAnswer.GetComponent<Text>();
                txt.text = answerString;
                break;
        }

    }

}
