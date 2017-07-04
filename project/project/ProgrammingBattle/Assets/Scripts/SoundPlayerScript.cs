using UnityEngine;

//オーディオマネージャースクリプトを利用して音を流すためのスクリプト
//といってもここでやっているのはほぼフラグ管理...
public class SoundPlayerScript : MonoBehaviour
{
    //よそからこの中のフラグが立たされると、対応した音を流す
    //public static bool seFlag_Choose;
    //public static bool seFlag_Click;
    //public static bool seFlag_Key;
    //public static bool seFlag_TimeRecover;
    //public static bool seFlag_Door;
    //public static bool seFlag_Locked;
    //public static bool seFlag_Arrow;
    //public static bool seFlag_Shake;
    //public static bool seFlag_Impact;
    //public static bool seFlag_Switch;
    //public static bool seFlag_Damage;

    //public static bool bgmFlag_StageSelect;
    //public static bool bgmFlag_Stage0;
    //public static bool bgmFlag_Stage1;
    //public static bool bgmFlag_Stage2;
    //public static bool bgmFlag_Stage3;
    //public static bool bgmFlag_GameOver;
    //public static bool bgmFlag_Crear;

    // Use this for initialization
    void Start ()
    {
        //seFlag_Choose = false;
        //seFlag_Click = false;
        //seFlag_Key = false;
        //seFlag_TimeRecover = false;
        //seFlag_Door = false;
        //seFlag_Locked = false;
        //seFlag_Arrow = false;

        //bgmFlag_StageSelect = false;
        //bgmFlag_Stage0 = false;
        //bgmFlag_Stage1 = false;
        //bgmFlag_Stage2 = false;
        //bgmFlag_Stage3 = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ////ＳＥ
        //if(seFlag_Choose) {//選択音
        //    AudioManagerScript.Instance.PlaySE("SE_CHOOSE");
        //    seFlag_Choose = false;
        //}
        //if (seFlag_Click) {//決定音
        //    AudioManagerScript.Instance.PlaySE("SE_CLICK");
        //    seFlag_Click = false;
        //}
        //if (seFlag_Key) {//鍵取得音
        //    AudioManagerScript.Instance.PlaySE("SE_KEY");
        //    seFlag_Key = false;
        //}
        //if (seFlag_TimeRecover) {//時間回復音
        //    AudioManagerScript.Instance.PlaySE("SE_TIMERECOVER");
        //    seFlag_TimeRecover = false;
        //}
        //if (seFlag_Door) {//ドア開く音
        //    AudioManagerScript.Instance.PlaySE("SE_DOOR");
        //    seFlag_Door = false;
        //}
        //if (seFlag_Locked) {//ドア鍵がかかってる音
        //    AudioManagerScript.Instance.PlaySE("SE_DOOR_LOCK");
        //    seFlag_Locked = false;
        //}
        //if (seFlag_Arrow) {//矢発射音
        //    AudioManagerScript.Instance.PlaySE("SE_ARROW");
        //    seFlag_Arrow = false;
        //}
        //if (seFlag_Shake) {//揺れる音
        //    AudioManagerScript.Instance.PlaySE("SE_SHAKE");
        //    seFlag_Shake = false;
        //}
        //if (seFlag_Impact) {//衝撃音
        //    AudioManagerScript.Instance.PlaySE("SE_IMPACT");
        //    seFlag_Impact = false;
        //}
        //if (seFlag_Switch)
        //{//スイッチに触った音
        //    AudioManagerScript.Instance.PlaySE("SE_SWITCH");
        //    seFlag_Switch = false;
        //}
        //if (seFlag_Damage)
        //{//ダメージ音
        //    AudioManagerScript.Instance.PlaySE("SE_DAMAGE");
        //    seFlag_Damage = false;
        //}

        ////ＢＧＭ
        //if (bgmFlag_StageSelect) {
        //    AudioManagerScript.Instance.PlayBGM("STAGE_SELECT");
        //    bgmFlag_StageSelect = false;
        //}
        //if (bgmFlag_Stage1) {
        //    AudioManagerScript.Instance.PlayBGM("STAGE1");
        //    bgmFlag_Stage1 = false;
        //}
        //if (bgmFlag_Stage2) {
        //    AudioManagerScript.Instance.PlayBGM("STAGE2");
        //    bgmFlag_Stage2 = false;
        //}
        //if (bgmFlag_Stage3) {
        //    AudioManagerScript.Instance.PlayBGM("STAGE3");
        //    bgmFlag_Stage3 = false;
        //}
        //if (bgmFlag_GameOver) {
        //    AudioManagerScript.Instance.PlayBGM("BGM_GAMEOVER");
        //    bgmFlag_GameOver = false;
        //}
        //if(bgmFlag_Crear) {
        //    AudioManagerScript.Instance.PlayBGM("BGM_CREAR");
        //    bgmFlag_Crear = false;
        //}
    }
}
