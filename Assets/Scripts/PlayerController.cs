using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private Text countText = null;

    [SerializeField]
    new private Rigidbody rigidbody = null;

    [SerializeField]
    private Material material = null;

    private int count;

    private void Start()
    {
        count = 0;
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rigidbody.AddForce(movement * speed);
    }

    void OnTriggerEnter (Collider other)
    {
        Powerup powerup = other.GetComponent<Powerup>();
        if (other.gameObject.CompareTag("Pick Up"))
        {
            count++;
            SetCountText();
        }

        if (powerup)
        {
            if(powerup.powerupData.scaleSize == Powerup.PowerupData.ScaleSize.Custom)
            {
                transform.localScale = transform.localScale + powerup.powerupData.scale;
                rigidbody.mass = rigidbody.mass + powerup.powerupData.mass;
            }
            else if(powerup.powerupData.scaleSize == Powerup.PowerupData.ScaleSize.Random)
            {
                if (!powerup.powerupData.scale.Equals(Vector3.zero))
                {
                    float randNum = Random.Range(0.5f, 3f);
                    transform.localScale = new Vector3(randNum, randNum, randNum);
                    rigidbody.mass = randNum;
                }
            }

            if (powerup.powerupData.colorType == Powerup.PowerupData.ColorType.Custom)
            {
                material.color = powerup.powerupData.color;
            }

            else if(powerup.powerupData.colorType == Powerup.PowerupData.ColorType.Random)
            { 
                material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }

            float halfProb = Random.value;
            if (halfProb < 0.5f & speed > powerup.powerupData.speed)
                speed = speed - powerup.powerupData.speed;
            else
                speed = speed + powerup.powerupData.speed;
        }
    }

    private void OnApplicationQuit()
    {
        material.color = Color.white;
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}

    
