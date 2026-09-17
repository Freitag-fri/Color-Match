using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BasketController : MonoBehaviour
    {
        private CollorManager.Collors _currentBasketCollor;
        private CollorManager.Collors _nextBasketCollor;
        private SpriteRenderer _sr;
        private float changeColorPeriod;
        private float timeToNextChangeColor;
        public int Score { get => _score; }
        
        [SerializeField] private UpdateScoreUI _updateScoreUI;
        [SerializeField] private int _score;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _fill;
        [SerializeField] private Image _background;


        void Awake()
        {
            changeColorPeriod = 2; // update
            timeToNextChangeColor = 0;
            _sr = transform.GetComponent<SpriteRenderer>();

            _slider.maxValue = changeColorPeriod;
            _slider.value = changeColorPeriod - timeToNextChangeColor;
            _fill = _slider.fillRect.GetComponent<Image>();
            _background = _slider.transform.Find("Background").GetComponent<Image>();
        }

        void Start()
        {
            _nextBasketCollor = CollorManager.GetRandomCollor();
            // var color = CollorManager.GetSpriteCollor(_basketCollor);
            // _sr.color = color;
            // _background.color = color;
        }

        void Update()
        {
            timeToNextChangeColor -= Time.deltaTime;
            if(timeToNextChangeColor <= 0)
            {
                timeToNextChangeColor = changeColorPeriod;
                ChangeColor();
            }
            _slider.value = changeColorPeriod - timeToNextChangeColor;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var fruitController = other.GetComponent<FruitController>();

            if(fruitController != null && !fruitController.IsDestroyStarted)
            {
                int changeScore = 0;
                if(fruitController.FruitCollor == _currentBasketCollor)
                    changeScore += 100;
                else
                    changeScore -= 100;

                _score += changeScore; 
                UpdateScoreUI updateScoreUI = Instantiate(_updateScoreUI, fruitController.transform.position, Quaternion.identity);
                updateScoreUI.StartAnimation(changeScore.ToString());
                _scoreText.text = "Score: " + _score.ToString();


                fruitController.DestroyFrouit();
            }
        }

        private void ChangeColor()
        {
            _currentBasketCollor = _nextBasketCollor;
            do
            {
                _nextBasketCollor = CollorManager.GetRandomCollor();
            } while (_nextBasketCollor == _currentBasketCollor);
            var currentColor = CollorManager.GetSpriteCollor(_currentBasketCollor);
            _background.color = currentColor;
            _sr.color = currentColor;

            _fill.color = CollorManager.GetSpriteCollor(_nextBasketCollor);
        }
    }
}