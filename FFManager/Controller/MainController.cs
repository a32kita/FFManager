﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FFManager.Models;
using FFManager.Models.Services.Twitter;

namespace FFManager.Controller
{
    /// <summary>
    /// コントローラクラスを定義します．
    /// </summary>
    public class MainController
    {
        // 非公開フィールド
        private ObservableCollection<IService> activeServices;
        private ObservableCollection<IServiceAccount<IService>> activeAccounts;
        private int currentAccountIndex;

        private EventHandler<ChangeStateEventArgs> changeState;


        // 公開プロパティ
        
        /// <summary>
        /// 利用可能なサービスのコレクションを取得します．
        /// </summary>
        public IReadOnlyCollection<IService> ActiveServices
        {
            get => this.activeServices;
        }

        /// <summary>
        /// 現在利用可能な ServiceAccount のコレクションを取得します．
        /// </summary>
        public ICollection<IServiceAccount<IService>> ActiveAccounts
        {
            get => this.activeAccounts;
        }

        /// <summary>
        /// 現在利用中のアカウントのインデックス番号を取得します．
        /// 現在ログイン済みでない場合は，-1を示します．
        /// </summary>
        public int CurrentAccountIndex
        {
            get => this.currentAccountIndex;
        }

        /// <summary>
        /// 現在利用中のアカウントを取得または，設定します．
        /// ActiveAccountsの中に登録済みでないアカウントを設定すると，例外が発生します．
        /// ログイン済みでない場合は，nullを返します．
        /// </summary>
        public IServiceAccount<IService> CurrentAccount
        {
            get => this.currentAccountIndex == -1 ? null : this.activeAccounts[this.currentAccountIndex];
            set => this.currentAccountIndex = value == null ? -1 : this.activeAccounts.IndexOf(value);
        }


        // 公開イベント

        /// <summary>
        /// State が変化した際に発生します．
        /// </summary>
        public event EventHandler<ChangeStateEventArgs> ChangeState
        {
            add => this.changeState += value;
            remove => this.changeState -= value;
        }

        /// <summary>
        /// アカウントの一覧が更新された際に発生します．
        /// </summary>
        public event NotifyCollectionChangedEventHandler AccountsChanged
        {
            add => this.activeAccounts.CollectionChanged += value;
            remove => this.activeAccounts.CollectionChanged -= value;
        }


        // コンストラクタ

        /// <summary>
        /// 新しい MainController クラスのインスタンスを初期化します．
        /// </summary>
        /// <param name="parameters"></param>
        public MainController(ControllerInitializeParameter parameters)
        {
            this.activeServices = new ObservableCollection<IService>(parameters.Services);
            this.activeAccounts = new ObservableCollection<IServiceAccount<IService>>(parameters.ServiceAccounts);
            this.currentAccountIndex = parameters.CurrentAccountIndex;
        }


        // 非公開メソッド

        private void RaiseChangeStateEventArgs(ChangeStateEventArgs e)
        {
            // nullでなければ実行
            this.changeState?.Invoke(this, e);
        }


        // その他有象無象

        public class ChangeStateEventArgs
        {

        }
    }
}
