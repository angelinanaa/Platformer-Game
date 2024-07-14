using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pemain : MonoBehaviour
{
    Rigidbody2D rb;
    public float kecepatann,jumpPower;
    Vector2 currentScale;
    Animator anim;
    bool mendarat;

    private void Awake()
    {
        currentScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontall = SimpleInput.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontall*kecepatann, rb.velocity.y);
        transform.Translate(horizontall * Time.deltaTime, 0, 0);

        if (horizontall < 0) transform.localScale = new Vector2(-currentScale.x, currentScale.y);
        if (horizontall > 0) transform.localScale = new Vector2(currentScale.x, currentScale.y);

        if (Input.GetKeyDown(KeyCode.Space) && mendarat)
            Lompat();

        anim.SetBool("lari", horizontall != 0);
        anim.SetBool("mendarat", mendarat);
    }

    public void Lompat()
    {
        rb.AddForce(Vector2.up * jumpPower);
        anim.SetTrigger("lompat");
        mendarat = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tanah")
            mendarat = true;
    }
}
