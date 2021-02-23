using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Image currentRend;

    // Start is called before the first frame update
    void Start()
    {
        currentRend = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0) && DataHolder.instance.GetUsingObject() != DataHolder.UsingObject.NONE)
        {
            // Cast a ray straight down.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

            // If it hits something...
            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name);
                DataHolder.instance.ResetCursor();
            }
        }
    }

    public void SetCustomCursor(string cursor)
    {
        currentRend.sprite = DataHolder.instance.GetSprite(cursor);

        Color newColor = new Color(255, 255, 255, 255);
        currentRend.color = newColor;
    }

    public void DestroyCursor()
    {
        Color newColor = new Color(255, 255, 255, 0);
        currentRend.color = newColor;
    }
}
