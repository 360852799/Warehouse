using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ReceiverBLL
    {
        /// <summary>
        /// 添加一个收货商.
        /// </summary>
        /// <param name="rec">收货商对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addReceiver(Model.Receiver rec)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 是否已有同名的收货商.
        /// </summary>
        /// <param name="nname">收货商名称.</param>
        /// <returns>如果有,则返回True;没有,返回False.</returns>
        public bool hasReceiverOfName(string nname)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加多个收货商。
        /// </summary>
        /// <param name="recs">收货商泛型集合</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addReceivers(List<Model.Receiver> recs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据名称,删除收货商.
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteReceiverByName()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有的收货商.
        /// </summary>
        /// <returns>收货商泛型集合.</returns>
        public List<Model.Receiver> getAllReceiver()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过名称,获取某个收货商.
        /// </summary>
        /// <returns>收货商对象</returns>
        public Model.Receiver getReceiverByName()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个收货商的信息.
        /// </summary>
        /// <param name="rec">收货商对象</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool updateReceiver(Model.Receiver rec)
        {
            throw new System.NotImplementedException();
        }
    }
}
