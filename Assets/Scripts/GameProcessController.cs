using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameProcessController : MonoBehaviour
    {
        float _roundDuration;
        float _roundTimeLeft;
        bool _isGameActive;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _roundTimeText;
        [SerializeField] private GameObject _resultGamePanel;
        [SerializeField] private BasketController _basketController;


        void Start()
        {
            _isGameActive = true;
            _roundDuration = 5;                     // change
            _roundTimeLeft = _roundDuration;
        }

        void Update()
        {
            if(_isGameActive)
            {
                _roundTimeLeft -= Time.deltaTime;
                _roundTimeText.SetText("{0:1}", _roundTimeLeft);

                if(_roundTimeLeft <= 0)
                {
                    _roundTimeText.SetText("{0:1}", 0);
                    Time.timeScale = 0f;
                    _isGameActive = false;
                    ShowResultPanel();

                    if(SaveData.HighScore < _basketController.Score)
                    {
                       SaveData.HighScore =  _basketController.Score;
                    }
                }
            }
        }

        private void ShowResultPanel()
        {
            _resultGamePanel.SetActive(true);
            _scoreText.SetText("{Score: 0}", _basketController.Score);
        }

        public void NewGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}
