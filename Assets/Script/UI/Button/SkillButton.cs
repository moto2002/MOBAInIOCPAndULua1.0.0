using System;
using UnityEngine;
using System.Collections;
using OneByOne;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 技能按钮
/// </summary>
public class SkillButton : MonoBehaviour
{
    /// <summary>
    /// 技能的属性
    /// </summary>
    private FightSkill skill;
    /// <summary>
    /// 技能图标
    /// </summary>
    [SerializeField]
    public Image skillImg; 
    /// <summary>
    /// 技能冷却蒙层
    /// </summary>
    [SerializeField]
    public Image cdMask;
    /// <summary>
    /// 技能冷却时间提示文字
    /// </summary>
    [SerializeField]
    public Text cdText;
    /// <summary>
    /// 技能按钮
    /// </summary>
    [SerializeField]
    public Button skillBtn;
    /// <summary>
    /// 技能升级按钮
    /// </summary>
    [SerializeField]
    public Button skillLevelUpBtn;
    /// <summary>
    /// 技能升级按钮的GameObject
    /// </summary>
    [SerializeField]
    public GameObject goSkillLevelUp;
    /// <summary>
    /// 技能按钮发光
    /// </summary>
    [SerializeField]
    public GameObject illution;
    /// <summary>
    /// 本技能的冷却时间长度
    /// </summary>
    private int cdSecondCount = 5;

	// Use this for initialization
	void Start ()
	{
	    cdMask.gameObject.SetActive(false);
	    cdText.gameObject.SetActive(false);
	    skillBtn.onClick.AddListener(ColdDown);
	    skillLevelUpBtn.onClick.AddListener(HideSkillLevelUpBtn);
        goSkillLevelUp.SetActive(false);
	}
    /// <summary>
    /// 显示技能升级按钮
    /// </summary>
    void ShowSkillLevelUpBtn()
    {
        goSkillLevelUp.SetActive(true);
    }
    /// <summary>
    /// 隐藏技能升级按钮
    /// </summary>
    void HideSkillLevelUpBtn()
    {
        goSkillLevelUp.SetActive(false);
    }
    /// <summary>
    /// 技能冷却
    /// </summary>
    public void ColdDown()
    {
        StartCoroutine("hintColdDown");
    }

    IEnumerator hintColdDown()
    {
        ForbidSkillBtn();
        cdMask.gameObject.SetActive(true);
        cdText.gameObject.SetActive(true);
        float remainTime = cdSecondCount;
        while (remainTime > 0)
        {
            remainTime = remainTime - Time.deltaTime;
            cdMask.fillAmount = remainTime/cdSecondCount;
            cdText.text = ((int) remainTime).ToString();

            yield return new WaitForEndOfFrame();
        }
        cdMask.gameObject.SetActive(false);
        cdText.gameObject.SetActive(false);
        ActiveSkillBtn();
        StopCoroutine("hintColdDown");
    }
    /// <summary>
    /// 设置技能的Sprite
    /// </summary>
    /// <param name="sp"></param>
    public void SetBtnSprite(Sprite sp)
    {
        skillImg.sprite = sp;
    }
    /// <summary>
    /// 设置skill
    /// </summary>
    /// <param name="skill"></param>
    public void SetSkill(FightSkill skill)
    {
        this.skill = skill;
        skillImg.sprite = ResourceMgr.Instance.GetSprite("skill_icon_" + skill.id);
        cdSecondCount = skill.time;
    }

    /// <summary>
    /// 技能冷却时间属性
    /// </summary>
    public int CdSecondCount
    {
        get { return cdSecondCount; }
        set { cdSecondCount = value; }
    }


    public void ForbidSkillBtn()
    {
        skillBtn.interactable = false;
        illution.SetActive(false);
    }

    public void ActiveSkillBtn()
    {
        skillBtn.interactable = true;
        illution.SetActive(true);
    }
}
