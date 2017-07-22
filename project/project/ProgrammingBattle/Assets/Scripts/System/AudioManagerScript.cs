using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

//BGM、SEの設定をするスクリプト
//Unity始めたてのころに個人ブログを参考に組んだやつ（理解は半分ぐらい...）
public class AudioManagerScript : SingletonMonoBehaviour<AudioManagerScript>
{
    public List<AudioClip> BGMList;
    public List<AudioClip> SEList;
    public int MaxSE = 10;

    private AudioSource bgmSource = null;
    private List<AudioSource> seSources = null;
    private Dictionary<string, AudioClip> bgmDict = null;
    private Dictionary<string, AudioClip> seDict = null;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        //リスナー作製
        if (FindObjectsOfType(typeof(AudioListener)).All(o => !((AudioListener)o).enabled))
        {
            this.gameObject.AddComponent<AudioListener>();
        }

        //オーディオソース作製
        this.bgmSource = this.gameObject.AddComponent<AudioSource>();
        this.seSources = new List<AudioSource>();

        //クリップ作成
        this.bgmDict = new Dictionary<string, AudioClip>();
        this.seDict = new Dictionary<string, AudioClip>();

        //ラムダ式記述らしい、ラムダ式記述とは？
        Action<Dictionary<string, AudioClip>, AudioClip> addClipDict = (dict, c) =>
        {
            //たぶん追加した音ファイルの登録をしてるんだと思う
            if (!dict.ContainsKey(c.name))
            {
                dict.Add(c.name, c);
            }
        };

        this.BGMList.ForEach(bgm => addClipDict(this.bgmDict, bgm));
        this.SEList.ForEach(se => addClipDict(this.seDict, se));
    }

    //以下、外から呼び出して使うメソッドの方々

    public void PlayBGM(string bgmName)
    {
        if (!this.bgmDict.ContainsKey(bgmName)) throw new ArgumentException(bgmName + " not found", "bgmName");
        if (this.bgmSource.clip == this.bgmDict[bgmName]) return;
        this.bgmSource.Stop();
        this.bgmSource.clip = this.bgmDict[bgmName];
        this.bgmSource.Play();
        this.bgmSource.loop = true;
    }

    public void StopBGM()
    {
        this.bgmSource.Stop();
        this.bgmSource.clip = null;
    }

    public void PlaySE(string seName)
    {
        if (!this.seDict.ContainsKey(seName)) throw new ArgumentException(seName + " not found", "seName");

        AudioSource source = this.seSources.FirstOrDefault(s => !s.isPlaying);
        if (source == null)
        {
            if (this.seSources.Count >= this.MaxSE)
            {
                Debug.Log("SE AudioSource is full");
                return;
            }

            source = this.gameObject.AddComponent<AudioSource>();
            this.seSources.Add(source);
        }

        source.clip = this.seDict[seName];
        source.Play();
    }

    public void StopSE()
    {
        this.seSources.ForEach(s => s.Stop());
    }
}