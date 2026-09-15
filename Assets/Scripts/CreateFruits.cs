using UnityEngine;

public class CreateFruits : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float _spawnFruitsDelay;
    private Vector2 _createDistanceRange = new Vector2(-8, 8);
    private float timeSinceCreatedFruit;
    private float creationHeight = 3.5f;
    [SerializeField] private GameObject _fruitPrefab;

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
        var fruitPositionX = Random.Range(_createDistanceRange.x, _createDistanceRange.y);
        Instantiate(_fruitPrefab, new Vector2(fruitPositionX, creationHeight), Quaternion.identity);
    }
}
