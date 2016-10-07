//Company Entity
[XmlRoot(Namespace="CustomerData",IsNullable=false)]
public class Company
{
    String name;
    string address1;
    string address2;
    string city;
    string state;
    string zip;
    string phone;

    public string Name
    {
        get{return name;}
        set{name = value;}
    }

    public string Address1
    {
        get{return address1;}
        set{address1 = value;}
    }

    public string Address2
    {
        get{return address2;}
        set{address2 = value;}
    }

    public string City
    {
        get{return city;}
        set{city = value;}
    }

    public string State
    {
       get{return state;}
       set{state = value;}
    }

    public string Zip
    {
        get{return zip;}
        set{zip = value;}
    }

    public string Phone
    {
        get{return phone;}
        set{phone = value;}
    }
}
