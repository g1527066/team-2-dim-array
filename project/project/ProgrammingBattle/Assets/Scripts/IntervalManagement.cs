using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


//ここで間のアイテム取得などの管理をします
class IntervalManagement
{
    GameObject Canvas;
    GameObject text;

    GameObject ArrowR;
    GameObject ArrowL;




    string chooseMessage = "どちらの道に行きますか？";
    private Text txt;
    bool oldState = false;//このフラグがfalseで前の状態がインターバル以外であったことになります

    bool oneClick = false;//矢印選択時２回クリックじゃないと移動できない仕様用のフラグ
    bool rightClick = false;
    bool endClick = false;//入力が二回とも終了したなら
    public bool EndClick
    {
        get { return endClick; }
    }
    public IntervalManagement()
    {
        Canvas = GameObject.Find("Canvas");
        text = (GameObject)Resources.Load("2DObject/TechniqueName");
     

    }

    //テキストオブジェクトを生成します
    GameObject GenerationText(GameObject prefab, Vector3 position, int fontSize, string drawString, Color color)
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

    //オブジェクトを生成します
    GameObject Generation(GameObject prefab, Vector3 position)
    {
        GameObject ob = GameObject.Instantiate(prefab) as GameObject;
        ob.transform.localPosition = position;
        return ob;
    }


    public void UpdateInterval(int batteleCount)//いつの間か
    {
        //前がintervalじゃ無かったらいろいろ初期化、生成します
        if (oldState == false)
        {
            ArrowR = ArrowL = (GameObject)Resources.Load("2DObject/Arrow");
            ArrowL = Generation(ArrowL, Vector2.zero);//削除した後だとエラー起きそう
            ArrowR = Generation(ArrowR, Vector2.one);
            ArrowR.transform.Rotate(new Vector3(0, 0, 180));//いったん変えとく、画像が仮のため

            oneClick = false;
            rightClick = false;
            endClick = false;

            switch (batteleCount)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;
            }
            oldState = true;
        }

        KeyCode inputNumber = KeyCheck();

        switch (inputNumber)
        {
            case KeyCode.RightArrow:
                if (oneClick == false)//初めて右クリックしたら
                {
                    oneClick = true;
                    rightClick = true;
                }
                else if (oneClick == true && rightClick == true)//２回目も右クリックだったら
                {
                    endClick = true;
                    MonoBehaviour.Destroy(ArrowL);
                    MonoBehaviour.Destroy(ArrowR);
                    oldState = false;

                }
                else//逆クリック後
                {
                    rightClick = true;
                }

                break;

            case KeyCode.LeftArrow:
                if (oneClick == false)
                {
                    oneClick = true;
                    rightClick = false;
                 
                }
                else if (oneClick == true && rightClick == false)
                {
                    endClick = true;
                    MonoBehaviour.Destroy(ArrowL);
                    MonoBehaviour.Destroy(ArrowR);
                    oldState = false;
                }
                else//逆クリック後
                {
                    rightClick = false;
                }

                break;

            default:
                break;
        }


        DrawUpdate();

    }

    private void DrawUpdate()
    {
        if (oneClick == true && endClick == false) //どちらかクリックしている方の矢印を大きくしているだけです。
        {
            SpriteRenderer sr;
            if (rightClick == true)
            {
                sr = ArrowR.GetComponent<SpriteRenderer>();
                sr.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                sr = ArrowL.GetComponent<SpriteRenderer>();
                sr.transform.localScale = new Vector3(1.0f, 1.0f, 0);
            }
            else
            {
                sr = ArrowL.GetComponent<SpriteRenderer>();
                sr.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                sr = ArrowR.GetComponent<SpriteRenderer>();
                sr.transform.localScale = new Vector3(1.0f, 1.0f, 0);
            }
        }
    }


    //入力チェック関数
    //入力したものをキーコードで返す
    private KeyCode KeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code)) return code;
            }
        }
        return KeyCode.None;
    }
}




