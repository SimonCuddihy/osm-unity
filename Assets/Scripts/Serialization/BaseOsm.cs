using System;
using System.Xml;

class BaseOsm
{
    /** 
    **GetAttributes function 
    * gets the attributes of type string in the osm xml(txt) file
    * and converts and returns the type specified by the function call 
    * 'protected' makes this function available to child classes
    */ 
    protected T GetAttribute<T>(string attrName, XmlAttributeCollection attributes)
    {
        // TODO: We are going to assume 'attrName' exists in the collection
        
        string strValue = attributes[attrName].Value;
        return (T)Convert.ChangeType(strValue, typeof(T));
    }
}