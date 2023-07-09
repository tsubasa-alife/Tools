using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
	[SerializeField] private GameObject soundPlayer;
	private AudioSource bgmSource = null;
	private AudioSource seSource = null;

	public AudioSource BgmSource
	{
		get
		{
			return bgmSource;
		}
	}

	public AudioSource SeSource
	{
		get
		{
			return seSource;
		}
	}

	protected override void doAwake()
	{
		Init();
	}

	/// <summary>
	/// 初期化用メソッド
	/// </summary>
	private void Init()
	{
		if(bgmSource == null)
		{
			bgmSource = soundPlayer.GetComponents<AudioSource>()[0];
		}

		if(seSource == null)
		{
			seSource = soundPlayer.GetComponents<AudioSource>()[1];
		}

		Debug.Log("AudioManager 初期化完了");
	}

	public void PlayBgm(string bgmName)
	{
		bgmSource.clip = Resources.Load<AudioClip>("Audio/BGM/" + bgmName);
		bgmSource.loop = true;
		bgmSource.Play();
	}

	public void StopBgm()
	{
		bgmSource.Stop();
	}

	public void PlaySE(string seName)
	{
		AudioClip clip = Resources.Load<AudioClip>("Audio/SE/" + seName);
		seSource.PlayOneShot(clip);
	}
	
	public void StopSE()
	{
		seSource.Stop();
	}
}