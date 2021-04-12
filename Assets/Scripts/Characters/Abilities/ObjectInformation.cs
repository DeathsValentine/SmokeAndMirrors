using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInformation
{
    private string name;
    private string description;
    private Sprite icon;

    public ObjectInformation(string name)
    {
        this.name = name;
    }

    public ObjectInformation(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public ObjectInformation(string name, string description, Sprite icon)
    {
        this.name = name;
        this.description = description;
        this.icon = icon;
    }
    
    public string getName
    {
        get { return this.name; }
    }

    public string getDescript
    {
        get { return this.description; }
    }

    public Sprite getIcon
    {
        get { return this.icon; }
    }
}
