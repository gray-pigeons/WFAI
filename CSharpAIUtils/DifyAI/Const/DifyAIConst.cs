using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtils.DifyAI.Const
{
    internal class DifyAIConst
    {
    }

    public enum DifyRsponseMode
    {
        /// <summary>
        /// 流式模式（推荐）。基于 SSE（Server-Sent Events）实现类似打字机输出方式的流式返回
        /// </summary>
        Streaming,
        /// <summary>
        /// 阻塞模式，等待执行完毕后返回结果。
        /// </summary>
        Blocking,
    }
}
