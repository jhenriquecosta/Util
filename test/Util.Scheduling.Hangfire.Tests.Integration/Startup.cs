using System;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Data.EntityFrameworkCore;
using Util.Helpers;
using Util.Tests.UnitOfWorks;
using Xunit.DependencyInjection.Logging;
using Environment = Util.Helpers.Environment;

namespace Util.Scheduling.Hangfire.Tests {
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup {
        /// <summary>
        /// 配置主机
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            hostBuilder.ConfigureDefaults( null )
                .ConfigureWebHostDefaults( webHostBuilder => {
                    webHostBuilder
                        .Configure( t => {
                            t.UseRouting();
                            t.UseEndpoints( endpoints => {
                                endpoints.MapControllers();
                                endpoints.MapHangfireDashboard();
                            } );
                        } );
                } )
                .AddUtil( options => {
                    Environment.SetDevelopment();
                    options.UseHangfire( config => 
                        config.UseSqlServerStorage( Config.GetConnectionString( "HangfireConnection" ) ),
                        config => config.SchedulePollingInterval = TimeSpan.FromSeconds( 1 )
                    )
                    .UseSqlServerUnitOfWork<ITestUnitOfWork, SqlServerUnitOfWork>( Config.GetConnectionString( "connection" ) );
                } );
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
	        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
			services.AddMvc();
            InitDatabase( services );
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        private void InitDatabase( IServiceCollection services ) {
            var unitOfWork = services.BuildServiceProvider().GetService<ITestUnitOfWork>();
            unitOfWork.EnsureDeleted();
            unitOfWork.EnsureCreated();
        }
    }
}
