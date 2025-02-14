﻿using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Cascaders.Builders;

namespace Util.Ui.NgZorro.Components.Cascaders.Renders; 

/// <summary>
/// 级联选择渲染器
/// </summary>
public class CascaderRender : FormControlRenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化级联选择渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public CascaderRender( Config config ) : base( config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Init() {
        SetControlId();
    }

    /// <summary>
    /// 添加表单控件
    /// </summary>
    protected override void AppendControl( TagBuilder formControlBuilder ) {
        var builder = new CascaderBuilder( _config );
        builder.Config();
        _config.Content.AppendTo( builder );
        formControlBuilder.AppendContent( builder );
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new CascaderRender( _config.Copy() );
    }
}