using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class MoveBasket : MonoBehaviour
    {
        Camera _mainCamera;
        bool _isSuccessClick;
        float _mouseOffset;

        void Start()
        {
            _mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            var pointer = Pointer.current;

            if (pointer.press.wasPressedThisFrame)
            {
                Click(pointer);
            }
            else if(pointer.press.isPressed) 
            {
                MoveMouse(pointer);
            }
            else if(pointer.press.wasReleasedThisFrame)
            {
                UnClick();
            }
        }

        private void Click(Pointer pointer)
        {
           var mouseClickPosition = pointer.position.ReadValue();
            Ray ray = _mainCamera.ScreenPointToRay(mouseClickPosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit == this.gameObject)
            {
                _isSuccessClick = true;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
                _mouseOffset =  transform.position.x - worldPosition.x;
            } 
        }

        private void MoveMouse(Pointer pointer)
        {
            if (!_isSuccessClick) 
                return;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pointer.position.ReadValue());
            Vector3 newPosition = transform.position;
            newPosition.x = worldPosition.x + _mouseOffset; 
            transform.position = newPosition;
        }

        private void UnClick()
        {
            _isSuccessClick = false;
            _mouseOffset = 0;
        }
    }
}
