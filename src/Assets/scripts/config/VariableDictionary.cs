using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableDictionary
{
    Dictionary<string, object> variables = new Dictionary<string, object>();

    object GetVariable(string name)
    {
        if (variables.ContainsKey(name))
            return variables[name];
        else
            return null;
    }

    void SetVariable(string name, object value)
    {
        if (variables.ContainsKey(name))
            variables[name] = value;
        else
            variables.Add(name, value);
    }

    public object this[string name]
    {
        get
        {
            return GetVariable(name);
        }
        set
        {
            SetVariable(name, value);
        }
    }
        
}
