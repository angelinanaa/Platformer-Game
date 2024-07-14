using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float kecepatan, jumpPower;
    Animator anim;
    Vector2 currentScale;
    Rigidbody2D rb;
    public LayerMask layerMask;
    public Transform groundCheck;
    public float darah = 100f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementx = SimpleInput.GetAxisRaw("Horizontal") * kecepatan;

        transform.Translate(movementx * Time.deltaTime, 0, 0);

        if (darah <= 0)
        {
            anim.Play("mati");
            Destroy(gameObject);
        }

        if (pijakTanah() == false)
        {
            anim.Play("lompat");
        }
        else if (movementx != 0)
        {
            anim.Play("lari");
        }
        else
        {
            anim.Play("iddle");
            if (Input.GetKeyDown(KeyCode.B))
            {
                anim.Play("serang");
            }
        }


        if (movementx < 0) transform.localScale = new Vector2(-currentScale.x, currentScale.y);
        if (movementx > 0) transform.localScale = new Vector2(currentScale.x, currentScale.y);

        if (Input.GetKeyDown(KeyCode.Space) && pijakTanah())
        {
            rb.AddForce(Vector2.up * jumpPower);
        }

        

        if (transform.position.y <= -7)
        {
            darah = 0;
        }


    }
    public bool pijakTanah()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0, layerMask);
    }

    public void LompatFunction()
    {
        if (pijakTanah())
        {
            rb.AddForce(Vector2.up * jumpPower);
        }
    }
}
