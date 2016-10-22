using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitInfoView : MonoBehaviour
{
    [SerializeField]
    private RectTransform hpBar;
    [SerializeField]
    private Text textName;

    private float xOffset = 0f;
    private float yOffset = 2f;

    public void SetValue(float value)
    {
        hpBar.GetComponent<Scrollbar>().size = Mathf.Clamp01(value);
    }

    public void SetFriendColor()
    {
        hpBar.GetComponent<Scrollbar>().targetGraphic.color = Color.green;
        textName.color = Color.white;
    }

    public void SetEnemyColor()
    {
        hpBar.GetComponent<Scrollbar>().targetGraphic.color = Color.red;
        textName.color = Color.red;
    }

    public void SetName(string name)
    {
        textName.text = name;
    }

    public void SetHpBarColor(Color col)
    {
        hpBar.GetComponent<Scrollbar>().targetGraphic.color = col;
    }

    public void SetInfoViewPos(Vector2 pos)
    {
        transform.position = pos + new Vector2(xOffset, yOffset);
    }
}
