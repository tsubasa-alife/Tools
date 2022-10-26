#!/bin/sh
#2つのファイルの差分をとってファイルに書き出すシェルスクリプト

CMDNAME=`basename $0`
if [ $# -ne 3 ]; then
    echo "Usage: $CMDNAME filepath1 filepath2 outputname" 1>&2
    exit 1
else
    time=`date +%Y%m%d%H%M`
    filename="diff_$3_${time}.txt"
fi

diff $1 $2 > ${filename}

echo "Done! ${filename}"
    

