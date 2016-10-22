//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph.Test
// FileName : ReverseListNode
//
// Created by : maxiao (398117200@qq.com) at 2016/10/12 14:09:09
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListNode
{
    public int m_nKey;
    public ListNode m_pNext;
}

public class ReverseListNode
{
    //可能会导致函数调用栈溢出，显式用栈基于循环实现的代码的鲁棒性要更好一些
    //功能测试:输入的链表有多个结点，输入的链表只有一个结点
    //特殊输入测试：输入的链表头结点指针NULL
    static void reversePrintList(ListNode pNode)
    {
        if (pNode != null)
        {
            if (pNode.m_pNext != null)
            {
                reversePrintList(pNode.m_pNext);
            }

            Console.WriteLine(pNode.m_nKey);
        }
    }

}
