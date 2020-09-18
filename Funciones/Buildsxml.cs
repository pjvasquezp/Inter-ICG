using ICG_Inter.Properties;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ICG_Inter.Funciones
{
    public class Buildsxml
    {
        public void ContruyeXML(string SerieDoc, Int32 NumDoc)
        {
            XmlDocument xml = new XmlDocument();

            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "UTF-8", null);

            string RutaXml = Settings.Default.PathFirmFEL;          //Ruta XML 
            string SRVFirmado = Settings.Default.ServidorFirmado;   //Servidor para Firmado
            string UserFirmado = Settings.Default.UserFirmado;      //User para Firmado
            string BDFirmado = Settings.Default.BDFirmado;          //BD para Firmado

            //raiz
            XmlElement raiz = xml.CreateElement("docbeforeprint");
            xml.AppendChild(raiz);
            xml.InsertBefore(xmlDeclaration, raiz);

            //Element bd
            XmlElement bd = xml.CreateElement("bd");
            raiz.AppendChild(bd);

            XmlElement server = xml.CreateElement("server");
            server.AppendChild(xml.CreateTextNode(SRVFirmado));
            bd.AppendChild(server);

            XmlElement database = xml.CreateElement("database");
            database.AppendChild(xml.CreateTextNode(BDFirmado));
            bd.AppendChild(database);

            XmlElement user = xml.CreateElement("user");
            user.AppendChild(xml.CreateTextNode(UserFirmado));
            bd.AppendChild(user);
                        
            //Element codvendedor
            XmlElement codvendedor = xml.CreateElement("codvendedor");
            codvendedor.AppendChild(xml.CreateTextNode("1"));
            raiz.AppendChild(codvendedor);

            //Element idtipodoc
            XmlElement idtipodoc = xml.CreateElement("idtipodoc");
            idtipodoc.AppendChild(xml.CreateTextNode("5"));
            raiz.AppendChild(idtipodoc);

            //Element serie
            XmlElement serie = xml.CreateElement("serie");
            serie.AppendChild(xml.CreateTextNode(SerieDoc));
            raiz.AppendChild(serie);

            //Element numero
            XmlElement numero = xml.CreateElement("numero");
            numero.AppendChild(xml.CreateTextNode(NumDoc.ToString()));
            raiz.AppendChild(numero);

            //Element b
            XmlElement b = xml.CreateElement("n");
            b.AppendChild(xml.CreateTextNode("B"));
            raiz.AppendChild(b);
                        
            //xml.Save(RutaXml + SerieDoc + "-" + NumDoc + ".xml");
            xml.Save(RutaXml + "Fel.xml");
        }
    }
}
