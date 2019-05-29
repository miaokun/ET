using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ETHotfix
{
    public static class ComponentUtil
    {

        public static GameObject GetGameObject(this Component component)
        {
            return component.GetParent<UI>().GameObject;
        }

        public static ReferenceCollector GetReferenceCollector(this Component component)
        {
            return component.GetGameObject().GetComponent<ReferenceCollector>();
        }
    }
}
