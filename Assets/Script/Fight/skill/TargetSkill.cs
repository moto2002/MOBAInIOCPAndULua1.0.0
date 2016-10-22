using UnityEngine;
using System.Collections;
using OneByOne;

public class TargetSkill : BaseSkill
{

    GameObject target;
    int skill;
    int atkId;


    public void Init(GameObject target, int skill, int atkId)
    {
        this.target = target;
        this.skill = skill;
        this.atkId = atkId;
    }

    public override void ReleaseSkill()
    {
        StartCoroutine(skillToTarget());
    }

    IEnumerator skillToTarget()
    {
        while (true)
        {
            if (target)
            {
                transform.position = Vector3.Lerp(transform.position, target.transform.position + Vector3.up, 0.5f);
                if (Vector3.Distance(transform.position, target.transform.position + Vector3.up) < 0.1f)
                {
                    //发送攻击 切销毁自身
                    DamageDTO dto = new DamageDTO();
                    dto.id = atkId;
                    dto.skill = skill;
                    dto.targetDamage = new int[][] { new int[] { target.GetComponent<FightUnit>().getData().id } };
                    this.WriteMessage(Protocol.TYPE_FIGHT, -1, FightProtocol.DAMAGE_CREQ, dto);
                    Destroy(gameObject);
                    StopCoroutine(skillToTarget());
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
