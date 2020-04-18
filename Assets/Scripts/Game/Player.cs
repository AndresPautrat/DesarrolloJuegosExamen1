using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    float Limits;

    float LimitXmin, LimitXmax;
    public int lifes = 5;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Limits = Camera.main.orthographicSize * Screen.width / Screen.height;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Limits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        LimitXmax = Limits.x;
        LimitXmin = -Limits.x;
        WASDMove();
    }

    void WASDMove()
    {
        float WASD = Input.GetAxisRaw("Horizontal");
        if (transform.position.x > LimitXmax)
            transform.position = new Vector3(LimitXmax, transform.position.y, 1);
        else if (transform.position.x < LimitXmin)
            transform.position = new Vector3(LimitXmin, transform.position.y, 1);
        else
        {
            if (WASD > 0)
            {
                rigidbody.velocity = new Vector2(3f, rigidbody.velocity.y);
            }
            else if (WASD < 0)
            {
                rigidbody.velocity = new Vector2(-3f, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "candies")
        {
            score++;
            print(score);
            collision.gameObject.SetActive(false);
            print(lifes);
        }
    }
    public void restLife()
    {
        lifes--;
    }
    public int getLife()
    {
        return lifes;
    }
    public int getScore()
    {
        return score;
    }
}
