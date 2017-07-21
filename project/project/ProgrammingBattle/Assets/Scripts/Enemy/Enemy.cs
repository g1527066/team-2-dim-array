using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//三角：
//すべての敵のもとになるクラス
//敵を作るときはここから派生クラスを作って、特殊に応じてoverrideしていく感じを考えています。
//おかしかったら言ってください・・・

public class Enemy : MonoBehaviour
{
    protected int hp;
    protected int attack;
    protected float attackInterval;
    protected float elapsedTime;
    protected string enemyName;//敵名
    public string EnemyName
    {
        get { return enemyName; }
    }
    protected string enemyDescription;//敵をサーチした時に出てくる説明文

    protected GameObject attackTarget;

    //protected enum EnemyState//時間があったら演出用に
    //{
    //    Wait,//タイマーをためている状態
    //    Attack,//攻撃中演出、タイマーをいったん停止
    //}


    ////各自時計オブジェクトを持つ
    //private GameObject timer;
    //田中：ここで敵のタイムメーター作らせてもらいます
    protected Transform secondHand;//秒針
    protected float angle;         //1フレームに回す角度

    protected void Start()
    {
        attackTarget = GameObject.FindWithTag("Player");

        //すべて適当です
        hp = 1;
        attack = 3;
        attackInterval = 7f;
        elapsedTime = 0f;
        enemyName = "敵の名前";
        enemyDescription = "敵の説明";

        //田中：タイムメーターの秒針です
        secondHand = this.transform.Find("timer/pivot");
        angle = 360 / attackInterval;
    }

    protected void Update()
    {
        elapsedTime += Time.deltaTime;
        Attack();

        //田中：秒針回転
        secondHand.Rotate(0, 0, -angle * Time.deltaTime);
    }

    protected void Attack()
    {
        if (elapsedTime > attackInterval)
        {
            attackTarget.GetComponent<PlayerScript>().Attacked(attack);
            elapsedTime = 0f;
        }
    }

    public void Attacked(int attacked)//攻撃を受けたとき
    {
        hp -= attacked;
        Debug.Log("enemyHP=" + hp);
        if (hp <= 0)//オブジェクト削除
        {
            gameObject.SetActive(false);
            SpriteRenderer.Destroy(this, 0f);
            Destroy(this, 0);
            GameObject go = GameObject.Find("SystemObject");
            go.GetComponent<BattleSystemScript>().GetEnemyManagement.DeleteEnemy(this.gameObject);//悪い参照の仕方
        }
    }

    //セレクト状態で色を変化します
    public void ChangeColor(bool isSelect)//falseなら元の色に戻します。
    {
        SpriteRenderer sR = this.GetComponent<SpriteRenderer>();
        if (isSelect)
        {
            sR.color = Color.red;//選択中赤、もっといい色あればいいな、、
        }
        else
        {
            sR.color = Color.white;
        }
    }
}
