using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float EnergyCount;
    public GameObject EnergyText;
    public Animator playerAni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.levelTime > 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAni.SetBool("Walk", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                playerAni.SetBool("Walk", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAni.SetBool("Walk", true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                playerAni.SetBool("Walk", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAni.SetBool("Walk", true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                playerAni.SetBool("Walk", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAni.SetBool("Walk", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                playerAni.SetBool("Walk", false);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
            {
                playerAni.SetBool("Walk", true);
            }
        }
        else if (GameManager.instance.levelTime < 0)
        {
            playerAni.SetBool("Walk", false);
            SceneManager.LoadScene("LoseScene");
        }
        if(EnergyCount <0)
        {
            SceneManager.LoadScene("LoseScene");
        }
        if(EnergyCount>50)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Add"))
        {
            Destroy(collision.gameObject);
            EnergyCount = EnergyCount + 5;
            EnergyText.GetComponent<Text>().text = "EnergyCount: " + EnergyCount;
            GameManager.instance.levelTime += (5);
            GameManager.instance.spawn();
        }
        if(collision.gameObject.CompareTag("Minus"))
        {
            Destroy(collision.gameObject);
            EnergyCount = EnergyCount - 25;
            EnergyText.GetComponent<Text>().text = "EnergyCount: " + EnergyCount;
        }
    }
}
