using JetBrains.Annotations;
using System.Collections.Generic;

[System.Serializable]
public class Skill
{
    public string name;
    public int level;
    public int maxLevel;    
    public List<SkillData> levels;
}

[System.Serializable]
public enum AttackPattern 
{
    SPLASH,
    MELEE,
    SHOTGUN,
    RANGE
}

[System.Serializable]
public enum Rarity
{
    COMMON,
    RARE,
    EPIC,
    LEGEND
}

// SkillData : ��ų ������
[System.Serializable]
public class SkillData
{
    public Rarity rarity;
    public AttackPattern pattern;
    public string objId;
    public float atk;
    public float coolTime;
    public float range;
    public float remainTime;
    public float knockback;
}
