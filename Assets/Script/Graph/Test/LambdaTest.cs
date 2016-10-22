//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph
// FileName : LamdaTest
//
// Created by : maxiao (398117200@qq.com) at 2016/10/11 15:21:09
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}


public class LambdaTest
{
    public static List<Person> PersonList()
    {
        List<Person> persons = new List<Person>();
        for (int i = 0; i < 7; i++)
        {
            Person p = new Person() {Name = i+"儿子", Age = 8 - i};
            persons.Add(p);
        }

        return persons;
    }

    static void Call()
    {
        List<Person> persons = PersonList();
        persons = persons.Where(p => p.Age > 6).ToList();
        Person per = persons.SingleOrDefault(c => c.Age == 1);
        persons = persons.Where(d => d.Name.Contains("儿子")).ToList();
    }

    delegate int GuangChaoShi(int a, int b);

    static void Call2()
    {
        GuangChaoShi gw1 = (p, z) => z - (p + 10);
    }

    static void LamdaExpressionTree()
    {
        ParameterExpression a = Expression.Parameter(typeof (int), "i");
        ParameterExpression b = Expression.Parameter(typeof (int), "j");
        BinaryExpression be = Expression.Multiply(a, b);
        ParameterExpression c = Expression.Parameter(typeof (int), "w");
        ParameterExpression d = Expression.Parameter(typeof (int), "x");
        BinaryExpression be1 = Expression.Multiply(c, d);
        BinaryExpression su = Expression.Add(be, be1);
        Expression<Func<int, int, int, int, int>> lambda = Expression.Lambda<Func<int, int, int, int, int>>(su, a, b, c,
            d);

        Func<int, int, int, int, int> f = lambda.Compile();
    }
}
