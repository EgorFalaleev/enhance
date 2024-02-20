using System;

namespace Enhance.Runtime
{
    public class LevelUpSystem
    {
        public event EventHandler OnExperienceChanged;
        public event EventHandler OnLevelChanged;

        public int Level { get; private set; }

        private int _experience;
        private int _requiredExpToNextLevel;

        private const float ADDITION_MULTIPLIER = 300f;
        private const float POWER_MULTIPLIER = 2f;
        private const float DIVISION_MULTIPLIER = 7f;

        public LevelUpSystem()
        {
            Level = 1;
            _experience = 0;
            _requiredExpToNextLevel = CalculateRequiredExp(Level);
        }

        public float GetExperiencePercentage()
        {
            return (float)_experience / _requiredExpToNextLevel;
        }

        public void AddExperience(int amount)
        {
            _experience += amount;

            while (_experience >= _requiredExpToNextLevel)
            {
                LevelUp();
            }

            // notify subscribers about exp change
            if (OnExperienceChanged != null)
                OnExperienceChanged(this, EventArgs.Empty);
        }

        // equation for required exp calculation from https://oldschool.runescape.wiki/w/Experience
        public int CalculateRequiredExp(int level)
        {
            int requiredExp = 0;

            for (int i = 1; i <= level; i++)
            {
                requiredExp +=
                    (int)Math.Floor(i + ADDITION_MULTIPLIER * Math.Pow(POWER_MULTIPLIER, i / DIVISION_MULTIPLIER));
            }

            return requiredExp / 4;
        }

        private void LevelUp()
        {
            Level++;
            _experience -= _requiredExpToNextLevel;
            _requiredExpToNextLevel = CalculateRequiredExp(Level);

            // notify subscribers about lvl change
            if (OnLevelChanged != null)
                OnLevelChanged(this, EventArgs.Empty);
        }
    }
}