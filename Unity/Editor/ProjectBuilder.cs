using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

//コマンドラインビルドを行う際に実行するためのエディタ拡張(Jenkinsでのビルド時など)

public class ProjectBuilder
{
    [MenuItem("Tools/Build/CustomBuild)]
    public static void CustomBuild()
    {
        Build();
    }

    private static void Build()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        
        // ビルド出力先
        buildPlayerOptions.locationPathName = "Build/hogehoge.apk";
        // 開発ビルドかどうか
        buildPlayerOptions.options = BuildOptions.Development;
        // ビルドするプラットフォームの指定
        buildPlayerOptions.target = BuildTarget.Android;

        // ビルドの実行と結果通知
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded");
        }
        else if (summary.result == BuildResult.Failed)
        {
            Debug.LogError("Build Failed");
        }
    }
}
