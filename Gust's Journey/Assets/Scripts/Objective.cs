using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] endSpriteRenderers;
    [SerializeField] private Sprite[] endSprites;
    [SerializeField] private Transform endPos;
    [SerializeField] private bool singleItem = true;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Object"))
        {
            col.transform.localPosition = endPos.position;
            col.transform.localRotation = Quaternion.identity;
            col.gameObject.GetComponent<WindObject>().enabled = false;
            col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            for (var i = 0; i < endSpriteRenderers.Length; i++)
                endSpriteRenderers[i].sprite = endSprites[i];
            if (singleItem)
                Invoke(nameof(NextLevel), 1f);
        }
    }

    private void NextLevel()
    {
        TransitionManager.Instance.StartTransition(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
