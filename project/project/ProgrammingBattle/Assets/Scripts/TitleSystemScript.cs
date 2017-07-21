using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSystemScript : MonoBehaviour {

    [SerializeField]//privateな変数をインスペクタに表示するよ
    private Camera mainCamera;
    [SerializeField]
    private Sprite BackgroundImage;
    [SerializeField]
    private Sprite StartButtonImage;

    // Use this for initialization
    void Start () {
        SoundPlayerScript.bgmFlag_TitleBgm = true;

        //背景用ゲームオブジェクト
        GameObject background = new GameObject("Background");
        Transform bgT = background.transform;
        bgT.position = new Vector3(0f, 0f, 0.5f);
        bgT.rotation = Quaternion.Euler(Vector3.zero);
        bgT.localScale = Vector3.one;

        //背景用ゲームオブジェクトのスプライトレンダラー
        SpriteRenderer bgSr = background.AddComponent<SpriteRenderer>();
        bgSr.sprite = BackgroundImage;
        bgSr.color = new Color(255/255, 255/255, 255/255);
        bgSr.flipX = false; bgSr.flipY = false;
        //エディタ実行かエグゼ実行かでデフォルトリソースは参照の仕方が違うらしい
        //デフォルトマテリアルを使わないなら#ifは消していい
        //むしろデフォマテリアルのままなら記述しなくてよくない？→なんとなく勉強用
        #if UNITY_EDITOR
            bgSr.material = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Material>("Sprites-Default.mat");
        #else
            bgSr.material = Resources.GetBuiltinResource<Material>("Sprites-Default.mat");
        #endif
        bgSr.sortingLayerName = "Default";
        bgSr.sortingOrder = 0;

        //シーン遷移ボタン
        GameObject startButton = new GameObject("StartButton");
        Transform sbT = startButton.transform;
        sbT.position = new Vector3(0f, -1f, 0.5f);
        sbT.rotation = Quaternion.Euler(Vector3.zero);
        sbT.localScale = Vector3.one;

        //シーン遷移ボタンのスプライトレンダラー
        SpriteRenderer sbSr = startButton.AddComponent<SpriteRenderer>();
        sbSr.sprite = StartButtonImage;
        sbSr.color = new Color(255 / 255, 255 / 255, 255 / 255);
        sbSr.flipX = false; sbSr.flipY = false;
        #if UNITY_EDITOR
        sbSr.material = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Material>("Sprites-Default.mat");
        #else
            sbSr.material = Resources.GetBuiltinResource<Material>("Sprites-Default.mat");
        #endif
        sbSr.sortingLayerName = "Default";
        sbSr.sortingOrder = 1;

        //シーン遷移ボタンレイキャストヒット用コリジョンボックス
        BoxCollider sbBc = startButton.AddComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update () {
        if(RayScript.getObj(mainCamera) == "StartButton" && Input.GetMouseButtonDown(0))
        {
            SoundPlayerScript.seFlag_Choose = true;
            LoadingScript.nextScene = "MainScene";
            SceneManager.LoadScene("LoadingScene");
        }
	}
}
