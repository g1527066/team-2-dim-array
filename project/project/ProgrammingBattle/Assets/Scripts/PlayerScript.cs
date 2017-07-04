using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーに貼り付け
public class PlayerScript : MonoBehaviour {

    private int hp = 100;
    private int attack = 1;
    private int defense = 1;
    private GameObject attackTarget;//攻撃対象

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log("Time=" + time);

    }

    public void Attacked(int attacked)//攻撃を受けたとき
    {
        //田中：変数のミスで自分の攻撃力分のダメージを受けるようになってたので修正しました
        //元：hp -= attack;
        hp -= attacked;
        Debug.Log(hp);
    }

    public void SetEnemy(string enemyName)//攻撃対象を選択したときにオブジェクトにセットします
    {
        attackTarget = GameObject.Find(enemyName);
        // gameObject.GetComponent<EnemyScript>();
       // attackTarget = GameObject.FindWithTag(enemyName);
    }

    public void Attack()//敵に攻撃したとき
    {
        attackTarget.GetComponent<EnemyScript>().Attacked(attack);
    }

}
