public class CompanyControl : UserControl,IRegion
{

    private IRegionFrameProxy frameProxy;
    private FrameType frameType;
    private IVisualStyles visualStyles;
    private XmlNode data;

    public IRegionFrameProxy HostProxy
    {
        get{return frameProxy;}
        set{frameProxy = value;}
    }

    public System.Xml.XmlNode Data
    {
        set{data = value;}
    }

    public Microsoft.InformationBridge.Framework.Interfaces.FrameType HostType
    {
        get{return frameType;}
        set{frameType = value;}
    }

    public IVisualStyles VisualStyle
    {
        get{return visualStyles;}
        set{visualStyles = value;}
    }
}
