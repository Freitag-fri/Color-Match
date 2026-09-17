using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MenuUiController : MonoBehaviour
    {
        void Start()
        {
            
        }

        // Update is called once per frame
        public void StartGame()
        {
        SceneManager.LoadScene("GameScene"); 
        }
    }
}
