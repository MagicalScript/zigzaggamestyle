using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRun : MonoBehaviour
{
    // Start is called before the first frame update
    // float SPEED;
    public playerScript _playerScript;
    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;
    Vector3 touchPosWorld;
    public List<GameObject> mTiles;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        // {
        //     // Debug.Log("touche");
        //     //We transform the touch position into word space from screen space and store it.
        //     touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

        //     Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

        //     //We now raycast with this information. If we have hit something we can process it.
        //     RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

        //     if (hitInformation.collider != null)
        //     {
        //         //We should have hit something with a 2D Physics collider!
        //         Debug.Log("touuuuuuuuck");
        //         //touchedObject should be the object someone touched.
        //         // Debug.Log("Touched " + touchedObject.transform.name);
        //     }
        // }
        // this for mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D touch = Physics2D.Raycast(cubeRay, Vector2.zero);

            if (touch)
            {
                // Debug.Log("We hit " + cubeHit.collider.name);
                _playerScript.changeDirection();
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + _playerScript._SPEED * Time.deltaTime, transform.position.z);

    }
}
