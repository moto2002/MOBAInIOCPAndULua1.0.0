using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ErrorManager : MonoBehaviour
{
    private static GameObject errorPanel = null;
    private static Text errorText = null;
    private static Button ensureBtn = null;

    #region 单例Instance

    private static ErrorManager _instance;
    private static object syncObj = new object();

    public static ErrorManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    _instance = GameObject.FindObjectOfType<ErrorManager>();
                    if (_instance == null)
                    {
                        GameObject container = GameObject.Find("SingletonContainer");
                        if (container == null)
                        {
                            container = new GameObject("SingletonContainer");
                        }
                        _instance = container.AddComponent<ErrorManager>();
                    }

                }
            }
            return _instance;
        }
    }

    #endregion
    private List<IError> errors = new List<IError>();
    private bool currentErrorHandled = true;

    void Awake()
    {
        errorPanel = GameObject.Find("errorPanel");
        GameObject text = TransformFinder.FindChild(errorPanel, "txt_errorInfo");
        if (text != null)
        {
            errorText = text.GetComponent<Text>();
        }
        GameObject btn = TransformFinder.FindChild(errorPanel, "btn_errorEnsure");
        if (btn != null)
        {
            ensureBtn = btn.GetComponent<Button>();
        }
        if (errorPanel != null)
        {
            errorPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (currentErrorHandled && errors.Count > 0)
        {
            IError model = errors[0];
            errors.RemoveAt(0);
            currentErrorHandled = false;
            model.CallFunction();
        }
    }

    public void AddError(ErrorModel model)
    {
        errors.Add(model);
    }

    public void AddNoLuaError(NoLuaErroModel model)
    {
        errors.Add(model);
    }

    public void CurrentErrorHandled()
    {
        HideErrorPanel();
        currentErrorHandled = true;
    }

    public void ShowErrorPanel()
    {
        if (errorPanel != null)
        {
            errorPanel.SetActive(true);
        }
    }

    public void HideErrorPanel()
    {
        if (errorPanel != null)
        {
            errorPanel.SetActive(false);
        }
    }

    public void SetErrorPanelText(string s)
    {
        if (errorText != null)
        {
            errorText.text = s;
        }
    }

    public void SetErrorPanel(GameObject panel)
    {
        errorPanel = panel;
    }

    public void SetEnsureBtnFunction(Action<object[]> action = null, object[] args = null)
    {
        ensureBtn.onClick.RemoveAllListeners();
        ensureBtn.onClick.AddListener(delegate
        {
            if (action != null)
            {
                action(args);
            }
            CurrentErrorHandled();
        });
    }
}
