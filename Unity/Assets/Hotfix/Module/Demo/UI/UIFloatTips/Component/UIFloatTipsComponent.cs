using ETModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{

    [ObjectSystem]
    public class UIFloatTipsComponentSystem : AwakeSystem<UIFloatTipsComponent, String>
    {
        public override void Awake(UIFloatTipsComponent self, String text)
        {
            AwakeAsync(self,text).Coroutine();
        }

        public async ETVoid AwakeAsync(UIFloatTipsComponent self,string text)
        {
            self.Awake(text);
            ETModel.TimerComponent timerComponent = ETModel.Game.Scene.GetComponent<ETModel.TimerComponent>();
            await timerComponent.WaitAsync(1000);
            UIHelper.Destory(UIType.UIFloatTips);
        }
    }

    public class UIFloatTipsComponent : Component
    {

        private Text text;

        public void Awake(String txt)
        {
            ReferenceCollector rc = this.GetReferenceCollector();
            text = rc.Get<GameObject>("Text").GetComponent<Text>();
            text.text = txt;
            //rc.StartCoroutine(OnCloseLater());
        }

    
        //private IEnumerator OnCloseLater()
        //{
        //    yield return new WaitForSeconds(2);
        //    UIHelper.Destory(UIType.UIFloatTips);
        //}
    }
}
