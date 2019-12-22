using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public enum State
    {
        title,
        menu,
        level,
        credits,
        options,
        quit,
    }

    public State currentState;


    public List<List<GameObject>> menuobjs = new List<List<GameObject>>();
    public List<GameObject> title = new List<GameObject>();
    public List<GameObject> menu = new List<GameObject>();
    public List<GameObject> level = new List<GameObject>();
    public List<GameObject> credits = new List<GameObject>();
    public List<GameObject> options = new List<GameObject>();

    public List<List<Vector2>> menuobjspos = new List<List<Vector2>>();
    public List<Vector2> titlepos = new List<Vector2>();
    public List<Vector2> menupos = new List<Vector2>();
    public List<Vector2> levelpos = new List<Vector2>();
    public List<Vector2> creditspos = new List<Vector2>();
    public List<Vector2> optionspos = new List<Vector2>();



    void Start()
    {

        menuobjs.Add(title);
        menuobjs.Add(menu);
        menuobjs.Add(level);
        menuobjs.Add(credits);
        menuobjs.Add(options);


        for (int i = 0; i < title.Count; i++)
        {
            titlepos.Add(new Vector2(menuobjs[0][i].transform.localPosition.x, menuobjs[0][i].transform.localPosition.y));
            menuobjs[0][i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1050.0f, menuobjs[0][i].transform.localPosition.y);
        }


        for (int i = 0; i < menu.Count; i++)
        {
            menupos.Add(menuobjs[1][i].transform.localPosition);
            menuobjs[1][i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1050.0f, menuobjs[1][i].transform.localPosition.y);
        }
        for (int i = 0; i < level.Count; i++)
        {
            levelpos.Add(menuobjs[2][i].transform.localPosition);
            menuobjs[2][i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1050.0f, menuobjs[2][i].transform.localPosition.y);
        }
        for (int i = 0; i < credits.Count; i++)
        {
            creditspos.Add(menuobjs[3][i].transform.localPosition);
            menuobjs[3][i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1050.0f, menuobjs[3][i].transform.localPosition.y);
        }
        for (int i = 0; i < options.Count; i++)
        {
            optionspos.Add(menuobjs[4][i].transform.localPosition);
            menuobjs[4][i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1050.0f, menuobjs[4][i].transform.localPosition.y);
        }

        menuobjspos.Add(titlepos);
        menuobjspos.Add(menupos);
        menuobjspos.Add(levelpos);
        menuobjspos.Add(creditspos);
        menuobjspos.Add(optionspos);

        currentState = State.title;
        StartCoroutine(fade(currentState));

    }

    void Update()
    {

        if (Input.anyKeyDown && currentState == State.title)
        {
            currentState = State.menu;
            StartCoroutine(fade(currentState));
        }

        if (currentState == State.level)
        { 
        
        }

        if (currentState == State.quit)
        {
            Application.Quit();
        }

    }

    public void playpressed()
    {
        currentState = State.level;
    }
    public void creditspressed()
    {
        currentState = State.credits;
    }
    public void optionspressed()
    {
        currentState = State.options;
    }
    public void quitspressed()
    {
        currentState = State.quit;
    }

    IEnumerator fade(State FadeToState)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 1.0f)
        {
            for (int i = 0; i < menuobjs[(int)FadeToState].Count; i++)
            {
                Debug.Log(new Vector2(Mathf.Lerp(-1050.0f, menuobjspos[(int)FadeToState][0].x, t), menuobjspos[(int)FadeToState][0].y));
                menuobjs[(int)FadeToState][i].GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Lerp(-1050.0f, menuobjspos[(int)FadeToState][i].x, t), menuobjspos[(int)FadeToState][i].y);
            }
            yield return null;

        }
    }
}
