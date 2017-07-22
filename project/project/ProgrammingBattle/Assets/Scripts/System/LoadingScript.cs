using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//ローディング画面のスクリプト
//黒背景に操作説明を出している画面
public class LoadingScript : MonoBehaviour
{
    private AsyncOperation async;
    public static string nextScene;
    [SerializeField]
    private GameObject UIPrefab;
    [SerializeField]
    private Sprite Image;
    //どのSceneをロードしたいかをここに入れてからここのSceneを呼ぶ

    // Use this for initialization
    void Start()
    {
        objManage();
        //タイトル画面に使っていたカメラ設定をそのまま利用
        GameObject UI = Instantiate(UIPrefab, new Vector3(0, 0f, 0), Quaternion.identity) as GameObject;
        if (nextScene == null) nextScene = "TitleScene";

        async = SceneManager.LoadSceneAsync(nextScene);
        async.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("loadNext");
    }

    void objManage()
    {
        GameObject manual;
        float manualSize = 0.6f;

        manual = new GameObject("ManualObject");
        manual.AddComponent<SpriteRenderer>().sprite = Image;
        manual.transform.position = Vector3.zero;
        manual.transform.localScale *= manualSize;
    }

    private IEnumerator loadNext()
    {
        //非同期ロードにはバグがあるらしく、待っていても1にならず完了しない
        while (async.progress < 0.9f)
        {
            yield return new WaitForEndOfFrame();
        }
        //ロードが完了したら右下のテキストを変える
        GameObject.Find("Text").GetComponent<Text>().text = "Complete";

        //シーン遷移実行
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            async.allowSceneActivation = true;
        }
    }
}
