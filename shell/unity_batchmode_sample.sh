#!/bin/sh
#Unityをバッチモードで起動するシェルスクリプトの雛形
echo ${UNITY_PATH}
echo ${PROJECT_PATH}
${UNITY_PATH} \
-batchmode \
-quit \
-projectPath ${PROJECT_PATH} \
-logFile ${PROJECT_PATH}'/Unitylog.txt' \
-executeMethod Hoge.Hoge

