using UnityEngine;

namespace Assets.Scripts
{
    public class CreateFruits : MonoBehaviour
    {
        private float _spawnFruitsDelay;
        private Vector2 _createDistanceRange = new Vector2(-8, 8);
        private float timeSinceCreatedFruit;
        private float creationHeight = 3.5f;
        [SerializeField] private FruitController _fruitPrefab;
        [SerializeField] private FruitData [] _fruits;

        void Awake()
        {

            _spawnFruitsDelay = 1.5f;
            timeSinceCreatedFruit = _spawnFruitsDelay;
        }

        void Update()
        {
            timeSinceCreatedFruit += Time.deltaTime;
            if(timeSinceCreatedFruit >= _spawnFruitsDelay)
            {
                CreateFruit();
                timeSinceCreatedFruit = 0;
            }
        }

        private void CreateFruit()
        {
            var newFruit = _fruits[Random.Range(0, _fruits.Length)];
            var fruitPositionX = Random.Range(_createDistanceRange.x, _createDistanceRange.y);
            FruitController fruit = Instantiate(newFruit.Fruit, new Vector2(fruitPositionX, creationHeight), Quaternion.identity);
            fruit.initializer(3f, CollorManager.GetRandomCollor());
        }
    }
}
