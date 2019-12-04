using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapReader : MonoBehaviour
{

    [Tooltip("The resource file that contains the OSM map data")]
    public string resourceFile;

    // Start is called before the first frame update
    void Start()
    {
        var txtAsset = Resource.Load<TextAsset>(resourceFile);

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(txtAsset.text);

        SetBounds(doc.SelectSingleNode("/osm/bounds"));
        GetNodes(doc.SelectNodes("/osm/node"));
        GetWays(doc.SelectNodes("osm/way"));
        

    }
}
 
