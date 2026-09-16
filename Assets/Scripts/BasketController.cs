using UnityEngine;

namespace Assets.Scripts
{
    public class BasketController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter");
            var fruitController = other.GetComponent<FruitController>();
            
            if(fruitController!= null)
            {
                fruitController.DestroyFrouit();
            }
        }
    }
}