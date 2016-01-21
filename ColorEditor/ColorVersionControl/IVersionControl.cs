using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorVersionControl
{
    /// <summary>
    /// 版本控制接口
    /// </summary>
    interface IVersionControl<T>
    {
        /// <summary>
        /// 获取版本列表
        /// </summary>
        /// <returns></returns>
        List<T> GetHistoryList();

        bool Commint(string msg);

        bool Push(string address, string versionName);

        bool Pull(string address);

        void Diff();
    }
}
