//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph.Test
// FileName : AssemblyTest
//
// Created by : maxiao (398117200@qq.com) at 2016/10/12 0:07:34
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

[Serializable]
internal class A : MarshalByRefObject
{
    public static int Number;

    public void SetNumber(int value)
    {
        Number = value;
    }
}

[Serializable]
internal class B
{
    public static int Number;

    public void SetNumber(int value)
    {
        Number = value;
    }
}

public class AssemblyTest
{
    static void Test()
    {
        string assembly = Assembly.GetEntryAssembly().FullName;
        AppDomain domain = AppDomain.CreateDomain("NewDomain");

        A.Number = 10;
        string nameOfA = typeof (A).FullName;
        A a = domain.CreateInstanceAndUnwrap(assembly, nameOfA) as A;
        a.SetNumber(20);
        Console.WriteLine("Number on class A is {0}", A.Number);

        B.Number = 10;
        string nameOfB = typeof (B).FullName;
        B b = domain.CreateInstanceAndUnwrap(assembly, nameOfB) as B;
        b.SetNumber(20);
        Console.WriteLine("Number on class B is {0}", B.Number);

        //由于A继承自MarshalByRefObject,那么a实际上只是在默认的域中的一个代理实例，
        //它指向位于NewDomain域中的A的一个实例。当调用a的方法SetNumber时，是在NewDomain域中调用该方法
        //它将修改NewDomain域中静态变量A.Number的值并设为20
        //由于静态变量在每个应用程序域中都有一份独立的拷贝，修改NewDomain域中的静态变量A.Number对默认域中的静态变量A.Number没有任何影响
        //由于Console.WriteLine是在默认的应用程序域中输出A.Number,因此输出仍然是10

        //而B只是从Object继承而来的类型，它的实例穿越应用程序域的边界时，将会完整地复制实例。
        //因此在上述代码中，我们尽管试图在NewDomain域中生成B的实例，但会把实例b复制到默认的应用程序域。
        //此时调用方法b.SetNumber也是在缺省的应用程序域上进行，它将修改默认的域上的B.Number并设为20.
        //再在默认的域上调用Console.WriteLine时，它将输出20
    }
}