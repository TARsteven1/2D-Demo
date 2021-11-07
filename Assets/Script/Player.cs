using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    [Header("Action")]
    public float Speed;
    public float jumpforce;
    private float horizontalmove;
    [Header("Ground")]
    public Transform GroundCheck;
    public LayerMask ground;
    private bool isGround;
    [HideInInspector]
    public static int HP=1;
    public Text HPValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

      

    }
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, ground);
        Movement();
       

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        IsLife();
    }

    private void Movement()
    {
        //anim.SetBool("jumping", isGround);
        horizontalmove = Input.GetAxisRaw("Horizontal");
       
        anim.SetFloat("running", Mathf.Abs(horizontalmove));
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * Speed, rb.velocity.y);
            transform.localScale = new Vector3(horizontalmove, 1, 1);
        }
    }
    private void Jump()
    {
            anim.SetBool("jumping", !isGround);
        if (Input.GetButtonDown("Jump")&&isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
       
    }
    private void IsLife()
    {
        HPValue.text = HP.ToString();
        if (HP<1)
        {
            OnClickReplay();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadLine")
        {
            OnClickReplay();
        }

    }
    public void OnClickReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HP = 1;
    }
}
