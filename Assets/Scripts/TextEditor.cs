using System;
using UnityEngine;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    
    [SerializeField] private Transform playerTransform, respawnPoint;
    
    [SerializeField] private GameObject border;

    [SerializeField] private Text quitText, gameOverText,
                        restartText, pointText, warnMessage;
    
    [SerializeField] public Text highScore;

    private int point;
    
    public int score;
    
    public float timer;

    public void TextActive()
    {
        quitText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
    }
    
    private void TextPassive()
    {
        quitText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
        warnMessage.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
    }
    
    public void TransformReset()
    {
        playerTransform.transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();
        playerTransform.gameObject.SetActive(true);
        timer = 0;
        TextPassive();
        border.SetActive(true);
    }
    
    public void UpdatePoint()
    {
        point += 5;
        
        if (point >= score)
        {
            score = point;
        }
        
        pointText.text = "Point: " + point;
    }
    
    public void Restart()
    {
        TextPassive();
        TransformReset();
        pointText.text = "Point: 0";
        point = 0;
    }
    
    public void Quit()
    {
        Debug.Log("Quited from Game");
        Application.Quit();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 8f)
        {
            warnMessage.gameObject.SetActive(true);
            if (timer >= 20f)
            {
                restartText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    TextPassive();
                    TransformReset();
                }
            }
        }
    }
}
