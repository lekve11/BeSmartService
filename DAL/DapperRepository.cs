using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace BeSmartService.DAL
{
    public class DapperRepository<T,S> : IRepository<T,S> where T : IEntity<S>
    {
        private string _connectionString = @"Server=tcp:r461y1rqaa.database.windows.net,1433;Database=BeSmart;User ID=lekve@r461y1rqaa;Password=Ooprogramming1;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

        public void Delete(S objId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute(String.Format("Delete From {0} where {1} = @id", Reflections.GetTableName(typeof(T)), Reflections.GetPk(typeof(T))), new { id = objId });
            }
        }

        public IEnumerable<T> GetAll()
        {
           using(var db = new SqlConnection(_connectionString))
            {
                var data = db.Query<T>(Reflections.GetQuery(typeof(T)));

                return data;
            }
        }

        public T GetById(S id)
        {

            using (var db = new SqlConnection(_connectionString))
            {
                var data = db.Query<T>(String.Format("{0} where {1} = @id",Reflections.GetQuery(typeof(T)),Reflections.GetPk(typeof(T))),new  { id=id});
                return data.SingleOrDefault();
            }
        }

        public int Insert(T obj)
        {
            string tableName = Reflections.GetTableName(typeof(T));

            string colNames = String.Empty;
            string parNames = String.Empty;

            bool withPk = !obj.Id.Equals(default(S));

            var dict = obj.GetParamsDict<S>(withPk);

            foreach (var item in dict )
            {
                colNames += String.Format("{0},", item.Key);
                parNames += String.Format("@{0},", item.Key);
            }

            colNames = colNames.Substring(0, colNames.Length - 1);
            parNames = parNames.Substring(0, parNames.Length - 1);

            string query = String.Format("Insert into {0}({1}) values({2})", tableName, colNames, parNames);

            using (var db = new SqlConnection(_connectionString))
            {
                return db.Execute(query, dict);
            }

        }


        public void Update(T obj)
        {
            string tableName = Reflections.GetTableName(typeof(T));
            string pk = Reflections.GetPk(typeof(T));

            string expression = String.Empty;

            var dict = obj.GetParamsDict<S>();

            var pkWithValue = obj.GetPk<S>();
            

            foreach (var item in dict)
                expression += String.Format("{0}=@{0},", item.Key);

            dict.Add(pkWithValue.First().Key, pkWithValue.First().Value);
            expression = expression.Substring(0, expression.Length - 1);

            
            //string query = $"Update {tableName} set {expression} where {pk} = @{pk}";

            string query = String.Format("Update {0} set {1} where {2} = @{2}", tableName, expression, pk);
            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute(query, dict);
            }
        }
    }
}
