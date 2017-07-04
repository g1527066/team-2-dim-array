using UnityEngine;
using System.Collections;

//クソ手抜きスクリプト戦闘前暗転みたいなの
public class BattleStartScript : MonoBehaviour {

    [SerializeField]
    Sprite BlackSprite;

    private Transform boT;
    public static bool BattleStart = false;
	// Use this for initialization
	void Start () {
        GameObject BlackOutSprite = new GameObject("BlackSprite");
        SpriteRenderer boSr = BlackOutSprite.AddComponent<SpriteRenderer>();
        boSr.sprite = BlackSprite;
        boSr.color = Color.black;
        boSr.sortingOrder = 10;
        BlackOutSprite.transform.localScale = new Vector3(5, 5, 1);
        boT = BlackOutSprite.transform;
	}

	// Update is called once per frame
	void Update () {
        if (boT.position.x > -20) boT.position += new Vector3(-0.5f, 0, 0);
        else {
            BattleStart = true;
            Destroy(this.GetComponent<BattleStartScript>());
        }
	}
}
