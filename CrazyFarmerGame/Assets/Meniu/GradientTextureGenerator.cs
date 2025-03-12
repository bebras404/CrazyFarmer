using UnityEngine;
using UnityEngine.UI;

public class BottomToTopGradient : MonoBehaviour
{
    public Image buttonImage;
    public Color startColor = new Color(0f, 100f / 255f, 0f); // Dark Green (Bottom)
    public Color endColor = new Color(144f / 255f, 238f / 255f, 144f / 255f); // Light Green (Top)
    public int textureHeight = 256; // Texture resolution

    void Start()
    {
        buttonImage.sprite = GenerateGradientSprite(textureHeight);
    }

    Sprite GenerateGradientSprite(int height)
    {
        Texture2D texture = new Texture2D(1, height);
        for (int y = 0; y < height; y++)
        {
            float t = y / (float)(height - 1);
            Color color = Color.Lerp(startColor, endColor, t); // Reversed order
            texture.SetPixel(0, y, color);
        }
        texture.Apply();

        return Sprite.Create(texture, new Rect(0, 0, 1, height), new Vector2(0.5f, 0.5f));
    }
}
