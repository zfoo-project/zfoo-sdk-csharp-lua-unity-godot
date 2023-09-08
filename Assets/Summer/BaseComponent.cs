using System;
using System.Collections.Generic;
using Summer.Base.Model;
using Spring.Core;
using Spring.Event;
using Spring.Util;
using Summer.Net.Dispatcher;
using UnityEngine;

namespace Summer.Base
{
    /// <summary>
    /// 基础组件。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Summer/Base")]
    public sealed class BaseComponent : SpringComponent
    {



        public static BaseComponent INSTANCE = null;

        private readonly List<AbstractManager> CachedModules = new List<AbstractManager>();

        public void StartSpring()
        {
            Debug.Log("start spring");
            INSTANCE = this;
            
            // 扫描路径
            var scanPaths = new List<string>()
            {
                "Summer",
                "Spring",
                "Controller"
            };
            SpringContext.AddScanPath(scanPaths);

            // 扫描全部的类
            SpringContext.Scan();

            // 事件扫描
            EventBus.Scan();

            // 网络扫描
            PacketDispatcher.Scan();

            // 获取全部的Module
            var moduleList = new List<AbstractManager>();
            var moduleComponents = SpringContext.GetBeans(typeof(AbstractManager));
            moduleComponents.ForEach(it => moduleList.Add((AbstractManager)it));
            moduleList.Sort((a, b) => b.Priority - a.Priority);
            moduleList.ForEach(it => CachedModules.Add(it));
        }


        private void Update()
        {
            for (var i = 0; i < CachedModules.Count; i++)
            {
                CachedModules[i].Update(Time.deltaTime, Time.unscaledDeltaTime);
            }
        }

    }
}