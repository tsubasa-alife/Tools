using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using Unity.EditorCoroutines.Editor;

/// <summary>
/// Webから画像をダウンロードし保存するエディタ拡張
/// </summary>
public class DownLoadImage : EditorWindow
{
    private string URI = "";
    [MenuItem("Tools/DownloadImage")]
    public static void DownLoad()
    {
        GetWindow<DownLoadImage>();
    }

    private void OnGUI()
    {
        // URIをGUI上で入力
        URI = EditorGUILayout.TextField("URI",URI);
        if (GUILayout.Button("ダウンロード"))
        {
            Debug.Log("ダウンロード開始" + "( " + URI + " )");
            // ダウンロードコルーチンの開始
            EditorCoroutineUtility.StartCoroutine(DownloadRequest(), this);
        }
    }

    private IEnumerator DownloadRequest()
    {
        // ダウンロードしたファイルはResources配下のDownLoadフォルダに保存する
        string folderPath = Path.Combine(Application.dataPath,"Resources/Download");
        // フォルダがなければ作成する
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string fileName = Path.GetFileName(URI);
        string savePath = Path.Combine(folderPath,fileName);

        // ダウンロード用のリクエストを作成する
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(URI);
        request.downloadHandler = new DownloadHandlerFile(savePath);
        request.disposeUploadHandlerOnDispose = false;

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log("ダウンロード終了");
        }
    }
}
