//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph.Test
// FileName : RebuildBinaryTree
//
// Created by : maxiao (398117200@qq.com) at 2016/10/12 16:11:16
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BinaryTreeNode
{
    public int m_nValue;
    public BinaryTreeNode m_left;
    public BinaryTreeNode m_right;
}

public class RebuildBinaryTree
{

    //测试：普通二叉树（完全二叉树、不完全二叉树）
    //特殊二叉树（所有节点都没有右/左子节点的二叉树），只有一个节点的二叉树
    //特殊输入测试(二叉树的根节点指针为NULL，输入序列不正确)
    BinaryTreeNode Construct(int[] preOrder, int[] inOrder)
    {
        if (preOrder == null || inOrder == null || preOrder.Length != inOrder.Length || preOrder.Length == 0 ||
            inOrder.Length == 0)
        {
            return null;
        }

        return ConstructCore(preOrder, inOrder, 0, preOrder.Length -1, 0, inOrder.Length - 1);
    }

    BinaryTreeNode ConstructCore(int[] preOrder, int[] inOrder, int startPreOrder, int endPreOrder, int startInOrder, int endInOrder)
    {
        int rootValue = preOrder[0];
        BinaryTreeNode root = new BinaryTreeNode();
        root.m_nValue = rootValue;
        root.m_left = null;
        root.m_right = null;

        if (startPreOrder == endPreOrder)
        {
            if (startInOrder == endInOrder)
            {
                return root;
            }
            else
            {
                throw new Exception("Invalid input");
            }
        }

        int rootInOrder = startInOrder;
        while (rootInOrder <= endInOrder && inOrder[rootInOrder] != rootValue)
        {
            ++rootInOrder;
        }

        int leftLength = rootInOrder - startInOrder;
        int leftPreOrderEnd = startPreOrder + leftLength;
        if (leftLength > 0)
        {
            root.m_left = ConstructCore(preOrder, inOrder, startPreOrder + 1, leftPreOrderEnd, startInOrder,
                rootInOrder - 1);
        }
        if (leftLength < endPreOrder - startPreOrder)
        {
            root.m_right = ConstructCore(preOrder, inOrder, leftPreOrderEnd + 1, endPreOrder, rootInOrder + 1,
                endInOrder);
        }

        return root;
    }
}