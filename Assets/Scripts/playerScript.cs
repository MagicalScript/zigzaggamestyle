using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    left,
    right
}
public class playerScript : MonoBehaviour
{
    public GameData gameManager;
    public characterProperties charactProperties;
    MovementDirection direction;
    public float SPEED = 3.5f;
    public float MaxSPEED = 6f;
    public float SpeedAugmentationPerSec = 0.01f;
    public float _SPEED;
    public float avgSpeed = 4;
    // Start is called before the first frame update
    public void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        _SPEED = SPEED;
        avgSpeed = gameManager.AvgSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == MovementDirection.left)
        {
            transform.position = new Vector3(transform.position.x - _SPEED * Time.deltaTime, transform.position.y, transform.position.z);

        }
        else if (direction == MovementDirection.right)
        {
            transform.position = new Vector3(transform.position.x + _SPEED * Time.deltaTime, transform.position.y, transform.position.z);

        }
        // speed augmentation by play time
        if (_SPEED < MaxSPEED)
        {
            if (_SPEED < avgSpeed)
            {
                _SPEED += Time.deltaTime * SpeedAugmentationPerSec * 10;
            }
            else
            {
                _SPEED += Time.deltaTime * SpeedAugmentationPerSec;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D o)
    {
        // Debug.Log("OnCollisionEnter");
        if (o.gameObject.tag == "keybox")
        {
            o.gameObject.GetComponent<keyBox>().liserObstacle.disableLiser();
        }
        changeDirection();
    }
    public void OnTriggerEnter2D(Collider2D o)
    {
        // Debug.Log("OnTriggerEnter");
        // Debug.Log(o.name);
        if (o.gameObject.tag == "coin")
        {
            gameManager.coin += 1;
            o.gameObject.SetActive(false);
        }
    }
    public void changeDirection()
    {
        // Debug.Log("changeDirection");
        direction = direction == MovementDirection.right ? MovementDirection.left : MovementDirection.right;
        if (direction == MovementDirection.left)
        {
            charactProperties.animator.SetTrigger("turnLeft");
        }
        else
        {
            charactProperties.animator.SetTrigger("turnRight");
        }
    }
    public void hitcoin()
    {

    }
    public void hitkeyBox()
    {

    }
    public void hitObstacle()
    {

    }
    public void hitBorder()
    {
        //avgspeed at lose
        avgSpeed = (avgSpeed + _SPEED)/2;
        gameManager.AvgSpeed = avgSpeed;

    }
}
