using UnityEngine;

public class DestroyAndPoint : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;

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
            playerObject.gameObject.SetActive(false);
            textController.TransformReset();
        }
    }

    void Update()
    {
        if (isDead)
        {
            textController.UpdatePoint();
            isDead = false;
        }
    }
}
