//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script
// FileName : MusicManager
//
// Created by : maxiao (398117200@qq.com) at 2016/6/24 8:16:55
//
// Function : 
//
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class MusicManager : MonoBehaviour,IEventListener
{


    private AudioSource audioSource = null;
    private Hashtable sounds = new Hashtable();

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 添加一个声音
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void AddSound(string key, AudioClip value)
    {
        if (sounds[key] != null && value != null)
            sounds.Add(key, value);
    }

    /// <summary>
    /// 获取一个声音
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    AudioClip Get(string key)
    {
        if (sounds[key] == null)
            return null;
        return sounds[key] as AudioClip;
    }

    public void LoadAudioClip(string path)
    {
        AudioClip ac = Get(path);
        if (ac == null)
        {
            ResourceMgr.Instance.LoadAsync(path,this,typeof(AudioClip),false);
        }
    }

    public int HandlePriority()
    {
        return 0;
    }

    public bool HandleEvent(int id, params object[] args)
    {
        switch (id)
        {
            case EventDef.LoadAssetFinished:
                AssetInfo aInfo = args[0] as AssetInfo;
                AudioClip clip = aInfo.asset as AudioClip;
                AddSound(aInfo.name, clip);

                return false;
        }

        return false;
    }

    /// <summary>
    /// 是否播放背景音乐，默认是1：播放
    /// </summary>
    /// <returns></returns>
    public bool CanPlayBackSound()
    {
        string key = "PlayBgSound";
        int i = PlayerPrefs.GetInt(key, 1);
        return i == 1;
    }

    /// <summary>
    /// 是否播放音效，默认是1：播放
    /// </summary>
    /// <returns></returns>
    public bool CanPlaySoundEffect()
    {
        string key = "PlaySoundEffect";
        int i = PlayerPrefs.GetInt(key, 1);
        return i == 1;
    }
    /// <summary>
    /// 在某点播放音频剪辑
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="position"></param>
    public void Play(AudioClip clip, Vector3 position)
    {
        if (!CanPlaySoundEffect()) return;
        AudioSource.PlayClipAtPoint(clip, position);
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="canPlay"></param>
    public void PlayBacksound(string name, bool canPlay)
    {
        if (audioSource.clip != null)
        {
            if (name.IndexOf(audioSource.clip.name) > -1)
            {
                if (!canPlay)
                {
                    audioSource.Stop();
                    audioSource.clip = null;
                    Util.ClearMemory();
                }
                return;
            }
        }
        if (canPlay)
        {
            audioSource.loop = true;
            if (sounds[name] != null)
            {
                audioSource.clip = sounds[name] as AudioClip;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
            audioSource.clip = null;
            Util.ClearMemory();
        }
    }
}
