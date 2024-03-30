using UnityEngine;

public class WindObject : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float vertWind;
    private Rigidbody2D _rb;
    private bool _isDragging;
    private Vector3 _lastMousePosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastMousePosition = Input.mousePosition;
            _isDragging = true;
        }
        else if (Input.GetMouseButton(0) && _isDragging)
        {
            Vector2 delta = Input.mousePosition - _lastMousePosition;
            if (delta.magnitude > 0)
            {
                GameManager.Instance.WindDirection = delta.normalized;
                _lastMousePosition = Input.mousePosition;
            }
        }
        else if (Input.GetMouseButtonUp(0))
            _isDragging = false;
        Move();
    }

    private void Move()
    {
        if (_isDragging)
            _rb.AddForce(new Vector2(GameManager.Instance.WindDirection.x * speed * Time.deltaTime, GameManager.Instance.WindDirection.y * speed * Time.deltaTime));
        else
            _rb.AddForce(new Vector2(GameManager.Instance.WindDirection.x * speed * Time.deltaTime, GameManager.Instance.WindDirection.y * speed * Time.deltaTime));

    }
}