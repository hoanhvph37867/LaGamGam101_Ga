using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panelEndGame;

    Rigidbody2D rigidbody2D;
    public float moveSpeed = 4;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    public void Jump ()
    {
        Debug.Log("Vao ham Jump");
        rigidbody2D.AddForce(Vector2.up * 6, ForceMode2D.Impulse);

        
    }
    

    public void RestartGame ()
    {
        panelEndGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "obstacles")
        {
            panelEndGame.SetActive(true);
            Time.timeScale = 0;
        }
    }

        // Update is called once per frame
        void Update()
    {
        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        // {
        //     MoveLeft();
        // }
    }
    public void MoveLeft()
    {
        // Di chuyển nhân vật sang trái
        Debug.Log("Vao ham Left");
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (gameObject.transform.localScale.x > 0)
                {
                    gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                }
    }
    public void MoveRight()
{
    // Di chuyển nhân vật sang phải
    Debug.Log("Vao ham Right");
    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    if (gameObject.transform.localScale.x < 0) //nguoc chieu
                {
                    gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                }
}

}
