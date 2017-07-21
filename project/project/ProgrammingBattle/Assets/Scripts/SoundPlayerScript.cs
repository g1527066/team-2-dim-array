using UnityEngine;

//オーディオマネージャースクリプトを利用して音を流すためのスクリプト
//といってもここでやっているのはほぼフラグ管理...
public class SoundPlayerScript : MonoBehaviour
{
    //よそからこの中のフラグが立たされると、対応した音を流す
    public static bool seFlag_Choose;

    public static bool bgmFlag_TitleBgm;
    public static bool bgmFlag_Tutorial;

    // Use this for initialization
    void Start ()
    {
        seFlag_Choose = false;

        bgmFlag_TitleBgm = false;
        bgmFlag_Tutorial = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ////ＳＥ
        if(seFlag_Choose) {//選択音
            AudioManagerScript.Instance.PlaySE("SE");
            seFlag_Choose = false;
        }

        ////ＢＧＭ
        if(bgmFlag_TitleBgm) {
            AudioManagerScript.Instance.PlayBGM("BGM");
            bgmFlag_TitleBgm = false;
        }
        if (bgmFlag_Tutorial) {
            AudioManagerScript.Instance.PlayBGM("BGM2");
            bgmFlag_Tutorial = false;
        }
    }
}
