using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Fruits", menuName = "Scriptable Objects/Fruits")]
    public class FruitData  : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private FruitController _fruit;

        public string Id => this._id;
        public FruitController Fruit => this._fruit;
    }
}
