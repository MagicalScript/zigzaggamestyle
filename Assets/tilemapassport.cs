using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemapassport : MonoBehaviour
{
    int randm;
    public GameObject camera;
    public List<tilemapScript> startTiles;
    GameObject lastPos;
    public List<GameObject> tileMaplist;
    public List<GameObject> tileMaplistOldPassed;
    // Start is called before the first frame update
    void Start()
    {
        tilemapReorder();
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    public void OnTriggerEnter2D(Collider2D o)
    {
        tilemapReorder();
    }

    public void tilemapReorder()
    {
        int turn = 0;
        List<GameObject> nextTiles = nextTilesCount();
        Debug.Log(nextTiles.Count);

        while (nextTiles.Count < 2)
        {
            getLastPos();

            randm = Random.Range(0, tileMaplist.Count - 1);
            var _tile = tileMaplist[randm];
            foreach (var item in nextTiles)
            {
                if (item == _tile)
                    continue;
            }
            if (_tile.transform.position.y + _tile.GetComponentInChildren<tilemapScript>().rectTransform.rect.height > camera.transform.position.y)
                continue;
            _tile.transform.position = new Vector2(
                                        _tile.transform.position.x,
                                        lastPos.transform.position.y + lastPos.GetComponentInChildren<tilemapScript>().rectTransform.rect.height
                                        );
            turn++;
            nextTiles = nextTilesCount();
        }
        turn = 0;
        Debug.Log("tilemapReorder");
    }

    public void getLastPos()
    {
        foreach (GameObject item in tileMaplist)
        {
            // item.transform.position = new Vector2(0,1000);
            if (!lastPos)
            {
                lastPos = item;
            }
            else
            if (item.transform.position.y > lastPos.transform.position.y)
            {
                lastPos = item;
            }
        }
    }
    public List<GameObject> nextTilesCount()
    {
        List<GameObject> count = new List<GameObject>();
        foreach (GameObject item in tileMaplist)
        {
            if (item.transform.position.y > camera.transform.position.y)
            {
                count.Add(item);
            }
        }
        return count;
    }

}
