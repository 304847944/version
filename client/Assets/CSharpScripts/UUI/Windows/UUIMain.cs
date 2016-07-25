using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UGameTools;

namespace Windows
{
    partial class UUIMain
    {

        protected override void InitModel()
        {
            base.InitModel();
            bt_fight.onClick.AddListener(() =>
                {
                    var ui = UUIManager.Singleton.CreateWindow<Windows.UUILevelList>();
                    ui.ShowWindow();
                    //UAppliaction.Singleton.GoToGameBattleGate(1);
                });
            //Write Code here
        }
        protected override void OnShow()
        {
            base.OnShow();
        }
        protected override void OnHide()
        {
            base.OnHide();
        }
    }
}