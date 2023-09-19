using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    private SkillData skillData;
    private float timer = 0f;

    public void Init(int index)
    {
        // 스킬 슬롯의 갯수가 만든 스킬보다 많으면 무시
        if(GameManager.Instance.skillList.Count <= index)
        {
            return;
        }

        skillData = GameManager.Instance.skillList[index].levels[GameManager.Instance.skillList[index].level-1];
    }

    private void Update()
    {
        if(skillData == null)
        {
            return;
        }

        timer += Time.deltaTime;
        if(timer >= skillData.coolTime)
        {
            timer = 0f;
            Spawn();
        }        
    }

    public void Spawn() 
    {
        GameObject attackObject = PoolManager.Instance.Spawn(skillData.objId);
        Attack attack = attackObject.GetComponent<Attack>();
        attack.SetAttack(skillData);        

        attackObject.transform.SetParent(transform, false);
        attackObject.transform.localPosition = Vector3.zero;
        attackObject.transform.localScale = Vector3.one;
    }
}
