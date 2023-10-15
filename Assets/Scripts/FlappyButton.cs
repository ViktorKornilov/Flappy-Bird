using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyButton : MonoBehaviour
{
    public string sceneName;

    void OnMouseDown()
    {
        transform.position += Vector3.down * 0.1f;
    }

    void OnMouseUp()
    {
        transform.position += Vector3.up * 0.1f;

        if (sceneName != "")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}