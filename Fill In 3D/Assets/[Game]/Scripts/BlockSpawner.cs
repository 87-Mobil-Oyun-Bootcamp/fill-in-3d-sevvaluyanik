using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Material defaultColor;

    [SerializeField]
    private Sprite image;

    [SerializeField]
    private GameObject cube;

    private float offsetX = 1f;

    private float offsetY = 1f;

    private float size = 0.1f;

    private Texture2D texture2D;

    private Vector3 cubePos = Vector3.zero;

    public Dictionary<Transform, Color> blockList = new Dictionary<Transform, Color>();

    private void Awake()
    {
        SpawnTexture();
    }

   private void SpawnTexture()
    {
        texture2D = image.texture;

        for(int x = 0; x < texture2D.width; x++)
        {
            for(int y = 0; y < texture2D.height; y++)
            {
                Color color = texture2D.GetPixel(x, y);

                if (color.a == 0) {
                    continue;
                }

                cubePos = new Vector3(
                    size * (x - (texture2D.width * .5f)),
                    size * 0f,
                    size * (y - (texture2D.width * .5f)));

                GameObject cubeObj = Instantiate(cube, transform);
                cubeObj.transform.localPosition = cubePos;
                cubeObj.GetComponent<Renderer>().material.color = defaultColor.color;
                cubeObj.transform.localScale = Vector3.one*size;
                blockList.Add(cubeObj.transform, color);
                
            }
        }
    }

}
