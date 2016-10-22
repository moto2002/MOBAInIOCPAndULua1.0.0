using UnityEngine;
using System.Collections;

public enum Anchor
{
    Top_Left = 1,
    Top_Center = 2,
    Top_Right = 3,
    Middle_Left = 4,
    Middle_Center = 5,
    Middle_Right = 6,
    Bottom_Left = 7,
    Bottom_Center = 8,
    Bottom_Right = 9
}

public class UIAnchor : MonoBehaviour
{
    [SerializeField]
    public Anchor anchor;
}
