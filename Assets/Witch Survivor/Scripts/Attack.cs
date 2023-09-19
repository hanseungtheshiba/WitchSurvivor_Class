using UnityEngine;

public class Attack : Poolable
{
    public SkillData currentSkill { get; private set; }
        
    public override void Release()
    {
        transform.parent = null;
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;        
        base.Release();
    }

    public void SetAttack(SkillData skillData)
    {
        currentSkill = skillData;
        Invoke("Release", currentSkill.remainTime);
    }
}
