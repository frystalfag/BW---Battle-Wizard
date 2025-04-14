using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public int curExp = 0;
    public int nextLvlExp = 100;

    public void AddXp(int xp)
    {
        curExp += xp;
        if (curExp >= nextLvlExp)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        curExp -= nextLvlExp;
        level++; 
        nextLvlExp = Mathf.RoundToInt(nextLvlExp * 1.5f);
        Debug.Log($"Level up! Now: {level}, next level at {nextLvlExp} XP."); 
    }
}