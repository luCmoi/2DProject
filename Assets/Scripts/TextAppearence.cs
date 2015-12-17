using UnityEngine;
using UnityEngine.UI;

public class TextAppearence : MonoBehaviour {
    public PageText[] pages;
    public bool active = true;

    private int page;
    private bool pressed = false;
    private bool inWork = false;
    private bool tuchPressed = false;
    // Use this for initialization
    void Start () {
    }

    void Update()
    {
        if (inWork)
        {
            if (!tuchPressed || (tuchPressed && pressed))
            {
                tuchPressed = Input.GetButtonDown("Jump");
            }
        }
    }
    void FixedUpdate()
    {
        if (inWork)
        {
            if (tuchPressed && !pressed)
            {
                pressed = true;
                if (page >= pages.Length)
                {
                    inWork = false;
                    GameUtilities.Instance.dontMove = false;
                    GameUtilities.Instance.textPlace.SetActive(false);
                    tuchPressed = false;
                    pressed = false;
                }
                else
                {
                    showText();
                }
            }
            else if (!tuchPressed && pressed)
            {
                pressed = false;
            }

        }
    }
    
    public void Play()
    {
        if (active)
        {
            GameUtilities.Instance.textPlace.SetActive(true);
            active = false;
            pressed = false;
            page = 0;
            GameUtilities.Instance.dontMove = true;
            inWork = true;
            showText();
        }
    }

    void showText()
    {
        GameUtilities.Instance.textName.text = pages[page].name + " : ";
        GameUtilities.Instance.textShown.text = "";
        GameUtilities.Instance.textShown.font = pages[page].font;
        GameUtilities.Instance.textShown.fontStyle = pages[page].fontStyle;
        GameUtilities.Instance.portrait.GetComponent<Image>().overrideSprite = pages[page].image;
        foreach (string line in pages[page].text)
        {
                GameUtilities.Instance.textShown.text = GameUtilities.Instance.textShown.text + line + "\n";
        }
        page++;
    }
}
