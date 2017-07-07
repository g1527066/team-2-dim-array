using UnityEngine;
using UnityEngine.UI;
//using System.Collections;
using System;
using System.Collections.Generic;
public class BattleSystemScript : MonoBehaviour
{

    //色々とクラス化した方がよくね？って部分はあると思う...
    //けどクラス化は苦手なので今後も期待できません...

    [SerializeField]
    private SpriteRenderer[] enemy = new SpriteRenderer[3];
    [SerializeField]
    private SpriteRenderer[] enemyWindow = new SpriteRenderer[3];
    [SerializeField]
    private SpriteRenderer[] wordWindow = new SpriteRenderer[3];
    [SerializeField]
    private Text[] wordText = new Text[3];
    [SerializeField]
    private Text[] textBox = new Text[2];     //フキダシ/答え

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private string[] wordList = new string[3];

    private Color ChooseColor = new Color(1, 1, 0);
    private Color NotChooseColor = new Color(1, 1, 1);

    //ここに出現させた敵の管理を行います
    EnemyManagement enemyManagement;
    public EnemyManagement GetEnemyManagement
    {
        get { return enemyManagement; }
    }


    //enunm型のほうがわかりやすいと思って変えさせてもらいました
    public enum BattleState
    {
        Interval,//間の分かれ道の時などバトル中じゃないところです
        ChooseWord,
        ChooseEnemy,//あとでwordと逆にする
        InputText,

    }

    BattleState battleState;

    TextManagement textManagement;//文字生成管理

    //  private string phase = "ChooseEnemy";
    private string StringBox;

    private int inputNum = 0;//入力何文字目
    private int wordNum = 0;//どの技を選択したか
    private bool onePush = false;//二回その文字を入力しないと次に進めない
    private GameObject player;

    int oldSelectNumber = 0;//前に選択したエネミーの色を戻すためです


    // Use this for initialization
    void Start()
    {

        battleState = BattleState.ChooseWord;
        enemyManagement = new EnemyManagement();
        textManagement = new TextManagement();
        //いったん
        string[] aaa = new string[] { "わざ１", "わざ2", "わざ3" };
        textManagement.SelectedTechnique(enemyManagement.EnemyArray(), aaa, "技の説明ですね", 0,0, battleState);
        //////////////


        player = GameObject.FindWithTag("Player");
        int i = 0;
        while (i < 3)
        {
            enemyWindow[i].color = NotChooseColor;
            enemy[i].color = NotChooseColor;
            wordWindow[i].color = NotChooseColor;
            wordText[i].text = wordList[UnityEngine.Random.Range(0, wordList.Length)];
            i++;
        }
        textBox[0].text = textBox[1].text = "";
    }

