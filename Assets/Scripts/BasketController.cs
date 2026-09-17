using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class BasketController : MonoBehaviour
    {
        private CollorManager.Collors _basketCollor;
        private SpriteRenderer _sr;
        [SerializeField] private UpdateScoreUI _updateScoreUI;
        [SerializeField] private int _score;
        public int Score { get => _score;}
        [SerializeField] private TextMeshProUGUI _scoreText;


        void Awake()
        {
            _sr = transform.GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            _basketCollor = CollorManager.GetRandomCollor();
            _sr.color = CollorManager.GetSpriteCollor(_basketCollor);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var fruitController = other.GetComponent<FruitController>();

            if(fruitController != null && !fruitController.IsDestroyStarted)
            {
                int changeScore = 0;
                if(fruitController.FruitCollor == _basketCollor)
                {
                    changeScore += 100;
                } 
                else
                {
                    changeScore -= 100;
                }
                _score += changeScore; 
                UpdateScoreUI updateScoreUI = Instantiate(_updateScoreUI, fruitController.transform.position, Quaternion.identity);
                updateScoreUI.StartAnimation(changeScore.ToString());
                _scoreText.text = "Score: " + _score.ToString();


                fruitController.DestroyFrouit();
            }
        }
    }
}