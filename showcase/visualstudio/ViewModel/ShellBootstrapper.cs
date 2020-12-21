#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Reflection;

namespace syncfusion.visualstudiodemo.wpf
{
    public class ShellBootstrapper : Bootstrapper<ShellViewModel>
    {
        public ShellBootstrapper()
        {
            ConventionManager.AddElementConvention<syncfusion.visualstudiodemo.wpf.DockingAdapterMVVM>(syncfusion.visualstudiodemo.wpf.DockingAdapterMVVM.ItemsSourceProperty, "DataContext", "Loaded");
        }

        private CompositionContainer container;

        protected override void Configure()
        {
            var assemblies = System.Reflection.Assembly.GetExecutingAssembly();

            AssemblyCatalog catalog = new AssemblyCatalog(assemblies);

            container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(container);

            container.Compose(batch);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] {
        Assembly.GetExecutingAssembly()
    };
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = container.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            container.SatisfyImportsOnce(instance);
        }
    }
}
