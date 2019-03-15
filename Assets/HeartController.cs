using UnityEngine;

public class HeartController : MonoBehaviour
{
    private ZombieController zombieController;

    public GameObject heart0;
    public GameObject heart1;
    public GameObject heart2;
    
    // Start is called before the first frame update
    void Start()
    {
        zombieController = GameObject.Find("Zombie").transform.GetComponent<ZombieController>();

        heart0.GetComponent<SpriteRenderer>().enabled = true;
        heart1.GetComponent<SpriteRenderer>().enabled = true;
        heart2.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        int currentLives = zombieController.GetLives();

        if (currentLives == 2)
        {
            heart2.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (currentLives == 1)
        {
            heart1.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (currentLives == 0)
        {
            heart0.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
