using UnityEngine;

public class Player : MonoBehaviour
{

    #region PublicStuff
    public float speed;
    public float jumpForce;
    public float rayDistance;
    public LayerMask ground;
    #endregion

    #region PrivateStuff
    private bool jump;
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    float step;
    [HideInInspector] public int attemps = 1;
    #endregion

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed* 100 * Time.deltaTime, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && jump ==true)
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
        RaycastHit2D frontRay = Physics2D.Raycast(transform.position,transform.right,rayDistance,ground);
        RaycastHit2D upRay = Physics2D.Raycast(transform.position,transform.up,rayDistance,ground);
        if(frontRay || upRay)
        {
            Restart();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.CompareTag("Ground"))
        {
            jump = true;
        } 
        if (other.transform.CompareTag("Death"))
        {
            Restart();
        }   
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.transform.CompareTag("Ground"))
        {
            jump = false;
        }    
    }

    public void Restart()
    {
        transform.position = initialPosition;
        attemps++;
        rb.velocity = Vector2.zero;
    }

    #region Methods
    #endregion
}
