using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Sharps
{
    public class Database
    {
        private static Database self;
        private IDatabase db;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 单例模式
        public static Database getInstanse() {
            if (self == null)
                self = new Database();
            return self;
        }
        public Database()
        {
            db = OledbDatabase.getInstanse();
        }

        public void init()
        {
            db.Connect("asdasd");
        }

        /// <summary>
        /// 某一列的内容
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> getaRow<T>(String sql)
        {
            List<T> list = new List<T>();
            DataTable dt = db.Query(sql);
            DataTableReader reader = new DataTableReader(dt);
            while (reader.Read())
            {
                Object obj = reader.GetValue(0);
                list.Add((T)obj);
            }

            return list;
        }
    }
}
