using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public static class UIHelper
    {

        /// <summary>
        /// 创建ui的封装
        /// </summary>
        /// <param name="name">UIType</param>
        /// <returns></returns>
        public static UI Create<T>(string name) where T: Component,new()
        {
            UI ui = Create(name);
            ui.AddComponent<T>();
            return ui;
        }

        public static UI Create<T,V>(string name,V param) where T : Component, new()
        {
            UI ui = Create(name);
            ui.AddComponent<T,V>(param);
            return ui;
        }

        /// <summary>
        /// 只创建UI，不添加组件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static UI Create(string name)
        {
            try
            {
                ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
                resourcesComponent.LoadBundle(name.StringToAB());
                GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(name.StringToAB(), name);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);

                UI ui = ComponentFactory.Create<UI, string, GameObject>(name, gameObject, false);
                
                return ui;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }
        

        /// <summary>
        /// 先简答的现实创建
        /// todo 没有判断重
        /// </summary>
        public static T ShowUI<T>(string name) where T : Component, new()
        {
            UI ui = Create<T>(name);
            Game.Scene.GetComponent<UIComponent>().Add(ui);
            return ui.GetComponent<T>();
        }

        public static void Destory(string name)
        {
            Game.Scene.GetComponent<UIComponent>().Remove(name);
            ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(name.StringToAB());
        }


        public static void ShowFloatTips(string message)
        {
            Game.EventSystem.Run<string>(EventIdType.ShowFloatTips, message);
        }
    }
}
