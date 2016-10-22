using System;
using UnityEngine;
using System.Collections;
using System.Net;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownloadScreen : EventNode
{
    [SerializeField]
    private Scrollbar downloadScrollBar;
    [SerializeField]
    private Text hintText;
    [SerializeField]
    private InputField DownloadServerIP;
    [SerializeField]
    private InputField DownloadServerPort;
    [SerializeField]
    private InputField GameServerIP;
    [SerializeField]
    private InputField GameServerPort;
    [SerializeField]
    private Button updateBtn;
    [SerializeField]
    private Button startBtn;
    [SerializeField]
    private GameObject downloadPanel;
    [SerializeField]
    private GameObject startGamePanel;

    private string hintStr;
    private float percent;
    void Start()
    {
        updateBtn.onClick.AddListener(OnUpdatePressed);
        startBtn.onClick.AddListener(OnStartPressed);
    }

    public void ScreenOnDownloadCompleted()
    {
        downloadPanel.SetActive(false);
        startGamePanel.SetActive(true);
    }

    void OnUpdatePressed()
    {
        IPAddress ip;
        if (IPAddress.TryParse(DownloadServerIP.text, out ip))
        {

                if (string.IsNullOrEmpty(DownloadServerPort.text))
                {
                    ErrorManager.Instance.AddNoLuaError(new NoLuaErroModel("更新服务的端口不能为空"));
                }
                else
                {
                    int downloadPort = Convert.ToInt32(DownloadServerPort.text);
                    if (NetWorkScript.Instance.ConnectTest(DownloadServerIP.text, downloadPort))
                    {
                        AppConst.DOWNLOAD_SERVER_IP = DownloadServerIP.text;
                        AppConst.DOWNLOAD_SERVER_PORT = downloadPort;
                        Debug.Log(AppConst.DOWNLOAD_SERVER_IP + ':' + AppConst.DOWNLOAD_SERVER_PORT);
                        transform.GetComponent<ResDownloader>().StartUpdate();
                    }
                    else
                    {
                        ErrorManager.Instance.AddNoLuaError(new NoLuaErroModel("连接不到:" + DownloadServerIP.text + "的端口:" + downloadPort));
                    }
                }

        }
        else
        {
            ErrorManager.Instance.AddNoLuaError(new NoLuaErroModel("输入的更新服务器IP不合法"));
        }
    }

    void OnStartPressed()
    {
        IPAddress ip;
        if (IPAddress.TryParse(GameServerIP.text, out ip))
        {
            if (string.IsNullOrEmpty(GameServerPort.text))
            {
                ErrorManager.Instance.AddNoLuaError(new NoLuaErroModel("游戏服务的端口不能为空"));
            }
            else
            {
                int gameServerPort = Convert.ToInt32(GameServerPort.text);
                if (NetWorkScript.Instance.ConnectTest(GameServerIP.text, gameServerPort))
                {
                    AppConst.GAME_SERVER_IP = GameServerIP.text;
                    AppConst.GAME_SERVER_PORT = gameServerPort;
                    NetWorkScript.Instance.Connect(GameServerIP.text, gameServerPort);
                    NetWorkScript.Instance.BeginReceive();
                    SceneManager.LoadScene(1);
                }
                else
                {
                    ErrorManager.Instance.AddNoLuaError(new NoLuaErroModel("连接不到游戏服务器:" + GameServerIP.text + "的端口:" + gameServerPort));
                }
            }

        }
        else
        {
            ErrorManager.Instance.AddNoLuaError(new NoLuaErroModel("输入的游戏服务器IP不合法"));
        }
    }

    public void SetProgressBarAndText(string text, int percentage)
    {
        hintStr = text + "  " + percentage + "%";
        percent = percentage/100f;
    }

    void Update()
    {
        hintText.text = hintStr;
        downloadScrollBar.size = percent;
    }
}
