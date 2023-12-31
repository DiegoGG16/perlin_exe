
using UnityEngine;

public class perlin : MonoBehaviour
{
    public int width = 256;
    public int heigth = 256;
    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY=100f;

    void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);
    }
    void Update()
    {
         Renderer renderer=GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }
    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, heigth);
        for(int x=0; x<width; x++)
        {
            for (int y=0;y<heigth;y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }
    Color CalculateColor(int x, int y)
    {
        float xcoord = (float)x / width * scale * offsetX;
        float ycoord = (float)y / heigth * scale * offsetY;
        float sample= Mathf.PerlinNoise(xcoord, ycoord);
        return new Color(sample, sample, sample);
    }
}
