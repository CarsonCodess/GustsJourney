using DG.Tweening;
using UnityEngine;

public class WindObject : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        _rb.AddForce(new Vector2(GameManager.Instance.WindDirection.x * speed * Time.deltaTime, GameManager.Instance.WindDirection.y * speed * Time.deltaTime));
    }
}