using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP8PO.Converters
{
    public class IDArrayToStringConverter<T> : JsonConverter where T: Model
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IEnumerable<T> ids = (IEnumerable<T>)value;
            string str = string.Empty;
            ids.ToList().ForEach(id => str += Convert.ToString(id.ID)+",");
            if(str != string.Empty)
                str = str.Remove(str.Length - 1);
            writer.WriteValue(str);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var a = existingValue as IEnumerable<T>;
            if (existingValue == null || (a != null && a.Count() == 0))
                return new ObservableCollection<T>().AsEnumerable();

            var collection = new ObservableCollection<T>();
            foreach (var item in collection)
            {

            }

            return ((string)existingValue).Split(','); 
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IEnumerable<T>);
        }
    }
}
