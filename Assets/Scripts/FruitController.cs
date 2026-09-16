using System;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts
{
    public class FruitController : MonoBehaviour
    {
        private float _speed;
        private Rigidbody2D _rb;
        private float _maxFallDistance = 30;
        private float _selfDestroyPosition;
        private bool isDestroyStarted;
        private CollorManager.Collors _fruitCollor;
        public CollorManager.Collors FruitCollor{ get; }

        public void initializer(float speed, CollorManager.Collors fruitCollor)
        {
            _speed = speed;
            _fruitCollor = fruitCollor;
            var sr = transform.GetComponent<SpriteRenderer>();
            sr.color = CollorManager.GetSpriteCollor(_fruitCollor);
        }

        void Awake()
        {
            _rb = transform.GetComponent<Rigidbody2D>();
            _selfDestroyPosition = transform.position.y - _maxFallDistance;
        }

        void FixedUpdate()
        {
            _rb.MovePosition(transform.position +  Vector3.down * Time.deltaTime * _speed);
            if(transform.position.y < _selfDestroyPosition)
            {
                DestroyFrouit();
            }
        }

        public void DestroyFrouit()
        {
            if(isDestroyStarted)
                return;
            
            transform.DOScale(Vector3.zero, 0.25f).OnComplete(() => Destroy(gameObject));
            isDestroyStarted = true;
        }
    }
}
