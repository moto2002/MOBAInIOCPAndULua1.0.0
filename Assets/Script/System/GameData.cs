using OneByOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class GameData
{
    public static UserDTO user = null;

    public static int posUpdateRate = 8;

    public static Vector3 teamOneStart = new Vector3(-44.9f, 0f, -48f);

    public static Vector3 teamTwoStart = new Vector3(53.8f, 0f, 51.7f);

    public static Vector3 cameraFollowOffset = new Vector3(0f, 22f, -13f);

    public static float mapToMiniMapScale = 0.01f;
}

