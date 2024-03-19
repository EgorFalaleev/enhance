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
            SetLevelText(levelUpSystem.Level);
            SetExperienceBarFill(levelUpSystem.GetExperiencePercentage());

            // subscribe to exp and lvl change
            levelUpSystem.OnLevelChanged += HandleLevelChange;
            levelUpSystem.OnExperienceChanged += HandleExperienceChange;
        }

        private void HandleExperienceChange(object sender, System.EventArgs e)
        {
            SetExperienceBarFill(_levelUpSystem.GetExperiencePercentage());
        }

        private void HandleLevelChange(object sender, int level)
        {
            SetLevelText(level);
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
