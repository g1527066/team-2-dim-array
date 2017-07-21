using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;


    //技をテトリス方式でやります
    //効率割るそうですが直せなかったですすみません、、、、


    public class TechniqueManagement
    {
        public struct s_Technique
        {
            public string techniqueName;//技名前!!入力するやつ
            public string techniqueDescription;//技説明
            public s_Technique(string name, string description)
            {
                techniqueName = name;
                techniqueDescription = description;
            }

        }

    s_Technique plus = new s_Technique("HP+=10", "体力に10を足す");//+=は変数名に入れれないので
    s_Technique comment = new s_Technique("//Comment", "次に受ける攻撃をコメントアウト");//　//入んないです
    s_Technique loop = new s_Technique("While(true)", "無限ループで敵に負担をかけ、遅くする");//whileは変数名にできないので
    s_Technique enemyUsing = new s_Technique("using enemy", "敵を解析することにより、防御力を下げる");//using先だとエラーなので
    s_Technique small = new s_Technique("enemy-=10", "敵のHPから10引く");
    s_Technique division = new s_Technique("enemy/=2", "敵のHPを半分に割る");
    s_Technique constant = new s_Technique("const int", "敵に定数ダメージを与える");
    s_Technique pure = new s_Technique("true", "聖なる攻撃でダメージを与える");
    s_Technique fake = new s_Technique("false", "邪悪な攻撃でダメージを与える");
    s_Technique release = new s_Technique("public", "全て公開する");

    //s_Technique plus = new s_Technique("hp10", "体力に10を足す");//+=は変数名に入れれないので
    //s_Technique comment = new s_Technique("//comment", "次に受ける攻撃をコメントアウト");//　//入んないです
    //s_Technique loop = new s_Technique("whiletrue", "無限ループで敵に負担をかけ、遅くする");//whileは変数名にできないので
    //s_Technique enemyUsing = new s_Technique("usingenemy", "敵を解析することにより、防御力を下げる");//using先だとエラーなので
    //s_Technique small = new s_Technique("enemy10", "敵のHPから10引く");
    //s_Technique division = new s_Technique("enemy2", "敵のHPを半分に割る");
    //s_Technique constant = new s_Technique("constint", "敵に定数ダメージを与える");
    //s_Technique pure = new s_Technique("true", "聖なる攻撃でダメージを与える");
    //s_Technique fake = new s_Technique("false", "邪悪な攻撃でダメージを与える");
    //s_Technique release = new s_Technique("public", "全て公開する");

    const int techniquNumber = 10;

        // List<int> techniqueArray = new List<int>();
        List<s_Technique> techniqueArray = new List<s_Technique>();

        public TechniqueManagement()
        {
            UnityEngine.Random.seed = System.Environment.TickCount;
        RandomCreate();
        }

        //配列をシャッフルしなおす
        private void RandomCreate()
        {
            techniqueArray.Clear();
            int[] hairetu = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int rand = 0, a, b;
            for (int i = hairetu.Length; i > 1; i--)//10回シャッフルする
            {
                a = i - 1;
                rand = UnityEngine.Random.Range(0, techniquNumber - 1);
                b = hairetu[a];
                hairetu[a] = hairetu[rand];
                hairetu[rand] = b;
            }
            for (int i = 0; i < hairetu.Length; i++)
            {
                SetTechnique(hairetu[i]);
                //  techniqueArray.Add(hairetu[i]);
            }
        }

        //番号にあわせてセットします
        //宣言した順番で行きます
        private void SetTechnique(int number)
        {
            switch (number)
            {
                case 0:
                    techniqueArray.Add(plus);
                    break;
                case 1:
                    techniqueArray.Add(comment);
                    break;
                case 2:
                    techniqueArray.Add(loop);
                    break;
                case 3:
                    techniqueArray.Add(enemyUsing);
                    break;
                case 4:
                    techniqueArray.Add(small);
                    break;
                case 5:
                    techniqueArray.Add(division);
                    break;
                case 6:
                    techniqueArray.Add(constant);
                    break;
                case 7:
                    techniqueArray.Add(pure);
                    break;
                case 8:
                    techniqueArray.Add(fake);
                    break;
                case 9:
                    techniqueArray.Add(release);
                    break;
                default:
                    Debug.Log("術セット時にエラーが起きました");
                    break;
            }
        }


        //最初の三個の配列を返す//２以下のバージョン書く
        public string[] techniquString
        {
            get
            {
                string[] hairetu = new string[] { techniqueArray[0].techniqueName, techniqueArray[1].techniqueName, techniqueArray[2].techniqueName };
                return hairetu;
            }
        }


        //選ばれている技の説明を返す
        public string SelectTechniqueDescription(int number)
        {
            return techniqueArray[number].techniqueDescription;
        }

    //選ばれている技をかえす
    public string SelectTechniqueName(int number)
    {
        return techniqueArray[number].techniqueName;
    }

    //使い終わったものは削除
    public void DeleteTechnique(int number)
    {
        techniqueArray.RemoveAt(number);
    }


    }
