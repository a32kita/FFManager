﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFManager.Views.ViewModels.AuthorizePanelVMElements
{
    /// <summary>
    /// AuthorizePanel の状態の示す値を定義します。
    /// </summary>
    public enum AuthorizePanelState : Int32
    {
        /// <summary>
        /// 不明な状態
        /// </summary>
        /// <remarks>AuthorizePanelのViewModelでコンストラクタでServiceSelectを代入させることで、CanExecuteChangedを発生させるための実装</remarks>
        Unknown = 0,

        /// <summary>
        /// サービスを選択している画面
        /// </summary>
        ServiceSelect = 1,

        /// <summary>
        /// 選択したサービスにログインする画面
        /// </summary>
        ServiceLogin = 2,
    }
}
