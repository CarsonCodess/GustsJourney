using DG.Tweening;
using UnityEngine;

public class WindObject : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 2500;
    [SerializeField] private float strongWindSpeed = 5000;
    [SerializeField] private bool sway = true;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = Random.Range(0.5f, 1.75f);
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        var strongWind = Input.GetKey(KeyCode.F) || Input.GetMouseButton(1);
        var speed = strongWind ? strongWindSpeed : baseSpeed;
        speed = Random.Range(speed - 2000, speed + 2500);
        _rb.velocity = new Vector2(GameManager.Instance.WindDirection.x * speed * Time.deltaTime, GameManager.Instance.WindDirection.y * speed * Time.deltaTime);
        if (sway)
        {
            var swaySpeed = strongWind ? 8f : 4f;
            var angle = Mathf.Sin(Time.time * swaySpeed) * 70f;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
    }
}