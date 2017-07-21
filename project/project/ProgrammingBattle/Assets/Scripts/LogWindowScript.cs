using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogWindowScript : MonoBehaviour {

    [SerializeField]
    private Text Text1;
    [SerializeField]
    private Text Text2;
    [SerializeField]
    private Text Text3;
    [SerializeField]
    private Text Text4;
    [SerializeField]
    private Text Text5;

    public static Text text1;
    public static Text text2;
    public static Text text3;
    public static Text text4;
    public static Text text5;

    // Use this for initialization
    void Start()
    {
        text1 = Text1;
        text2 = Text2;
        text3 = Text3;
        text4 = Text4;
        text5 = Text5;
        //text1 = GameObject.Find("").GetComponent<Text>();
        //text2 = GameObject.Find("").GetComponent<Text>();
        //text3 = GameObject.Find("").GetComponent<Text>();
        //text4 = GameObject.Find("").GetComponent<Text>();
        //text5 = GameObject.Find("").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {

	}

    public static void Text(string word)
    {
        Debug.Log("window");
        text5.text = text4.text;
        text4.text = text3.text;
        text3.text = text2.text;
        text2.text = text1.text;
        switch(word)
        {
            default:
                text1.text = word;
                break;
            case "HP+=10":
                text1.text = "プレイヤーのHPに+10";
                break;
            case "//Comment":
                text1.text = "ダメージをコメントアウト";
                break;
            case "While(true)":
                text1.text = "敵の行動速度低下";
                break;
            case "using enemy":
                text1.text = "敵の情報を取得";
                break;
            case "enemy-=10":
                text1.text = "敵の体力に-10ダメージ";
                break;
            case "enemy/=2":
                text1.text = "敵の体力に/2ダメージ";
                break;
            case "const int":
                text1.text = "敵にの体力に固定ダメージ";
                break;
            case "null":
                text1.text = "未定義";
                break;
        }        
    }
}
