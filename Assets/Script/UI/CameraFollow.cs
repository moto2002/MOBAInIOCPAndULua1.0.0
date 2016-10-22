using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    private Transform focusTransform;
    private Vector3 followOffset = GameData.cameraFollowOffset;


    // Update is called once per frame
    void Update()
    {
        if (focusTransform != null)
        {
            transform.position = focusTransform.position + followOffset;
        }
    }

    public Transform FocusTransform
    {
        get { return focusTransform; }
        set { focusTransform = value; }
    }

    public Vector3 FollowOffset
    {
        get { return followOffset; }
        set { followOffset = value; }
    }
}
