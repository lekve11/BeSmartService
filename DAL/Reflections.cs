using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService.DAL
{
    public class DalObjAttribute : Attribute
    {
        public string Alias { get; set; }

        public bool IsPrimaryKey { get; set; }
    }

    public static class Reflections
    {
        public static string GetTableName(Type type)
        {
            var dalObjAttributes = type.GetCustomAttributes(true).Where(o => o is DalObjAttribute);

            foreach (var item in dalObjAttributes)
            {
                DalObjAttribute currAttr = item as DalObjAttribute;

                if (!String.IsNullOrEmpty(currAttr.Alias))
                    return currAttr.Alias;
            }

            return null;
        }


        public static string GetQuery(Type type)
        {
            string tableName = Reflections.GetTableName(type);

            var properties = type.GetProperties();

            string expression = "Select ";

            foreach (var prop in properties)
            {
                var attrs = prop.GetCustomAttributes(true).Where(o => o is DalObjAttribute);

                foreach (var dalAttr in attrs)
                {
                    DalObjAttribute custDalAttr = dalAttr as DalObjAttribute;

                    expression += String.Format("{0}.{1} as {2},",tableName, custDalAttr.Alias, prop.Name);
                }
            }

            expression = expression.Substring(0, expression.Length - 1);

            expression += String.Format(" From {0}", tableName);

            return expression;
        }

        public static string GetPk(Type type)
        {
            var props = type.GetProperties();

            foreach (var propItem in props)
            {
                var custAttrs = propItem.GetCustomAttributes(true).Where(o => o is DalObjAttribute);

                foreach (var  dalAttrItem in custAttrs)
                {
                    DalObjAttribute dalAttrs = dalAttrItem as DalObjAttribute;

                    if (dalAttrs.IsPrimaryKey)
                        return dalAttrs.Alias;
                }
            }

            return null;
        }

        public static Dictionary<string,object> GetPk<T>(this IEntity<T> entity)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            var props = entity.GetType().GetProperties();

            foreach (var propItem in props)
            {
                var custAttrs = propItem.GetCustomAttributes(true).Where(o => o is DalObjAttribute);

                foreach (DalObjAttribute dalAttr in custAttrs)
                {
                    if (dalAttr.IsPrimaryKey)
                        dict.Add(dalAttr.Alias, propItem.GetValue(entity));
                }

            }

            return dict; ;
        }

        public static Dictionary<string, object> GetParamsDict<T>(this IEntity<T> entity,bool withPrimaryKey=false){

            Dictionary<string, object> dict = new Dictionary<string, object>();

            var props = entity.GetType().GetProperties();

            foreach (var propItem in props)
            {
                var dalAttrs = propItem.GetCustomAttributes(true).Where(o => o is DalObjAttribute);

                foreach (DalObjAttribute dalItemAttr in dalAttrs)
                {
                    if (dalItemAttr.IsPrimaryKey && !withPrimaryKey)
                        continue;

                     dict.Add(dalItemAttr.Alias, propItem.GetValue(entity));
                }
            }

            return dict;
        }

    }
}
