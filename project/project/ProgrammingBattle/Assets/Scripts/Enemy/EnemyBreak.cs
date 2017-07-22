using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBreak : Enemy
{
    new protected void Start()
    {
        attackTarget = GameObject.FindWithTag("Player");

        //すべて適当です
        hp = 8;
        attack = 1;
        attackInterval = 10f;
        elapsedTime = 0f;
        enemyName = "Break";
        enemyDescription = "自分へのダメージをBreakし軽減させる";

        //田中：タイムメーターの秒針です
        secondHand = this.transform.Find("timer/pivot");
        angle = 360 / attackInterval;
    }


    new  public void Attacked(int attacked)//固定攻撃を受けたとき
    {
        hp -= attacked/2;
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

    new public void AttributeAttacked(int attacked, bool istrue)//属性攻撃を受けたとき  flag=属性がtrueならtrue
    {
        hp -= attacked/2;
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

    //  /2をくらったとき
    new  public void TechniqueDivision()
    {
        hp =(hp/=2)/2;
    }

}
