using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using SimpleHtmlDom.Abstraction;

namespace SimpleHtmlDom.Elements
{
    public class Table<T> : IHtmlElement where T : class
    {
        private readonly IEnumerable<T> _data;
        private readonly IReadOnlyDictionary<string, Func<T, string>> _valueConvertors;
        private readonly string _id;
        private readonly string _name;
        private readonly string _style;

        public Table(IEnumerable<T> data,
                     IReadOnlyDictionary<string, Func<T, string>> valueConvertors = null,
                     string id = "",
                     string name = "",
                     string style = "")
        {
            _id = id;
            _name = name;
            _data = data;
            _valueConvertors = valueConvertors;
            _style = style;
        }

        public string ToHtml()
        {
            if (_data == null)
            {
                return string.Empty;
            }

            StringBuilder html = new StringBuilder();
            html.Append('<').Append(ElementNames.Table).Append(" width=\"100%\"");

            if (!string.IsNullOrWhiteSpace(_id))
            {
                html.Append(" id=\"").Append(_id).Append('\"');
            }

            if (!string.IsNullOrWhiteSpace(_name))
            {
                html.Append(" name=\"").Append(_name).Append('\"');
            }

            if (!string.IsNullOrWhiteSpace(_style))
            {
                html.Append(" style=\"").Append(_style).Append('\"');
            }

            html.Append('>');

            IEnumerable<string> headerNames = GetDataObjectPropertyNames(typeof(T));

            if (headerNames != null)
            {
                html.Append('<').Append(ElementNames.TableRow).Append('>');

                foreach (string name in headerNames)
                {
                    html.Append('<').Append(ElementNames.TableHead).Append('>').Append(name).Append("</").Append(ElementNames.TableHead).Append('>');
                }

                html.Append("</").Append(ElementNames.TableRow).Append('>');
            }

            foreach (T record in _data)
            {
                IEnumerable<string> values = GetDataObjectPropertyValues(record);
                html.Append('<').Append(ElementNames.TableRow).Append('>');

                foreach (string value in values)
                {
                    html.Append('<').Append(ElementNames.TableData).Append('>').Append(value).Append("</").Append(ElementNames.TableData).Append('>');
                }

                html.Append("</").Append(ElementNames.TableRow).Append('>');
            }

            html.Append("</").Append(ElementNames.Table).Append('>');

            return html.ToString();
        }

        private IEnumerable<string> GetDataObjectPropertyNames(Type type)
        {
            // Get public properties only
            PropertyInfo[] propertyInfos = type.GetProperties();
            List<string> names = new List<string>();

            foreach (PropertyInfo item in propertyInfos)
            {
                names.Add(GetDisplayName(item.Name));
            }

            return names;
        }

        private string GetDisplayName(string propertyName)
        {
            Attribute attribute = typeof(T).GetProperty(propertyName)?.GetCustomAttribute(typeof(DisplayAttribute), false);

            if (attribute == null
                || !(attribute is DisplayAttribute displayAttr))
            {
                // If the property does not have the data annotation name that we expect, then return property name.
                return propertyName;
            }

            return displayAttr.Name;
        }

        private IEnumerable<string> GetDataObjectPropertyValues(T obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            List<string> values = new List<string>(propertyInfos.Length);

            foreach (PropertyInfo item in propertyInfos)
            {
                if (_valueConvertors != null
                    && _valueConvertors.TryGetValue(item.Name, out Func<T, string> converter))
                {
                    values.Add(converter(obj));
                }
                else
                {
                    values.Add(item.GetValue(obj).ToString());
                }
            }

            return values;
        }
    }
}
