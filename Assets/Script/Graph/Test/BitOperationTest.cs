//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph.Test
// FileName : BitOperationTest
//
// Created by : maxiao (398117200@qq.com) at 2016/10/13 1:15:22
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BitOperationTest
{
    int NumberOf1(int n)
    {
        int count = 0;

        while(n != 0)
        {
            ++count;
            n = (n - 1) & n;
        }

        return count;
    }
}
