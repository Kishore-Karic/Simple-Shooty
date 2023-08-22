using SimpleShooty.GenericSingleton;
using SimpleShooty.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SimpleShooty.Game
{
    public class UIManager : GenericSingleton<UIManager>
    {
        [SerializeField] private GameObject gameOverPanel, gameWonPanel;
        [SerializeField] private Button restartButton, replayButton, menuButton;
        [SerializeField] private int zero, one;
        [field: SerializeField] public VirtualJoyStickController VirtualJoyStickController { get; private set; }

        protected new void Awake()
        {
            base.Awake();

            restartButton.onClick.AddListener(RestartScene);
            replayButton.onClick.AddListener(RestartScene);
            menuButton.onClick.AddListener(GoToMainMenu);
        }

        private void GoToMainMenu()
        {
            SceneManager.LoadScene(zero);
        }

        private void RestartScene()
        {
            Time.timeScale = one;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GameWon()
        {
            Time.timeScale = zero;
            gameWonPanel.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }

        public void GameOver()
        {
            Time.timeScale = zero;
            gameOverPanel.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
    }
}