using UnityEngine;
/// <summary>
/// カメラ関連のUtilsを集めたクラス
/// </summary>
public class CameraUtils
{
	/// <summary>
	/// カメラのアスペクト比を保つメソッド
	/// </summary>
	/// <param name="camera"></param>
	/// <param name="width"></param>
	/// <param name="height"></param>
	/// <param name="ppu"></param>
	public static void KeepAspect(Camera camera, float width, float height, float ppu)
	{
		camera.orthographic = true;
		float currentAspect = (float)Screen.height / (float)Screen.width;
		float baseAspect = height / width;
		float baseOrthographicSize = height / ppu / 2f;
		camera.orthographicSize = baseOrthographicSize;
		if(baseAspect > currentAspect)
		{
			float bgScale = height / (float)Screen.height;
			float camWidth = width / ((float)Screen.width * bgScale);
			camera.rect = new Rect((1f - camWidth) / 2f, 0f, camWidth, 1f);
		}
		else
		{
			float bgScale = width / (float)Screen.width;
			float camHeight = height / ((float)Screen.height * bgScale);
			camera.rect = new Rect(0f, (1f - camHeight) / 2f, 1f, camHeight);
		}

	}
	
}