using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Warehouse.Tools
{
    public class goodstypeNum
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNum">父类别的编号，如果没有则为空</param>
        /// <returns></returns>
        public string protect_goodstypeNum(string parentNum)
        {
            string Num="";
            string MAXnum = null;
            string date = Warehouse.Tools.GeneralTools.getDateNow();
            SqlConnection sc = DAL.DBTools.DBConn();
            SqlCommand scd = new SqlCommand();
            scd.Connection = sc;
            if (parentNum == null)
            {
                scd.CommandText = "select top 1 goodsTypeNum from GoodsType  order by goodsTypeNum desc";
                object result = scd.ExecuteScalar();
                if (result == null)
                {
                    DAL.DBTools.DBClose(sc);
                    return "1A0001";
                }
                else
                {
                    MAXnum = result.ToString();
                    string firstNum = MAXnum.Substring(0, 1);
                    string firstchar = MAXnum.Substring(1, 1);
                    if (Char.Parse((firstchar)) == 'Z')
                    {
                        Num += (int.Parse(firstNum) + 1).ToString() + 'A' + "0001";
                    }
                    else
                    {
                        Char[] c = firstchar.ToCharArray();
                        int i = (int)c[0];
                        Num += firstNum + ((Char)(i + 1)) + "0001";
                    }
                    DAL.DBTools.DBClose(sc);
                    return Num;
                }
            }
            else
            {
                string s = parentNum;
                string a = parentNum.Substring(2,1);
                s = s.Remove(2, 1);
                string parNum = s.Insert(2, (int.Parse(a)+1).ToString());

                string b=parNum.Substring(0,3);
                scd.CommandText = "select top 1 goodsTypeNum from GoodsType where goodsTypeNum like '"+b+"%' order by goodsTypeNum desc";
                object result = scd.ExecuteScalar();
                if (result == null)
                {
                    return b + "001";
                }
                else
                {
                    string max = result.ToString().Substring(3,3);
                    if (int.Parse(max) >= 9)
                    {
                        if (int.Parse(max) >= 99)
                        {
                            return b + (int.Parse(max) + 1).ToString();
                        }
                        else
                        {
                            return b +"0"+ (int.Parse(max) + 1).ToString();
                        }
                    }
                    else
                    {
                        return b +"00"+(int.Parse(max) + 1).ToString();
                    }                    
                }   
            }
        }
    }
}