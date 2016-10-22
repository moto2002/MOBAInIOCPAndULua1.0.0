using UnityEngine;
using System.Collections;

public class AssetBundleLoadTest : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    AssetBundle ab = AssetBundle.LoadFromFile(AppConst.StreamingAssetPath + '/' + AppConst.platformFolderName + '/' + "login_ui.assetbundle");

	    Debug.Log(ab.LoadAsset("Assets/prefabs/UI/LOGIN_UI/errorPanel.prefab").name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
