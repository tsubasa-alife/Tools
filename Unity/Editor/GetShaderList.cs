using UnityEditor;
using UnityEngine;

/// <summary>
/// 現在のシーンで使用されているシェーダーの一覧を取得するエディタ拡張
/// </summary>
public class GetShaderList : EditorWindow
{
	[MenuItem("Tools/GetShaderList")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(GetShaderList));
	}

	void OnGUI()
	{
		// 現在のシーンに存在するすべてのマテリアルを取得
		var materials = Resources.FindObjectsOfTypeAll<Material>();
		// シェーダー格納用
		var shaders = new HashSet<Shader>();
		// シーン内のすべてのマテリアルからシェーダーを取得
		foreach (var material in materials)
		{
			if (material.shader != null)
			{
				shaders.Add(material.shader);
			}
		}

		// シェーダーの一覧を表示
		foreach (var shader in shaders)
		{
			EditorGUILayout.LabelField(shader.name);
		}
	}
}