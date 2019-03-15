using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text score;
    public ZombieController zombieController;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "0" + "/" + zombieController.winningCount.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = zombieController.GetCongaLineCount().ToString() + 
                        "/" + zombieController.winningCount.ToString();
        
    }
}
