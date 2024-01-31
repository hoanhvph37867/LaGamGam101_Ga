using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

     public GameObject panelEndGame;

    public GameObject effectPartical;

    public GameObject banana;

    public GameObject weapon;

    public AudioClip jump;
    public AudioClip collectFruit;
    private AudioSource audioSource;
     public float moveSpeed = 12f;
     
    public SpriteRenderer spriteRenderer;

    void Start()
    {
         //rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Instantiate(weapon, gameObject.transform);

        audioSource = GetComponent<AudioSource>();

        //Instantiate(effectPartical, gameObject.transform);
    }


    

    public void Jump()
    {
       GetComponent<Rigidbody2D>().AddForce(Vector2.up * movePrefix, ForceMode2D.Impulse);
    }
    float movePrefix = 4;
    public void moveLeft ()
    {
       spriteRenderer.flipX = true;
       GetComponent<Rigidbody2D>().AddForce(Vector2.left * movePrefix, ForceMode2D.Impulse);
    }

    public void moveRight()
    {
       spriteRenderer.flipX = false;
       GetComponent<Rigidbody2D>().AddForce(Vector2.right * movePrefix, ForceMode2D.Impulse);
    }
    
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "obstacles")
        {
            panelEndGame.SetActive(true);
            Time.timeScale = 0;
            
        }
        if (other.gameObject.tag == "checkpoint")
        {
            SceneManager.LoadScene("Level 2");
        }
    }

    // qua màn chơi khác
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("Va cham vao: " + collision.gameObject.tag);
    //     if (collision.gameObject.tag == "nendat")
    //     {
    //         //isGrounded = true;
    //         // animator.SetBool("isGround", true);
    //         // animator.SetBool("isRun", false);
    //         animator.SetBool("diChay", false);
    //         animator.SetBool("diDung", true);
    //     }
    //     else if (collision.gameObject.tag == "door")
    //     {
    //         SceneManager.LoadScene("Level1");
    //     }
    // }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "fruits")
        {

            audioSource.PlayOneShot(collectFruit);

            Destroy(collider.gameObject);

            //Instantiate(effectPartical, new Vector3(0, 0, 0), Quaternion.identity);

        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }


//     public void MoveLeft()
//     {
//         // Di chuyển nhân vật sang trái
//         Debug.Log("Vao ham Left");
//         transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
//         if (gameObject.transform.localScale.x > 0)
//                 {
//                     gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

//                 }
//     }
//     public void MoveRight()
// {
//     // Di chuyển nhân vật sang phải
//     Debug.Log("Vao ham Right");
//     transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
//     if (gameObject.transform.localScale.x < 0) //nguoc chieu
//                 {
//                     gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

//                 }
// }

}
