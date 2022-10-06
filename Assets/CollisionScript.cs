using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public int score;

    public Text ScoreTxt;

   

    public float timeLeft;
    public Text TimerTxt;

    public GameObject Particle;

    
    // Start is called before the first frame update
    void Start()
    {
        ScoreTxt.text = "Score : " + score;
        TimerTxt.text = "Time: " + timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        TimerTxt.text = "Time: " + timeLeft;

        if(score == 80)
        {
            SceneManager.LoadScene("GameWin");
        }
        else if(timeLeft <= 0)
        {
            SceneManager.LoadScene("GameLose");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            score += 10;
            ScoreTxt.text = "Score : " + score;
            Destroy(other.gameObject);
            Instantiate(Particle, other.transform.position, Quaternion.identity);
        }

        if(other.gameObject.tag == "Fire")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
