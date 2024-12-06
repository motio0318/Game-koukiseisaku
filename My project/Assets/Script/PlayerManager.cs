using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum DIRECTION_TYPE
    {
        STOP,
        RIGHT,
        LEFT
    }
    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;

    Rigidbody2D rb;
    float speed;
    bool isGround;
    SpriteRenderer spriteRenderer;

    bool isDead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (!isDead)
        {



            //ˆÚ“®‚·‚é•ûŒü‚ðŒˆ‚ß‚é
            if (x == 0)
            {
                //Ž~‚Ü‚Á‚Ä‚é
                direction = DIRECTION_TYPE.STOP;
            }
            else if (x > 0)
            {
                //‰E‚ÉˆÚ“®
                direction = DIRECTION_TYPE.RIGHT;

            }
            else if (x < 0)
            {
                //¶‚ÉˆÚ“®
                direction = DIRECTION_TYPE.LEFT;
            }

            //ƒWƒƒƒ“ƒv
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        switch(direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;

            case DIRECTION_TYPE.RIGHT:
                speed = 3;
                transform.localScale = new(1, transform.localScale.y, 1);
                break;

            case DIRECTION_TYPE.LEFT:
                speed = -3;
                transform.localScale = new(-1, transform.localScale.y, 1);
                break;

        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Jump()
    {
        //ƒLƒƒƒ‰‚Ìã‰º‚ð”½“]
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 1);
        //d—Í‚ð‹t‚É‚·‚é
        rb.gravityScale = -rb.gravityScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "Trap")
        {
            isDead = true;
            StartCoroutine(GameOver());
            //Debug.Log("Torap");
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }

    }

    IEnumerator GameOver()
    {
        //“®‚«‚ðŽ~‚ß‚é
        direction = DIRECTION_TYPE.STOP;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;

        //“_–Å‚³‚¹‚é :F‚ÍÔ
        int count = 0;
        while ( count < 10)
        {
            //Á‚¦‚é
            spriteRenderer.color = new Color32(255, 120, 120,100);
            yield return new WaitForSeconds(0.05f);//0.05•b‘Ò‚Â
            //‚Â‚­
            spriteRenderer.color = new Color32(255, 120, 120, 255);
            yield return new WaitForSeconds(0.05f);//0.05•b‘Ò‚Â

            count++;
        }
        //ƒŠƒXƒ^[ƒg
    }
}
