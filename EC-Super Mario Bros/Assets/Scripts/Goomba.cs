using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y > transform.position.y + 0.04f)
            {
                GetComponent<Animator>().SetTrigger("death");
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<EnemyMovement>().enabled = false;

                Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRB.velocity = new Vector2(playerRB.velocity.x, 10);

                Destroy(gameObject, 0.5f);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerBehaviour>().Hit();
            }
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}