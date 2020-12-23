﻿using System.Threading.Tasks;
using System.Windows.Input;
using MVP.Services.Interfaces;
using TinyMvvm;
using TinyNavigationHelper;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace MVP.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase
    {
        protected App CurrentApp => (App)Xamarin.Forms.Application.Current;

        protected IMvpApiService MvpApiService => (App.MvpApiService);
        protected IAnalyticsService AnalyticsService { get; }
        protected IAuthService AuthService => (App.AuthService);
        protected INavigationHelper NavigationHelper { get; }

        public virtual IAsyncCommand BackCommand { get; set; }
        public virtual ICommand PrimaryCommand { get; set; }
        public virtual ICommand SecondaryCommand { get; set; }

        public LayoutState State { get; set; }

        public BaseViewModel(IAnalyticsService analyticsService, INavigationHelper navigationHelper)
        {
            AnalyticsService = analyticsService;
            NavigationHelper = navigationHelper;
            BackCommand = new AsyncCommand(() => Back());
        }

        public async virtual Task Back()
            => await NavigationHelper.BackAsync().ConfigureAwait(false);
    }
}
