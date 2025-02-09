using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject cell;

    private void Start()
    {
        const float cellSize = 0.3f;
        const int gridSizeX = 20;
        const int gridSizeY = 13;

        for (var i = -gridSizeX; i <= gridSizeX; i++)
        for (var j = -gridSizeY; j <= gridSizeY; j++)
        {
            var newCell = Instantiate(cell, new Vector3(i * cellSize, j * cellSize, 1f), Quaternion.identity);
            var spriteRenderer = newCell.GetComponent<SpriteRenderer>();
            
            if (i == -gridSizeX || i == gridSizeX || j == -gridSizeY || j == gridSizeY)
                spriteRenderer.color = new Color(0.396078431372549f, 0.2901960784313726f, 0.050980392156862744f, 1f); 
        }
    }
}
