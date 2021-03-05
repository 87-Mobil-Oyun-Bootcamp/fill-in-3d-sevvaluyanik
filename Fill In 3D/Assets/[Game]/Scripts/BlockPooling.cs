using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPooling : MonoBehaviour
{
    [SerializeField]
    private Sprite image;


    [SerializeField]
    private GameObject cube;

    public Material blocksColor;

    private float size = 0.1f;

    private Texture2D texture2D;

    private Vector3 cubePos = Vector3.zero;

    private void Awake()
    {
        PoolBlocks();
    }

    private void PoolBlocks()
    {
        texture2D = image.texture;

        for(int x= 0; x < 32; x++)
        {
            for(int y = 0; y < 32; y++)
            {
                Color color = texture2D.GetPixel(x, y);

                if (color.a == 0) {
                    continue;
                }
               

               GameObject cubeObj = Instantiate(cube, new Vector3(x / 10f + transform.position.x, 0.3f, y / 10f), transform.rotation, transform);
              //  cubeObj.transform.localPosition = cubePos;
            
                cubeObj.transform.localScale = Vector3.one * size;
                cubeObj.GetComponent<Renderer>().material.color = blocksColor.color;
             
            }
        }
    }
}
