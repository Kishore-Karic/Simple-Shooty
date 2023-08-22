using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SimpleShooty.Game
{
    public class LobbyManager : MonoBehaviour
    {
        [SerializeField] private Button playButton, quitButton;
        [SerializeField] private int one;

        private void Awake()
        {
            playButton.onClick.AddListener(PlayGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        private void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + one);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}