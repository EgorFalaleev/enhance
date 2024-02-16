using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Enhance.Runtime.UI
{
    public class LevelUpUIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private Image _experienceBarImg;

        private LevelUpSystem _levelUpSystem;

        public void SetLevelUpSystem(LevelUpSystem levelUpSystem)
        {
            _levelUpSystem = levelUpSystem;

            // set ui elements
            SetLevelText(levelUpSystem.GetLevel());
            SetExperienceBarFill(levelUpSystem.GetExperiencePercentage());

            // subscribe to exp and lvl change
            levelUpSystem.OnLevelChanged += LevelUpSystem_OnLevelChanged;
            levelUpSystem.OnExperienceChanged += LevelUpSystem_OnExperienceChanged;
        }

        private void LevelUpSystem_OnExperienceChanged(object sender, System.EventArgs e)
        {
            SetExperienceBarFill(_levelUpSystem.GetExperiencePercentage());
        }

        private void LevelUpSystem_OnLevelChanged(object sender, System.EventArgs e)
        {
            SetLevelText(_levelUpSystem.GetLevel());
        }

        private void SetExperienceBarFill(float experiencePercentage)
        {
            _experienceBarImg.fillAmount = experiencePercentage;
        }

        private void SetLevelText(int level)
        {
            _levelText.text = level.ToString();
        }
    }
}
