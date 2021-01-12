using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LeafFilter.HelpDesk.Repository;
using LeafFilter.HelpDesk.Data;
using Microsoft.EntityFrameworkCore;
using LeafFilter.HelpDesk.TrackerApp.View;
using LeafFilter.HelpDesk.TrackerApp.ViewModel;
using LeafFilter.HelpDesk.TrackerApp.ViewModel.IssueViewModel;
using Microsoft.Extensions.Configuration;
using LeafFilter.HelpDesk.Service;
using LeafFilter.HelpDesk.TrackerApp.ViewModel.TicketViewModel;
using LeafFilter.HelpDesk.TrackerApp.View.TicketView;

namespace LeafFilter.HelpDesk.TrackerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private IServiceProvider _serviceProvider;        

        public IConfiguration Configuration { get; }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<HelpDeskContext>(options =>
            {
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString());
            });
            

            services.AddSingleton<ITicketService, TicketService>();
            services.AddSingleton<ITicketRepository, TicketRepository>();
            services.AddSingleton<ITicketStatusRepository, TicketStatusRepository>();
            services.AddSingleton<IIssueRepository, IssueRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            //services.AddSingleton<ISeverityTypeRepository, SeverityTypeRepository>();
            //services.AddSingleton<IIssueRepository, IssueRepository>();
            //services.AddSingleton<IIssueService, IssueService>();           
            services.AddTransient<TicketListViewModel>();
            services.AddSingleton<CreateViewModel<TicketListViewModel>>(services => () => services.GetRequiredService<TicketListViewModel>());

            services.AddTransient<MainWindowViewModel>();

            services.AddSingleton<MainWindowView>(v => new MainWindowView(v.GetRequiredService<MainWindowViewModel>()));

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider = CreateServiceProvider();
                        
            Window window = _serviceProvider.GetRequiredService<MainWindowView>();
            window.Show();            

            base.OnStartup(e);
        }
    }
}
