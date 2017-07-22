using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーに貼り付け
public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer[] hpSprite = new SpriteRenderer[5];

    private const int c_MaxHP = 5;
    private int hp = 5;
    private int attack = 1;
    private int defense = 1;
    private GameObject attackTarget;//攻撃対象
    private bool isComment = false;//このフラグがたっていると次の攻撃くらわない

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
        if (isComment)//防いだときエフェクト入れたい
            isComment = false;
        else
            hp -= attacked;

        Debug.Log(hp);
        DrawHP();
        if (hp <= 0)
            Application.LoadLevel("GameOver");
    }

    public void SetEnemy(GameObject enemyName)//攻撃対象を選択したときにオブジェクトにセットします
    {
        attackTarget = enemyName;
        Debug.Log("セットされました");
        // gameObject.GetComponent<EnemyScript>();
        // attackTarget = GameObject.FindWithTag(enemyName);
    }

    public void TechniqueSuccess(TechniqueList techniqueList)//術成功
    {

        switch (techniqueList)
        {
            case TechniqueList.comment:
                isComment = true;
                Debug.Log("commentフラグ");
                break;

            case TechniqueList.constant:
                attackTarget.GetComponent<Enemy>().Attacked(8);//8ってきまってる、
                break;

            case TechniqueList.division:// /2
                attackTarget.GetComponent<Enemy>().TechniqueDivision();
                break;


            case TechniqueList.fake:
                attackTarget.GetComponent<Enemy>().AttributeAttacked(6, false);
                break;

            case TechniqueList.plus:
                //回復、音、エフェクトいれたい
                hp = c_MaxHP;
                DrawHP();
                break;

            case TechniqueList.pure:
                attackTarget.GetComponent<Enemy>().AttributeAttacked(6,true);
                break;

            case TechniqueList.small:
                attackTarget.GetComponent<Enemy>().Attacked(10);//10ってきまってる、、
                break;
            default:
                Debug.Log("技発動時例外");
                break;

        }
 
    }

    private void DrawHP()
    {
        for (int i = 0; i < hpSprite.Length; i++)
        {
            if (hp > i)
                hpSprite[i].gameObject.SetActive(true);
            else
                hpSprite[i].gameObject.SetActive(false);
        }
    }

}
