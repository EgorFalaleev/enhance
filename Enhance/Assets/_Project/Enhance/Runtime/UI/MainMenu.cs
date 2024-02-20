using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enhance.Runtime.UI
{
    public class MainMenu : MonoBehaviour
    {
        private const int GAME_SCENE_INDEX = 1;

        public void PlayGame()
        {
            SceneManager.LoadScene(GAME_SCENE_INDEX);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
