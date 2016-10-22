//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph.Test
// FileName : FibonacciTest
//
// Created by : maxiao (398117200@qq.com) at 2016/10/13 0:14:00
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FibonacciTest
{
    //青蛙跳台阶，一次可以跳1级也可以跳二级，求跳法一共多少种（就是菲波那切数列）
    long Fibonacci(uint n)
    {
        int[] result = new int[2] {0, 1};
        if (n < 2)
            return result[n];

        long fibNMinusOne = 1;
        long fibNMinusTwo = 0;
        long fibN = 0;
        for (int i = 2; i <= n; ++i)
        {
            fibN = fibNMinusOne + fibNMinusTwo;

            fibNMinusTwo = fibNMinusOne;
            fibNMinusOne = fibN;
        }

        return fibN;
    }


}
