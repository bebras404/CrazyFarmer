using UnityEngine;

public class ButtonTexture : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    void Start()
    {
        Texture2D tex = new Texture2D(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float t = (float)y / height; // Gradient factor
                Color color = Color.Lerp(Color.green, Color.black, t);
                tex.SetPixel(x, y, color);
            }
        }
        tex.Apply();

        GetComponent<UnityEngine.UI.Image>().sprite = Sprite.Create(tex, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
    }
}