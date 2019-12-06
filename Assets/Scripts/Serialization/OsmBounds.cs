using System.Xml;
using UnityEngine;

class OsmBounds : BaseOsm
{
    public float MinLat { get; private set; }

    public float MaxLat { get; private set; }

    public float MinLon { get; private set; }

    public float MaxLon { get; private set; }

    public Vector3 Centre { get; private set; }

    // bounds: minlat="53.2770000" minlon="-9.0703000" maxlat="53.2893000" maxlon="-9.0567000"

    public OsmBounds(XmlNode node)
    {
        MinLat = GetAttribute<float>("minlat", node.Attributes);
        MaxLat = GetAttribute<float>("maxlat", node.Attributes);
        MinLon = GetAttribute<float>("minlon", node.Attributes);
        MaxLon = GetAttribute<float>("maxlon", node.Attributes); 

        float x = (float)(MercatorProjection.lonToX(MaxLon) + MercatorProjection.lonToX(MinLon))/2;
        float y = (float)(MercatorProjection.latToY(MaxLat) + MercatorProjection.latToY(MinLat))/2;

        Centre = new Vector3(x, 0, y);

    }

}