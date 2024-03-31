using DG.Tweening;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private Vector2 defaultWindDirection;
    [SerializeField] private Vector2 windDirectionChangeRate = new Vector2(0.5f, 2f);

    public Vector2 WindDirection { get; set; }
    public bool IsDragging { get; set; }

    protected override void Awake()
    {
        base.Awake();
        WindDirection = defaultWindDirection;
        StartAutoWindChange();
    }

    public void StartAutoWindChange()
    {
        IsDragging = false;
        InvokeRepeating(nameof(ChangeWindDirection), Random.Range(windDirectionChangeRate.x, windDirectionChangeRate.y), Random.Range(windDirectionChangeRate.x, windDirectionChangeRate.y));
    }

    public void StopAutoWindChange()
    {
        IsDragging = true;
        CancelInvoke();
    }

    private void ChangeWindDirection()
    {
        var rand = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        DOVirtual.Vector2(WindDirection, rand, 0.5f, value =>
        {
            WindDirection = value;
        }).SetEase(Ease.InOutQuad);
    }
}