    // Update is called once per frame
    void Update()
    {
        enemyManagement.AllDeadEnemy();//敵がすべて死んでいたら生成します
        if (BattleStartScript.BattleStart)
        {
            switch (battleState)//それぞれのフェーズへ
            {

                case BattleState.ChooseWord:
                    ChooseWord();
                    break;
                case BattleState.ChooseEnemy:
                    ChooseEnemy();
                    break;
                case BattleState.InputText:
                    InputText();
                    break;
            }
        }
        //いったん
        string[] aaa = new string[] { "わざ１", "わざ2", "わざ3" };
        textManagement.SelectedTechnique(aaa, enemyManagement.EnemyArray(), "技の説明ですね", wordNum, oldSelectNumber, battleState);
        //////////////


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

    //敵選択フェーズ
    private void ChooseEnemy()
    {
        KeyCode inputNumber = KeyCheck();

        if (Input.anyKeyDown)
        {
            switch (inputNumber)
            {
                case KeyCode.Alpha1://敵１
                    if (oldSelectNumber != 0)//色を元に戻す
                    {
                        enemyManagement.Enemy[oldSelectNumber].GetComponent<Enemy>().ChangeColor(false);
                        onePush = false;
                    }
                        oldSelectNumber = 0;
                    enemyWindow[0].color = ChooseColor; //選択したウィンドウの色を変える
                    enemy[0].color = ChooseColor;       //敵の色を変える
                    enemyManagement.Enemy[0].GetComponent<Enemy>().ChangeColor(true);
                      if (oldSelectNumber == 0 && onePush == true)
                    battleState++;            //次のフェーズへ
                    player.GetComponent<PlayerScript>().SetEnemy(enemyManagement.Enemy[0]);//攻撃対象の敵セット
                    onePush = true;
                    break;
                case KeyCode.Alpha2://敵２
                    if (enemyManagement.Enemy.Count >= 2)
                    {
                        if (oldSelectNumber != 1)
                        {
                            enemyManagement.Enemy[oldSelectNumber].GetComponent<Enemy>().ChangeColor(false);
                            onePush = false;
                        }
                            oldSelectNumber = 1;
                        enemyWindow[1].color = ChooseColor;
                        enemy[1].color = ChooseColor;
                        if (oldSelectNumber == 1 && onePush == true)
                            battleState++;
                            enemyManagement.Enemy[1].GetComponent<Enemy>().ChangeColor(true);
                        player.GetComponent<PlayerScript>().SetEnemy(enemyManagement.Enemy[1]);
                        onePush = true;
                    }
                    break;
                case KeyCode.Alpha3://敵３
                    if (enemyManagement.Enemy.Count >= 3)
                    {
                        if (oldSelectNumber != 2)
                        {
                            enemyManagement.Enemy[oldSelectNumber].GetComponent<Enemy>().ChangeColor(false);
                            onePush = false;
                        }
                            oldSelectNumber = 2;
                        enemyWindow[2].color = ChooseColor;
                        enemy[2].color = ChooseColor;
                        if (oldSelectNumber == 2 && onePush == true)
                            battleState++;
                        enemyManagement.Enemy[2].GetComponent<Enemy>().ChangeColor(true);
                        player.GetComponent<PlayerScript>().SetEnemy(enemyManagement.Enemy[2]);
                        onePush = true;
                    }
                    break;

                case KeyCode.Alpha4://敵4
                    if (enemyManagement.Enemy.Count >= 4)
                    {
                        if (oldSelectNumber != 3)
                        {
                            enemyManagement.Enemy[oldSelectNumber].GetComponent<Enemy>().ChangeColor(false);
                            onePush = false;
                        }
                            oldSelectNumber = 3;
                        enemyWindow[2].color = ChooseColor;
                        enemy[2].color = ChooseColor;
                        if (oldSelectNumber == 3 && onePush == true)
                            battleState++;
                        enemyManagement.Enemy[3].GetComponent<Enemy>().ChangeColor(true);
                        player.GetComponent<PlayerScript>().SetEnemy(enemyManagement.Enemy[3]);
                        onePush = true;
                    }
                    break;

                case KeyCode.Alpha5://敵5
                    if (enemyManagement.Enemy.Count >= 5)
                    {
                        if (oldSelectNumber != 4)
                        {
                            enemyManagement.Enemy[oldSelectNumber].GetComponent<Enemy>().ChangeColor(false);
                            onePush = false;
                        }
                            oldSelectNumber = 4;
                        enemyWindow[2].color = ChooseColor;
                        enemy[2].color = ChooseColor;
                        if (oldSelectNumber == 4 && onePush == true)
                            battleState++;
                        enemyManagement.Enemy[4].GetComponent<Enemy>().ChangeColor(true);
                        player.GetComponent<PlayerScript>().SetEnemy(enemyManagement.Enemy[4]);
                        onePush = true;
                    }
                    break;

            }
        }
    }

    //技ワード選択フェーズ
    private void ChooseWord()
    {
        KeyCode inputNumber = KeyCheck();

        if (Input.anyKeyDown)
        {
            switch (inputNumber)
            {
                case KeyCode.Alpha1://技１
                    if (wordNum != 0)//前回と同じ入力じゃな無ければ
                        onePush = false;
                    wordWindow[0].color = ChooseColor;  //選択したウィンドウの色を変える
                    StringBox = wordText[0].text;       //フキダシに表示する用にテキストを保存
                    if (onePush == true && wordNum == 0)
                    {
                        onePush = false;
                        battleState++; //次のフェーズへ
                    }            
                    wordNum = 0;                        //再抽選用に選択した番号の保存
                    onePush = true;
                    break;
                case KeyCode.Alpha2://技２
                    if (wordNum != 1)//前回と同じ入力じゃな無ければ
                        onePush = false;
                    if (onePush == true && wordNum == 1)
                    {
                        onePush = false;
                        battleState++;
                    }
                    onePush = true;
                    wordWindow[1].color = ChooseColor;
                    StringBox = wordText[1].text;
                    wordNum = 1;
                    break;
                case KeyCode.Alpha3://技３
                    if (wordNum != 2)//前回と同じ入力じゃな無ければ
                        onePush = false;
                    wordWindow[2].color = ChooseColor;
                    StringBox = wordText[2].text;
                    wordNum = 2;
                    if (onePush == true && wordNum == 2)
                    {
                        onePush = false;
                        battleState++;
                    }
                    onePush = true;
                    break;
            }
            textBox[0].text = StringBox;
        }
    }

    //キー入力フェーズ
    private void InputText()
    {
        //入力確認
        if (inputNum < StringBox.Length)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(StringBox.Substring(inputNum, 1)/*i文字目から1文字分*/))
                {
                    //テキストカラーを変えるならたぶんここ
                    Debug.Log("Good!");
                    inputNum++;
                    textBox[1].text = textBox[0].text.Substring(0, inputNum);

                }
                else
                {
                    //入力ミス
                    Debug.Log("Bad!");
                }
            }
        }
        //入力完了処理いろいろ
        else
        {
            //敵のHPを減らす（いったん今はただ一定攻撃するだけで技による対応などはしてないです。       
            //倒す前に色を元に戻しとく
            enemyManagement.Enemy[oldSelectNumber].GetComponent<Enemy>().ChangeColor(false);
            player.GetComponent<PlayerScript>().Attack();


            int i = 0;
            while (i < 3)
            {
                //選択色を再度初期化
                enemyWindow[i].color = NotChooseColor;
                enemy[i].color = NotChooseColor;
                wordWindow[i].color = NotChooseColor;
                i++;
            }
            //フキダシを空に
            textBox[0].text = textBox[1].text = "";
            //入力文字数をリセット
            inputNum = 0;
            //一度選択したテキストを再抽選
            wordText[wordNum].text = wordList[UnityEngine.Random.Range(0, wordList.Length)];
            //もう一度技選択フェーズへ
            battleState = BattleState.ChooseWord;
        }
    }
}
