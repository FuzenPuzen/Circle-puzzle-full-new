using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChildsArranger : MonoBehaviour
{
    public int columns = 4;
    public int rows = 4;
    public float spacingX = 120.0f;
    public float spacingY = 120.0f;
    public float startX = 0.0f;
    public float startY = 0.0f;
    public bool ChangeSize;
    [ShowIf("ChangeSize")]
    public Vector2 ChildSize;

    [ContextMenu("ArrangeChildren")]
    void ArrangeChildren()
    {
        int childID= 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Transform child = transform.GetChild(childID);
                RectTransform childrect = child.GetComponent<RectTransform>();
                BoxCollider2D childcollider = child.GetComponent<BoxCollider2D>();
                float x = startX + (j * spacingX);
                float y = startY + (i * spacingY);
                Vector3 position = new Vector3(x, y, 0.0f);
                childrect.anchoredPosition = position;
                if (ChangeSize)
                {
                    childrect.sizeDelta = ChildSize;
                    childcollider.size = ChildSize;
                }
                childID++;
            }
        }
    }
}
