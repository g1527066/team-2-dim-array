using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//たぶん、敵に貼り付け？
public class EnemyScript : MonoBehaviour
{
    private GameObject attackTarget;               //攻撃対象
    [SerializeField]public static int hp = 3;      //体力
    [SerializeField]public static int defense = 1; //防御力
    [SerializeField]private int attack = 1;        //攻撃力
    [SerializeField]private float attackInterval = 3f;//３秒ごとに攻撃なかなかやばい
    //
    //敵のステータスは外部から弄れるようにしたほうが良い気がしたので弄りましたすみません
    
    public GameObject testObject;
    private float elapsedTime = 0f;

    //田中：ここで敵のタイムメーター作らせてもらいます
    private Transform secondHand;//秒針
    private float angle;         //1フレームに回す角度

    // Use this for initialization
    void Start()
    {
        attackTarget = GameObject.FindWithTag("Player");

        //田中：タイムメーターの秒針です
        secondHand = this.transform.FindChild("timer/pivot");
        angle = 360 / attackInterval;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Attack();

        //田中：秒針回転
        secondHand.Rotate(0, 0, -angle * Time.deltaTime);
    }

    private void Attack()
    {
        if (elapsedTime > attackInterval)
        {
            attackTarget.GetComponent<PlayerScript>().Attacked(attack);
            elapsedTime = 0f;
        }
    }


    public void Attacked(int attacked)//攻撃を受けたとき
    {
        hp-=attacked;
        Debug.Log("enemyHP="+hp);
        if(hp<=0)//オブジェクト削除
        {
            gameObject.SetActive(false);
            SpriteRenderer.Destroy(this,0f);
            Destroy(this, 0);


            GameObject test = LoadEnemy();


        }

    }


    GameObject LoadEnemy()
    {
        GameObject bullet = GameObject.Instantiate(testObject) as GameObject;
        bullet.transform.parent = transform;
        bullet.transform.localPosition = Vector3.zero;
        return bullet;


    }

}
