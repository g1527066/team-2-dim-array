using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseEnemy : Enemy
{
    new protected void Start()
    {
        attackTarget = GameObject.FindWithTag("Player");

        //すべて適当です
        hp = 12;
        attack = 1;
        attackInterval = 9f;
        elapsedTime = 0f;
        enemyName = "True";
        enemyDescription = "闇属性の敵、聖属性が苦手";

        //田中：タイムメーターの秒針です
        secondHand = this.transform.Find("timer/pivot");
        angle = 360 / attackInterval;
    }
    new public void AttributeAttacked(int attacked, bool istrue)//属性攻撃を受けたとき  flag=属性がtrueならtrue
    {
        if (!istrue)
            hp -= attacked;
        else
            hp -= (attacked * 2);


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
}
