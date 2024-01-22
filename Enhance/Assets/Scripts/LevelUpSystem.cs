using System;
using System.Collections;
using System.Collections.Generic;

public class LevelUpSystem 
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private int _level;
    private int _experience;
    private int _requiredExpToNextLevel;

    private const float ADDITION_MULTIPLIER = 300f;
    private const float POWER_MULTIPLIER = 2f;
    private const float DIVISION_MULTIPLIER = 7f;

    public LevelUpSystem()
    {
        _level = 1;
        _experience = 0;
        _requiredExpToNextLevel = CalculateRequiredExp(_level);
    }

    public int GetLevel()
    {
        return _level;
    }

    public float GetExperiencePercentage()
    {
        return (float)_experience / _requiredExpToNextLevel;
    }

    public void AddExperience(int amount)
    {
        _experience += amount;

        if (_experience >= _requiredExpToNextLevel) 
        {
            LevelUp();
        }

        // notify subscribers about exp change
        if (OnExperienceChanged != null)
            OnExperienceChanged(this, EventArgs.Empty);
    }

    private void LevelUp()
    {
        _level++;
        _experience -= _requiredExpToNextLevel;
        _requiredExpToNextLevel = CalculateRequiredExp(_level);

        // notify subscribers about lvl change
        if (OnLevelChanged != null) 
            OnLevelChanged(this, EventArgs.Empty);
    }

    // equation for required exp calculation from https://oldschool.runescape.wiki/w/Experience
    private int CalculateRequiredExp(int level)
    {
        int requiredExp = 0;

        for (int i = 1; i <= level; i++) 
        {
            requiredExp += (int)Math.Floor(i + ADDITION_MULTIPLIER * Math.Pow(POWER_MULTIPLIER, i / DIVISION_MULTIPLIER));
        }

        return requiredExp / 4;
    }
}
