using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enhance.Runtime.UI
{
    public class PauseScreen : MonoBehaviour
    {
        public void Pause()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            gameObject.SetActive(false); 
            Time.timeScale = 1f;
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
