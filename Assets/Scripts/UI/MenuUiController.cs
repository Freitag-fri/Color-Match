using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

namespace Assets.Scripts
{
    public class MenuUiController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _highScoreText;
        [SerializeField] private LevelData[] _levels;
        [SerializeField] private TMP_Dropdown _levelsDropdown;

        void Start()
        {
            _highScoreText.SetText("Score: {0}", SaveData.HighScore);
            _levelsDropdown.ClearOptions();
            _levelsDropdown.AddOptions(_levels.Select(l => l.name).ToList());
        }

        // Update is called once per frame
        public void StartGame()
        {
            LevelData selected = _levels[_levelsDropdown.value];
            LevelManager.Instance.SetLevel(selected);

            SceneManager.LoadScene("GameScene"); 
        }
    }
}
