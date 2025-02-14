﻿using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums; 

/// <summary>
/// 标签大小
/// </summary>
public enum TabSize {
    /// <summary>
    /// 默认
    /// </summary>
    [Description( "default" )]
    Default,
    /// <summary>
    /// 小尺寸
    /// </summary>
    [Description( "small" )]
    Small,
    /// <summary>
    /// 大尺寸
    /// </summary>
    [Description( "large" )]
    Large
}