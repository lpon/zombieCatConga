using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public float startDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadCongaScene", startDelay);
    }

    void LoadCongaScene()
    {
        SceneManager.LoadScene("CongaScene");
    }
}
