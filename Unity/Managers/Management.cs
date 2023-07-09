using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : SingletonMonoBehaviour<Management>
{
	protected override void doAwake()
	{
		Init();
	}

	private void Init()
	{
		Debug.Log("Management初期化完了");
	}
}