using Enhance.Runtime.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Enhance.Runtime.UI
{
    public class PlayerHealthUIController : MonoBehaviour
    {
        [SerializeField] private Image[] _heartImages;
        [SerializeField] private Sprite _fullHeartImage;
        [SerializeField] private Sprite _emptyHeartImage;

        private PlayerHealthHandler _playerHealthHandler;

        void Start()
        {
            _playerHealthHandler = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerHealthHandler>();
            _playerHealthHandler.OnDamageTaken += _playerHealthHandler_OnDamageTaken;
        }

        private void _playerHealthHandler_OnDamageTaken(object sender, System.EventArgs e)
        {
            SetHeartImages(_playerHealthHandler.CurrentHealth);
        }

        private void SetHeartImages(int health)
        {
            // first fill all images with empty hearts
            foreach (var image in _heartImages)
            {
                image.sprite = _emptyHeartImage;
            }

            // then set full heart images depending on HP
            for (int i = 0; i < health; i++)
            {
                _heartImages[i].sprite = _fullHeartImage;
            }
        }
    }
}
