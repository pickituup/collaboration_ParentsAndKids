using Autofac;
using ParentsAndKids.Services.Dialog;
using ParentsAndKids.Services.Navigation;
using ParentsAndKids.Services.OpenUrl;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace ParentsAndKids.ViewModels.Base {
    public static class ViewModelLocator {
        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty = BindableProperty.Create(propertyName: "AutoWireViewModel",
                                                                                                   returnType: typeof(bool),
                                                                                                   declaringType: typeof(ViewModelLocator),
                                                                                                   defaultValue: default(bool),
                                                                                                   propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable) {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value) {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        public static void RegisterDependencies(bool useMockServices) {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            // View models
            containerBuilder.RegisterType<WelcomeViewModel>();
            containerBuilder.RegisterType<LoginViewModel>();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<SignUpViewModel>();
            containerBuilder.RegisterType<TopViewModel>();
            containerBuilder.RegisterType<ExploreViewModel>();
            containerBuilder.RegisterType<InboxViewModel>();
            containerBuilder.RegisterType<ProfileViewModel>();

            // Services
            containerBuilder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            containerBuilder.RegisterType<DialogService>().As<IDialogService>();
            containerBuilder.RegisterType<OpenUrlService>().As<IOpenUrlService>();

            if (useMockServices) {

            } else {

            }

            if (_container != null) {
                _container.Dispose();
            }
            _container = containerBuilder.Build();
        }

        public static T Resolve<T>() {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue) {
            var view = bindable as Element;
            if (view == null) {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null) {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
