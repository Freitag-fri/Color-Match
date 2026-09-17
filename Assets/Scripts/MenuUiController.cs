using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Assets.Scripts
{
    public class MenuUiController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _highScoreText;

        void Start()
        {
            _highScoreText.SetText("Score: {0}", SaveData.HighScore);
        }

        // Update is called once per frame
        public void StartGame()
        {
        SceneManager.LoadScene("GameScene"); 
        }
    }
}
