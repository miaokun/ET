using ETModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETHotfix
{
    [Event(EventIdType.ShowFloatTips)]
    public class ShowFloatTips_CreateFloatTips : AEvent<String>
    {
        public override void Run(string a)
        {
            UI ui = UIHelper.Create<UIFloatTipsComponent,string>(UIType.UIFloatTips,a);
            Game.Scene.GetComponent<UIComponent>().Add(ui);
        }
    }
}
