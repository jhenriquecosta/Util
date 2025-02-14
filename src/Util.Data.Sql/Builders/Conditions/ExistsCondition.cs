﻿using System;
using System.Text;

namespace Util.Data.Sql.Builders.Conditions; 

/// <summary>
/// Exists查询条件
/// </summary>
public class ExistsCondition : ISqlCondition {
    /// <summary>
    /// 子查询Sql生成器
    /// </summary>
    private readonly ISqlBuilder _sqlBuilder;

    /// <summary>
    /// 初始化Exists查询条件
    /// </summary>
    /// <param name="builder">子查询Sql生成器</param>
    public ExistsCondition( ISqlBuilder builder ) {
        _sqlBuilder = builder;
    }

    /// <summary>
    /// 添加到字符串生成器
    /// </summary>
    /// <param name="builder">字符串生成器</param>
    /// <exception cref="NotImplementedException"></exception>
    public void AppendTo( StringBuilder builder ) {
        if ( _sqlBuilder == null )
            return;
        builder.Append( "Exists (" );
        _sqlBuilder.AppendTo( builder );
        builder.Append( ")" );
    }
}