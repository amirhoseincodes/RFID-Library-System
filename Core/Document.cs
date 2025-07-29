using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MR6100Demo.classes
{
    public static class ObjectExtensions
    {
        public static T ToObject<T>(this IDictionary<string, object> source)
            where T : class, new()
        {
            T someObject = new T();
            Type someObjectType = someObject.GetType();

            foreach (KeyValuePair<string, object> item in source)
            {
                someObjectType.GetProperty(item.Key).SetValue(someObject, item.Value, null);
            }

            return someObject;
        }

        public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );

        }
    }

    class Document
    {
        public string doc_Authors {get; set;}
        public long doc_Key { get; set; }
        public long doc_DB { get; set; }
        public string doc_PlaceSpec { get; set; }
        public string doc_RFID_UID { get; set; }
        public string doc_Imprint { get; set; }
        public string doc_BarCode { get; set; }
        public string doc_Notes { get; set; }
        public string doc_Title { get; set; }
        public long doc_DBMFN { get; set; }
        public string doc_RegisterNum { get; set; }
        public Loaned loaned { get; set; }

        public override string ToString()
        {
            string[] array = { 
                                 doc_Key.ToString(), 
                                 doc_Title, 
                                 // doc_Authors, 
                                 doc_RFID_UID, 
                                 doc_BarCode, 
                                 // doc_RegisterNum, 
                                 // doc_PlaceSpec, 
                                 loaned == null ? "" : loaned.ToString() 
                             };

            return string.Join(", ", array);
        }
    }

    class Loaned
    {
        public long member { get; set; }
        public string member_name { get; set; }
        public string LoanTime { get; set; }

        override
        public string ToString()
        {

            return member_name == null ? "" : member_name + " [" + member.ToString() + "]";
        }
    }
}
