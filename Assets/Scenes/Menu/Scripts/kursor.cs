using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kursor : MonoBehaviour
{
    public Sprite cursorSprite;

    void Start()
    {
        if (cursorSprite != null)
        {
            // Przekształć Sprite na Texture2D
            Texture2D cursorTexture = SpriteToTexture(cursorSprite);

            // Ustaw kursor
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    // Metoda przekształca Sprite na Texture2D
    private Texture2D SpriteToTexture(Sprite sprite)
    {
        Texture2D texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        texture.SetPixels(sprite.texture.GetPixels((int)sprite.rect.x, (int)sprite.rect.y,
                                                  (int)sprite.rect.width, (int)sprite.rect.height));
        texture.Apply();
        return texture;
    }
}
