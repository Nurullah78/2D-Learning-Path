using UnityEngine;

public class DestroyByGround : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject obstacle;

    private TextEditor textController;

    private bool isDead;
    
    private void Start()
    {
        textController = GameObject.FindWithTag("GameController").GetComponent<TextEditor>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerObject.gameObject)
        {
            isDead = true;
            textController.TextActive();
            obstacle.gameObject.SetActive(false);
            playerObject.gameObject.SetActive(false);
            textController.highScore.gameObject.SetActive(true);
            textController.highScore.text = "Your High Score: " + textController.score;
        }
    }

    private void Update()
    {
        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                isDead = false;
                textController.Restart();
                obstacle.gameObject.SetActive(true);
            }
        
            if (Input.GetKeyDown(KeyCode.Q))
            {
                textController.Quit();
            }
        }
    }
}
