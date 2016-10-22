using UnityEngine;
using System.Collections;
using OneByOne;
using UnityEngine.UI;
/// <summary>
/// 技能提示
/// </summary>
public class SkillTip : MonoBehaviour {
    public Text skillName;
    public Text info;
    public Image icon;

    public void Active(FightSkill skill,Vector3 position)
    {

        icon.sprite = ResourceMgr.Instance.GetSprite("skill_icon_" + skill.id);
        skillName.text = skill.name;
        info.text = skill.info;
        gameObject.transform.localPosition = position;
        gameObject.SetActive(true);
    }

    public void Disactive()
    {
        gameObject.SetActive(false);
    }
}
