using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector3 mousePosition, location;
    
    public float moveSpeed = 0.1f,
            borderL = -50.5f,
            borderR = 50.5f,
            borderU = 33.25f,
            borderD = 27;

    private bool isTap, isDead;
    [SerializeField] public GameObject border;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        location = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTap = false;
        rigid.simulated = false;
    }

    void Update()
    {
        if (isTap != true)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
            if (location.y <= borderU && location.x >= borderL &&
                   location.x <= borderR && location.y >= borderD)
            {
                transform.position = Vector2.Lerp(
                    transform.position,
                    mousePosition, moveSpeed);
                location = transform.position;
            }
            else
            {
                location = mousePosition;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                border.SetActive(false);
                isTap = true;
            }
        }
        else
        {
            rigid.simulated = true;
        }
    }
}
