using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private float _fruitSpeed;
    [SerializeField] private float _spawnFruitsDelay;

    public string Id => this._id;
    public float FruitSpeed => this._fruitSpeed;
    public float SpawnFruitsDelay => this._spawnFruitsDelay;
}
