using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    class Serialization
    {  
    public static void Serialize(string filename, List<Line> lines)
    {
       
        XmlSerializer formatter = new XmlSerializer(typeof(List<Line>));

        using (FileStream fs = new FileStream(filename, FileMode.Create))
        {
            formatter.Serialize(fs, lines);
        }
    }

    public static List<Line> Deserialize(string filename)
    {
        XmlSerializer formatter = new XmlSerializer(typeof(List<Line>));
        var lines = new List<Line>();
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            lines = (List<Line>)formatter.Deserialize(fs);
        }
        return lines;
            

        
    }

}
}
