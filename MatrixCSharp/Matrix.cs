using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RandomFunc.Distribution;

namespace Matrix{
    public class Calculation
    {
        //行列積
        public static float[,] dot(float[,] a,float[,] b){
            float [,] result = new float[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        //アダマール積
        public static float[,] mul(float[,] a,float[,] b){
            float [,] result = new float[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] * b[i, j];   
                }
            }
            return result;
        }

        //転置
        public static float[,] transpose(float[,] a){
            float[,] result = new float[a.GetLength(1),a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    result[i, j] = a[j, i];
                }
            }
            return result;
        }

        //1で初期化
        public static void One(ref float[,] a){
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = 1.0f;
                }
            }
        }

        //正規分布で初期化
        public static void Rand(ref float[,] a){
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = NormalDist(0f,1f);
                }
            }
        }

        //0クリア
        public static void Zero(ref float[,] a){
            Array.Clear(a,0,a.Length);
        }

        //行列の表示
        public static void ShowMatrix(float[,] a){
            int i = 0;
            string str = "\n";

            foreach(var element in a){
                i += 1;
                str += element;
                if((i % a.GetLength(1)) == 0){
                    str += "\n";
                }else{
                    str += " ";
                }
            }
            Debug.Log(str);
        }
    }

}

