using UnityEngine;
using UnityEngine.UI;
//using System.Collections;
using System;
using System.Collections.Generic;
public class BattleSystemScript : MonoBehaviour {

    //色々とクラス化した方がよくね？って部分はあると思う...
    //けどクラス化は苦手なので今後も期待できません...
    
    [SerializeField] private SpriteRenderer[] enemy = new SpriteRenderer[3];
    [SerializeField] private SpriteRenderer[] enemyWindow = new SpriteRenderer[3];
    [SerializeField] private SpriteRenderer[] wordWindow = new SpriteRenderer[3];
    [SerializeField] private Text[] wordText = new Text[3];
    [SerializeField] private Text[] textBox = new Text[2];     //フキダシ/答え

    [SerializeField] private GameObject canvas;

    [SerializeField]
    private string[] wordList = new string[3];

    private Color ChooseColor = new Color(1, 1, 0);
    private Color NotChooseColor = new Color(1, 1, 1);

    //ここに出現させる敵のプレファブを入れて生成する方に渡します。
    //スクリプト内のスクリプトにデータをuinty上で入れるのがわからなかったのでこうなりました。すみません：三角
    [SerializeField]
    private List<GameObject> enemyList;
    EnemyManagement enemyManagement;

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
    private GameObject player;

    // Use this for initialization
    void Start () {
        battleState = BattleState.ChooseWord;
        enemyManagement = new EnemyManagement(enemyList);
        textManagement = new TextManagement();
        //いったん
        string[] aaa = new string[]{ "わざ１", "わざ2", "わざ3" };
        textManagement.SelectedTechnique(aaa,"技の説明ですね",0,battleState);
        //////////////
        enemyManagement.GenerationEnemy();//敵を生成します

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
        textBox[0].text = textBox[1].text= "";
    }

    // Update is called once per frame
    void Update()
    {
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
                    enemyWindow[0].color = ChooseColor; //選択したウィンドウの色を変える
                    enemy[0].color = ChooseColor;       //敵の色を変える
                    battleState++;            //次のフェーズへ
                    player.GetComponent<PlayerScript>().SetEnemy("Enemy1");//攻撃対象の敵セット
                    break;
                case KeyCode.Alpha2://敵２
                    enemyWindow[1].color = ChooseColor;
                    enemy[1].color = ChooseColor;
                    battleState++;
                    player.GetComponent<PlayerScript>().SetEnemy("Enemy2");
                    break;
                case KeyCode.Alpha3://敵３
                    enemyWindow[2].color = ChooseColor;
                    enemy[2].color = ChooseColor;
                    battleState++;
                    player.GetComponent<PlayerScript>().SetEnemy("Enemy3");
                    break;

                case KeyCode.Alpha4://敵4
                    enemyWindow[2].color = ChooseColor;
                    enemy[2].color = ChooseColor;
                    battleState++;
                    player.GetComponent<PlayerScript>().SetEnemy("Enemy3");
                    break;

                case KeyCode.Alpha5://敵5
                    enemyWindow[2].color = ChooseColor;
                    enemy[2].color = ChooseColor;
                    battleState++;
                    player.GetComponent<PlayerScript>().SetEnemy("Enemy3");
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
                    wordWindow[0].color = ChooseColor;  //選択したウィンドウの色を変える
                    StringBox = wordText[0].text;       //フキダシに表示する用にテキストを保存
                    wordNum = 0;                        //再抽選用に選択した番号の保存
                    battleState++;               //次のフェーズへ
                    break;
                case KeyCode.Alpha2://技２
                    wordWindow[1].color = ChooseColor;
                    StringBox = wordText[1].text;
                    wordNum = 1;
                    battleState++;
                    break;
                case KeyCode.Alpha3://技３
                    wordWindow[2].color = ChooseColor;
                    StringBox = wordText[2].text;
                    wordNum = 2;
                    battleState++;
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
