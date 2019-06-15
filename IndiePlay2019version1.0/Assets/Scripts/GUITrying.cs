using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITrying : MonoBehaviour {

    public Texture2D myTexture;
    public int height=30;
    public int weight = 100;
    public int height1 = 5;
    public int weight1 = 50;

    string textString;
    string textString1 = "Some text here";
    string textString2 = "Some more text here";
    string textString3 = "Even more text here";

    bool statebool = false;

    private int toolbarInt;
    private string[] toolbarStrings;

    private int selectionGridInt = 0;
    private string[] selectionStrings;

    private float fltSilderValue = 0.5f;

    private Vector2 scrollPosition = Vector2.zero;
    private bool blnToggleState = false;

    private void Start()
    {
        myTexture = new Texture2D(125, 15);
        toolbarInt = 0;
        toolbarStrings =new string[]{ "Toolbar1", "Toolbar2", "Toolbar3"};
        selectionGridInt = 0;
        selectionStrings = new string[]
        {
            "Grid 1","Grid 2","Grid 3","Grid 4"
        };
    }

    private void OnGUI()
    {
        // GUI.DrawTexture(new Rect(325, 15, weight, height), myTexture);
        //  GUI.Label(new Rect(125, 15, weight, height), myTexture);
        //  GUI.Label(new Rect(125, 15, 100, 30), "Text overlap");   
        /*
        if (GUI.Button(new Rect(25, 40, 120, 30),myTexture))
        {
            Debug.Log(1);
        }
        if (GUI.RepeatButton(new Rect(170, 40, 120, 30), "button"))
        {
            Debug.Log(2);
        }*/
        // textString = GUI.TextArea(new Rect(25, 100, 100, 30), textString);
        // textString = GUI.TextArea(new Rect(150, 100, 100, 30), textString2);
        //  textString = GUI.PasswordField(new Rect(375, 100, 90, 30),textString3,'*');
        //statebool = GUI.Toggle(new Rect(25, 150, 250, 30), statebool, "Toggle");
        //  toolbarInt = GUI.Toolbar(new Rect(25, 200, 200, 30), toolbarInt, toolbarStrings);
        // Debug.Log(toolbarInt);
        //selectionGridInt = GUI.SelectionGrid(new Rect(25, 200, 200, 60), selectionGridInt, selectionStrings, 2);
        //  fltSilderValue = GUI.HorizontalSlider(new Rect(25, 250, 100, 30), fltSilderValue , 0f, 10f);
        // fltSilderValue = GUI.VerticalSlider(new Rect(150, 250, 25, 50), fltSilderValue, 0f, 10f);
        //  fltSilderValue = GUI.HorizontalScrollbar(new Rect(25, 285, 100, 30), fltSilderValue, 0.5f, 0f, 10f);
        //  fltSilderValue = GUI.VerticalScrollbar(new Rect(200, 250, 25, 50), fltSilderValue, 0.5f, 10f, 0f);
        scrollPosition = GUI.BeginScrollView(new Rect(25, 325, 300, 200), scrollPosition, new Rect(0, 0, 400, 400));
        for (int i = 0; i < 20; i++)
        {
            addScrollView(i, "I'm listItem number" + i);
        }
        GUI.EndScrollView();
    }

    void addScrollView(int i,string strItemeName)
    {
        GUI.Label(new Rect(25, 25 + i * 25, 150, 25), strItemeName);
        blnToggleState = GUI.Toggle(new Rect(175, 25 + (i * 25), 100, 25), blnToggleState, "");
    }
}
