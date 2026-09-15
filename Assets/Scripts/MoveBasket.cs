using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBasket : MonoBehaviour
{
    [SerializeField] private GameObject _basket;
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
        {   var mouseClickPosition = pointer.position.ReadValue();
            Ray ray = _mainCamera.ScreenPointToRay(mouseClickPosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit == this.gameObject)
            {
                _isSuccessClick = true;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
                _mouseOffset =  transform.position.x - worldPosition.x;
            }

        }
        else if(pointer.press.isPressed) 
        {
            if (!_isSuccessClick) 
                return;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pointer.position.ReadValue());
            Vector3 newPosition = transform.position;
            newPosition.x = worldPosition.x + _mouseOffset; 
            transform.position = newPosition;
        }
        else if(pointer.press.wasReleasedThisFrame)
        {
           _isSuccessClick = false;
           _mouseOffset = 0;
        }
    }
}
