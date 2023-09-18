using UnityEngine;

public class Attack : Poolable
{
    public SkillData currentSkill { get; private set; }
    
    private void OnEnable()
    {        
        Invoke("Release", currentSkill.remainTime);
    }
    
    public override void Release()
    {
        transform.parent = null;
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;        
        base.Release();
    }

    public void SetSkillData(Skill skill)
    {

    }
}
