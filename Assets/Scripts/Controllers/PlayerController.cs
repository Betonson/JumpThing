using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _playerRb;
    public float power = 5f;
    private Vector2 _forceToApply;
    public Vector2 minForce;
    public Vector2 maxForce;
    Vector2 startPosition;
    Vector2 endPosition;
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                startPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Debug.Log("Start position captured: " + startPosition);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                endPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Debug.Log("End position captured: " + endPosition);
                _forceToApply = new Vector2(Mathf.Clamp(startPosition.x - endPosition.x, minForce.x, maxForce.x), Mathf.Clamp(startPosition.y - endPosition.y, minForce.y, maxForce.y));
                _playerRb.AddForce(_forceToApply * power, ForceMode2D.Impulse);
            }
        }
    }
}
