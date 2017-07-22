using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//三角:このクラスで、何回目はこいつを出すとかの指示をまとめたいと思っています。

public class EnemyManagement
{
    int battleEncounterCount;//今が何回目のバトルか
    public int BattleEncounterCount
    {
        get { return battleEncounterCount; }
    }

    List<GameObject> enemy = new List<GameObject>();//ここに今いる敵を格納します
    public List<GameObject> Enemy
    {
        get { return enemy; }
    }

    const int maxEnemyNumber = 5;//敵は場に最大5体まで
     Vector3[] enemyPosition = new Vector3[5] {new Vector3(-2,2.5f,0), new Vector3(0, 2.5f, 0), new Vector3(2, 2.5f, 0), new Vector3(4, 2.5f, 0), new Vector3(6, 2.5f, 0) };


    public EnemyManagement()
    {
        battleEncounterCount = 0;
    }

    //敵オブジェクトを生成します
    GameObject Generation(GameObject prefab,Vector3 position)
    {
        GameObject ob = GameObject.Instantiate(prefab) as GameObject;
        ob.transform.localPosition = position;
        return ob;
    }

    //次のマップに移動した際に敵を新しく生成します
    private void GenerationEnemy()
    {
        //すべてのデータ消したから
         enemy.Clear();

        //ここですべて死んでいたらシーン移動します/知識不足でこんな場所に入れてます
        if (battleEncounterCount > 5)
            Application.LoadLevel("ResultScene");

        //生成,リストに追加
        switch (battleEncounterCount)//いったん適当に生成しています。
        {
            case 1:
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[2]));
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/EnemyBreak"), enemyPosition[3]));
                Debug.Log("エネミーの数"+enemy.Count);

                break;

            case 2:
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[1]));
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[3]));
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[4]));
                break;

            case 3:
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[2]));
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[0]));

                break;

            case 4:
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[0]));
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[4]));

                break;

            case 5:

                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[2]));
                enemy.Add(Generation((GameObject)Resources.Load("2DObject/kariEnemy"), enemyPosition[3]));
                break;


        }
    }

    //死んだ敵をリストから抹消します
    public void DeleteEnemy(GameObject deleteObject)
    {
        enemy.Remove(deleteObject);
        
    }

    //敵が全て死んでいたらあたらしい敵をを生成します
    public void AllDeadEnemy()
    {
        if (enemy.Count == 0)
        {
            battleEncounterCount++;
            GenerationEnemy();
        }
    }


    //++で増えた敵をリストに追加
    public void AddEnemy()
    {

    }

    //テキスト用に敵名一覧渡す
    public string[] EnemyArray()
    {
        string[] enemyString = new string[enemy.Count];
        for(int i=0;i<enemy.Count;i++)
        {
           Enemy e  = enemy[i].GetComponent<Enemy>();
            enemyString[i] = e.EnemyName;
        }
        return enemyString;
    }

}
