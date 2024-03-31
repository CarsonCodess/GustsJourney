using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.RightArrow))
            TransitionManager.Instance.StartTransitionQuit();
    }
}
