using System.Collections.Generic;
// new
using System.Xml;

class OsmWay : BaseOsm
{
    public ulong ID {get; private set; }

    public bool Visible { get; private set; }

    public List<ulong> NodeIDs {get; private set; }

    public bool IsBoundary {get; private set; }

    public bool IsBuilding {get; private set; }

    public bool IsRoad {get; private set; }

    public float Height {get; private set; }

    public OsmWay(XmlNode node)
    {
        NodeIDs = new List<ulong>();
        Height = 10.0f; // ! Originally 3.0f (need to fix the building height - building:levels not being recognized)

        ID = GetAttribute<ulong>("id", node.Attributes);
        Visible = GetAttribute<bool>("visible", node.Attributes);

        XmlNodeList nds = node.SelectNodes("nd");
        foreach (XmlNode n in nds)
        {
            ulong refNo = GetAttribute<ulong>("ref", n.Attributes);
            NodeIDs.Add(refNo);
        }

        // TODO: Determine what type of way this is; is it a road? / boudary etc.

        if (NodeIDs.Count > 1)
        {
            IsBoundary = NodeIDs[0] == NodeIDs[NodeIDs.Count - 1];
        }

        XmlNodeList tags = node.SelectNodes("tag");
        foreach (XmlNode t in tags)
        {
            string key = GetAttribute<string>("k", t.Attributes);
            if (key == "height")
            {
                Height = 0.3048f * GetAttribute<float>("v", t.Attributes);
            }
            
            else if (key == "building:levels")
            {
                 Height = 3.0f * GetAttribute<float>("v", t.Attributes);
            }

            else if (key == "building")
            {
                IsBuilding = GetAttribute<string>("v", t.Attributes) == "yes";
            }

            else if (key == "building")
            {
                Height = 10.0f;
            }

            else if (key == "highway")
            {
                IsRoad = true;
            }

            /** would preferably like to use only: 
            ** trunk roads
            ** primary roads
            ** secondary roads
            ** service roads
            */
        }

    }
   
}
