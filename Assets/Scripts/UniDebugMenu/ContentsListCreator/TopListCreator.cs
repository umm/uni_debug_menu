using System;
using System.Collections.Generic;
using System.Linq;

namespace UniDebugMenu
{
    /// <summary>
    /// デバッグメニューのトップ画面のリストを作成するクラス
    /// </summary>
    [Serializable]
    public sealed class TopListCreator : ListCreatorBase<ActionData>, IDisposable
    {
        //==============================================================================
        // 変数(readonly)
        //==============================================================================
        private readonly ActionData[] m_sourceList;

        // ログ情報のリストを作成するインスタンス
        private readonly LogListCreator m_logDataCreator = new LogListCreator(1500);

        //==============================================================================
        // 変数
        //==============================================================================
        private IList<ActionData> m_list;

        //==============================================================================
        // プロパティ
        //==============================================================================
        public override int Count => m_list.Count;

        //==============================================================================
        // 関数
        //==============================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TopListCreator()
        {
            m_sourceList = new[]
            {
                new ActionData("システム情報", () => OpenAdd(DMType.TEXT_TAB_6, new SystemInfoListCreator())),
                new ActionData("システムコマンド", () => OpenAdd(DMType.COMMAND_TAB_6, new SystemCommandListCreator())),
                new ActionData("ゲームオブジェクト一覧", () => OpenAdd(DMType.COMMAND_TAB_6, new GameObjectListCreator())),
                new ActionData("ログ情報", () => OpenAdd(DMType.TEXT_TAB_6, m_logDataCreator)),
            };
        }

        /// <summary>
        /// 初期化します
        /// </summary>
        public void Init() => m_logDataCreator.Init();

        /// <summary>
        /// 破棄します
        /// </summary>
        public void Dispose() => m_logDataCreator.Dispose();

        /// <summary>
        /// リストの表示に使用するデータを作成します
        /// </summary>
        protected override void DoCreate(ListCreateData data)
        {
            m_list = m_sourceList
                    .Where(c => data.IsMatch(c.m_text))
                    .ToArray()
                    .ReverseIf(data.IsReverse)
                ;
        }

        /// <summary>
        /// 指定されたインデックスの要素の表示に使用するデータを返します
        /// </summary>
        protected override ActionData DoGetElemData(int index) => m_list.ElementAtOrDefault(index);
    }
}