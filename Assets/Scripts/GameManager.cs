using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject retryButton;
    public GameObject playButton;
    public GameObject player;

    public Text scoreNumber, bestNumber;

    public Animator sipario;
    public Animator cartello;
    public Animator playerAnim;

    public AudioSource recordAudio;



    int score, bestScore;
    bool gameStarted, gamePaused, didBestScore;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 1;
        if(PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            bestScore = 0;
        }
        bestNumber.text = bestScore.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameStarted == true)
        {
            UpdateStuff();
        }

    }
     
    public void IncreaseScore()
    {
        score++;
        if(scoreNumber != null)
        {
            scoreNumber.text = score.ToString();
        }
        if(score > 1500 && score < 3000)
        {
            Time.timeScale = 1.3f;
        }
        else if(score > 3000 && score < 4500)
        {
            Time.timeScale = 1.6f;
        }
        else if(score > 4500)
        {
            Time.timeScale = 1.8f;
        }
    }
    void UpdateStuff()
    {
        if (PlayerController.instance != null && PlayerController.instance.isDead == false)
        {
            IncreaseScore();

            if(bestScore != 0 && score> bestScore && didBestScore == false)
            {
                didBestScore = true;
                recordAudio.Play();

            }
        }
        else if(PlayerController.instance != null && PlayerController.instance.isDead == true)
        {
            Time.timeScale = 0;

            sipario.SetTrigger("SiparioEnd");
            StartCoroutine(CartelloAnimationEnd());
        }
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        
    }

    void SiparioAnimation()
    {
        sipario.SetTrigger("SiparioStart");
        gameStarted = true;
        StartCoroutine(ActivePlayer());
    }

    public void PlayButton()
    {
        cartello.SetTrigger("CartelloStart");
        Invoke(nameof(SiparioAnimation), 1f);

    }


    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }


    IEnumerator ActivePlayer()
    {
        yield return new WaitForSeconds(0.5f);
        player.SetActive(true);
    }

    IEnumerator CartelloAnimationEnd()
    {
        yield return new WaitForSecondsRealtime(1f);
        cartello.SetTrigger("CartelloEnd");
        playButton.SetActive(false);
        retryButton.SetActive(true);
    }
}
