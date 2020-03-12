using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backroundOffsetScript : MonoBehaviour
{
    public Material material;
    public float Speed = 0.5f;
    float lastPos = 0;

    // Update is called once per frame
    void Update()
    {
        //material.SetTextureOffset("gradient-geometric-shapes-background_52683-12505",new Vector2(1*Time.deltaTime,1));
        material.mainTextureOffset = new Vector2(Time.time * Speed,0);
    }
}
