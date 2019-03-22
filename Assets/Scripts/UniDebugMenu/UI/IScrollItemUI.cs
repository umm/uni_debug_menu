﻿using System;

namespace UniDebugMenu.Internal
{
	/// <summary>
	/// スクロール内の要素のインターフェイス
	/// </summary>
	public interface IScrollItemUI<T>
	{
		//==============================================================================
		// デリゲート
		//==============================================================================
		/// <summary>
		/// 変更された時に呼び出されます
		/// </summary>
		Action<int> mOnComplete { set; }

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 表示を設定します
		/// </summary>
		void SetDisp( T data );
	}
}