using System;
using System.Net;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
	[ObjectSystem]
	public class UiLoginComponentSystem : AwakeSystem<UILoginComponent>
	{
		public override void Awake(UILoginComponent self)
		{
			self.Awake();
		}
        
	}
    
    public class UILoginComponent: Component
	{
		private GameObject account;
		private GameObject loginBtn;

        private Button testBtn;

		public void Awake()
		{
			ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			loginBtn = rc.Get<GameObject>("LoginBtn");
			loginBtn.GetComponent<Button>().onClick.Add(OnLogin);
			this.account = rc.Get<GameObject>("Account");

            testBtn = rc.Get<GameObject>("TestButton").GetComponent<Button>();
            testBtn.onClick.Add(OnTestButtonClick);

        }

        private void OnTestButtonClick()
        {
            Debug.Log("test button");
            Game.EventSystem.Run<string>(EventIdType.ShowFloatTips, "test float tips");
        }

        public void OnLogin()
		{
			LoginHelper.OnLoginAsync(this.account.GetComponent<InputField>().text).Coroutine();
		}
	}
}
