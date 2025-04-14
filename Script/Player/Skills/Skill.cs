using UnityEngine;
using System.Collections.Generic;
public class Skill : MonoBehaviour
{
    public Transform Player;
    
    private float Damage;
    private float Speed;
    private float Range;
    private float LifeTime;
    private float Cooldown;
    
    private string SkillName;
    private Sprite SkillIcon;
    private string SkillDescription;
    
    private GameObject SkillEffect;
    private List<SkillBehaviors> Skills;
    
    private float WhenUsed;
    private bool CanUseSkill;
    void Start()
    {
    }

    public bool CanUse()
    {
        return Time.time >= WhenUsed+Cooldown;
    }
    
    void Update()
    {
        
    }

    public void UseSkill()
    {
        if (CanUse())
        {
            WhenUsed = Time.time;
            if (SkillEffect != null)
            {
                GameObject effect = Instantiate(SkillEffect, Player.position, Player.rotation);
                GameObject.Destroy(effect, LifeTime);
            }
        }    
    }

    public Skill(Sprite SkillIcon, string SkillName, string SkillDescription, GameObject SkillEffect, List<SkillBehaviors> Skills)
    {
        
    }

    public string getSkillName
    {
        get  { return SkillName;} 
    }
    
    public Skill(float damage, float range, float speed, float lifetime, float cooldown, string skillName)
    {
        this.Damage = damage;
        this.Range = range;
        this.Speed = speed;
        this.LifeTime = lifetime;
        this.Cooldown = cooldown;
        this.SkillName = skillName;
    }
    
    
}
