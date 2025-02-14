﻿using System.Text;
using Util.Data.Sql.Builders.Conditions;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Conditions; 

/// <summary>
/// Is Not Null查询条件测试
/// </summary>
public class IsNotNullConditionTest {
    /// <summary>
    /// 获取结果
    /// </summary>
    private string GetResult( ISqlCondition condition ) {
        var result = new StringBuilder();
        condition.AppendTo( result );
        return result.ToString();
    }

    /// <summary>
    /// 获取条件
    /// </summary>
    [Fact]
    public void Test_1() {
        var condition = new IsNotNullCondition( "Email" );
        Assert.Equal( "Email Is Not Null", GetResult( condition ) );
    }

    /// <summary>
    /// 获取条件 - 验证列为空
    /// </summary>
    [Fact]
    public void Test_2() {
        var condition = new IsNotNullCondition( "" );
        Assert.Empty( GetResult( condition ) );
    }
}