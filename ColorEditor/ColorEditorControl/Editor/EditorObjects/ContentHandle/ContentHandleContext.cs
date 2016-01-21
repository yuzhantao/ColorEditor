﻿using System.Collections.Generic;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    /// <summary>
    /// 对象处理上下文
    /// </summary>
    class ContentHandleContext : IContentHandle
    {
        private static List<IContentHandle> AllObjectHandleList;
        private IContentHandle m_objectHandle;

        public void Input(EditorEditArea area,int pos, EditorContent content)
        {
            foreach(IContentHandle obj in this.GetAllObjectHandleList())
            {
                obj.Input(area, pos, content);
            }
        }

        private List<IContentHandle> GetAllObjectHandleList()
        {
            if(AllObjectHandleList== null)
            {
                AllObjectHandleList = new List<IContentHandle>();

                AllObjectHandleList.Add(new GeneralWordsHandle());
                AllObjectHandleList.Add(new BackspaceKeyHandle());
                AllObjectHandleList.Add(new LeftKeyHandle());
                AllObjectHandleList.Add(new RightKeyHandle());
                AllObjectHandleList.Add(new MouseDownHandle());
                AllObjectHandleList.Add(new UpKeyHandle());
                AllObjectHandleList.Add(new DownKeyHandle());
                AllObjectHandleList.Add(new ImageHandle());
            }

            return AllObjectHandleList;
        }
    }
}
