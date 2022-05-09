using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PE22A_JAMZ.src.Utils
{
    internal class XmlUtils
    {

        public static string GetXmlValue(XmlDocument Document, 
                                         string XmlTag, 
                                         string Property,
                                         int Index)
        {
            // Variables
            XmlNodeList ElementList;
            XmlElement Element;

            // Obtener los elementos por su etiqueta
            ElementList = Document.GetElementsByTagName(XmlTag);

            // Iterar a través de los elementos obtenidos

            Element = (XmlElement)ElementList[Index];

            // Si la propiedad esta vacia 

            if (Property.Equals(""))
            {
                return Element.InnerText;
            }

            if (Property != "")
            {
                return Element[Property].InnerText;
            }

            return "Error";

        }

    }
}
