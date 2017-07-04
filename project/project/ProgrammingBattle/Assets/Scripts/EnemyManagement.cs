using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//三角:このクラスで、何回目はこいつを出すとかの指示をまとめたいと思っています。

public class EnemyManagement
{

     GameObject karienemy;


    int battleEncounterCount;//今が何回目のバトルか
    List<GameObject> enemy = new List<GameObject>();//ここに今いる敵を格納します
    public List<GameObject> Enemy
    {
        get { return enemy; }
    }

    const int maxEnemyNumber = 5;//敵は場に最大5体まで
     Vector3[] enemyPosition = new Vector3[5] {new Vector3(-2,2.5f,0), new Vector3(0, 2.5f, 0), new Vector3(2, 2.5f, 0), new Vector3(4, 2.5f, 0), new Vector3(6, 2.5f, 0) };


    public EnemyManagement(List<GameObject> copyEnemy)
    {
        karienemy = copyEnemy[0];
        battleEncounterCount = 0;
    }

    //敵オブジェクトを生成します
    GameObject Generation(GameObject prefab,Vector3 position)
    {
        GameObject bullet = GameObject.Instantiate(prefab) as GameObject;
        bullet.transform.localPosition = position;
        return bullet;
    }

    //次のマップに移動した際に敵を新しく生成します
    public void GenerationEnemy()
    {
        //すべてのデータ消したから
         enemy.Clear();

        //生成,リストに追加
        switch (1)//いったん
        {
            case 1:
                enemy.Add(Generation(karienemy,enemyPosition[2]));
                enemy.Add(Generation(karienemy, enemyPosition[3]));
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;


        }
    }

    //死んだ敵をリストから抹消します
    public void DeleteEnemy()
    {

    }

    //++で増えた敵をリストに追加
    public void AddEnemy()
    {

    }



}
